using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Services;
public class AccountIdentityService : IAccountIdentityService
{
    private readonly IAccountIdentityRepository _accountIdentityRepository;
    private readonly INotificationHandler _notificationHandler;

    public AccountIdentityService(IAccountIdentityRepository accountIdentityRepository,
                                  INotificationHandler notificationHandler
                                  )
    {
        _accountIdentityRepository = accountIdentityRepository;
        _notificationHandler = notificationHandler;
    }

    public async Task<AccountIdentity?> GetAccountIdentityLoginAsync(UserLogin userLogin)
    {
        if (!await SignPasswordAsync(userLogin))
            return null;

        return await _accountIdentityRepository.FindByPredicateAsync(i => i.NormalizedUserName == userLogin.Login.ToUpper(), true);
    }

    public async Task<bool> CreateIdentityAccountAsync(AccountIdentity accountIdentity)
    {
        var identity = await _accountIdentityRepository.FindByPredicateAsync(i => i.NormalizedUserName == accountIdentity.UserName!.ToUpper(), true);

        if (identity is not null)
            return _notificationHandler.CreateNotification("Identity", EMessage.Exist.GetDescription().FormatTo("Login"));

        accountIdentity.EmailConfirmed = true;
        accountIdentity.PhoneNumberConfirmed = true;

        var saveResult = await _accountIdentityRepository.CreateAccountAsync(accountIdentity);

        if (!saveResult.Succeeded)
            return _notificationHandler.CreateNotification("Identity", "An error occurred while trying to register identity data.");
        else
            return true;
    }

    public async Task<bool> SignPasswordAsync(UserLogin login)
    {
        var loginResult = await _accountIdentityRepository.SignPasswordAsync(login.Login, login.Password);

        if (!loginResult.Succeeded)
            return _notificationHandler.CreateNotification("Identity", "Invalid login or password.");

        return loginResult.Succeeded;
    }

    public void Dispose() => _accountIdentityRepository.Dispose();
}
