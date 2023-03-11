namespace RDS_Commerce.ApplicationServices.Dtos.Request.ManagerRequest;
public sealed class ManagerDtoForRegister
{
    public string FullName { get; set; }
    public string Login { get; init; }
    public string Password { get; init; }
    public string ConfirmPassword { get; init; }
}
