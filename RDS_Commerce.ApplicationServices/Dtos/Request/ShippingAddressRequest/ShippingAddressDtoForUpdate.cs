namespace RDS_Commerce.ApplicationServices.Dtos.Request.ShippingAddressRequest;
public sealed class ShippingAddressDtoForUpdate
{
    public int ShippingAddressId { get; set; }
    public bool SelectedForShipping { get; set; }
    public string Street { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Complement { get; set; }
    public string Number { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}
