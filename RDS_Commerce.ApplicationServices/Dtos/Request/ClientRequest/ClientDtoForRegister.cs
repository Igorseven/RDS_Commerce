namespace RDS_Commerce.ApplicationServices.Dtos.Request.ClientRequest;
public sealed class ClientDtoForRegister
{
    public string FullName { get; init; }
    public string DocumentCpf { get; set; }
    public string CellPhone { get; set; }
    public bool AcceptTermsAndPolicy { get; init; }
    public DateTime AcceptanceOfTermsAndPolicies { get; init; }
    public string Login { get; init; }
    public string Password { get; init; }
    public string ConfirmPassword { get; init; }
}
