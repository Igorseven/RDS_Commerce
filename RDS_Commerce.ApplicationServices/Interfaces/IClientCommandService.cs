using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.ClientRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.ClientResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IClientCommandService : IDisposable
{
    Task<bool> RegisterClientAsync(ClientDtoForRegister clientDtoForRegister);
    Task<bool> UpdateClientDataToMakePurchesesAsync(ClientDtoForUpdateToPayment clientDtoForUpdateToPayment);
    Task<ClientDtoForLoginResponse?> LoginAsync(UserLogin userLogin);
}
