using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.ClientResponse;
public sealed class ClientDtoForLoginResponse 
{
    public string Token { get; set; }
    public ERole Role { get; set; }
}
