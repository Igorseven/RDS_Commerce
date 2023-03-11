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
    private readonly IAuthenticationTokenService<Manager> _authenticationTokenService;
    public ManagerService(INotificationHandler notification,
                          IValidate<Manager> validate,
                          IManagerRepository managerRepository,
                          IAuthenticationTokenService<Manager> authenticationTokenService)
        : base(notification, validate)
    {
        _managerRepository = managerRepository;
        _authenticationTokenService = authenticationTokenService;
    }

    public Task<bool> CreateManagerAccountAsync(ManagerDtoForRegister managerDtoForRegister)
    {
        throw new NotImplementedException();
    }

    public Task<ManagerDtoLoginResponse> LoginAsync(UserLogin userLogin)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
