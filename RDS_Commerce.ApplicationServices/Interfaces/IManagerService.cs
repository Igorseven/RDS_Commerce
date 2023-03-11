using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.ManagerRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.ManagerResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IManagerService : IDisposable
{
    Task<bool> CreateManagerAccountAsync(ManagerDtoForRegister managerDtoForRegister);
    Task<ManagerDtoLoginResponse> LoginAsync(UserLogin userLogin);
}
