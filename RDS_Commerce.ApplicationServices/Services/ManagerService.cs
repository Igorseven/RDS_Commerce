using Microsoft.EntityFrameworkCore;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.ManagerRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.ManagerResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.ApplicationServices.Services.Base;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.Services;
public sealed class ManagerService : BaseService<Manager>, IManagerService
{
    private readonly IManagerRepository _managerRepository;
    private readonly IAuthenticationTokenService _authenticationTokenService;
    private readonly IAccountIdentityService _accountIdentityService;
    public ManagerService(INotificationHandler notification,
                          IValidate<Manager> validate,
                          IManagerRepository managerRepository,
                          IAuthenticationTokenService authenticationTokenService,
                          IAccountIdentityService accountIdentityService)
        : base(notification, validate)
    {
        _managerRepository = managerRepository;
        _authenticationTokenService = authenticationTokenService;
        _accountIdentityService = accountIdentityService;
    }

    public async Task<bool> CreateManagerAccountAsync(ManagerDtoForRegister managerDtoForRegister)
    {
        if (managerDtoForRegister.Password != managerDtoForRegister.ConfirmPassword)
            _notification.CreateNotification("Senha", "Senha e sua confirmação não estão em conformidade.");

        var manager = managerDtoForRegister.MapTo<ManagerDtoForRegister, Manager>();

        if (!await EntityValidationAsync(manager))
            return false;

        if (!await _accountIdentityService.CreateIdentityAccountAsync(manager.AccountIdentity))
            return false;

        return await _managerRepository.SaveAsync(manager);
    }

    public async Task<ManagerDtoLoginResponse?> LoginAsync(UserLogin userLogin)
    {
        if (!await _accountIdentityService.SignPasswordAsync(userLogin))
            return null;

        var manager = await _managerRepository.FindByPredicateAsync(m => m.AccountIdentity.NormalizedUserName == userLogin.Login!.ToUpper(), i => i
                                              .Include(m => m.AccountIdentity), true);

        if (manager is not null)
        {
            return new ManagerDtoLoginResponse
            {
                Role = manager.Role,
                Token = await _authenticationTokenService.GenerateTokenAsync(manager)
            };
        }

        return null;
    }

    public void Dispose() => _managerRepository.Dispose();
}
