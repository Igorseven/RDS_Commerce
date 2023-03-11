using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.ManagerResponse;
public sealed class ManagerDtoLoginResponse
{
    public string Token { get; set; }
    public ERole Role { get; set; }
}
