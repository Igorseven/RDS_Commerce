using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
using RDS_Commerce.ApplicationServices.Dtos.Request.ClientRequest;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class ClientProfile : Profile
{
	public ClientProfile()
	{
		CreateMap<Client, ClientDtoForRegister>()
			.ForMember(cr => cr.Login, map => map.MapFrom(c => c.AccountIdentity.UserName))
			.ForMember(cr => cr.ConfirmPassword, map => map.MapFrom(c => c.AccountIdentity.PasswordHash))
			.ReverseMap();

        CreateMap<Client, CustomerRequest>()
                .ForMember(cr => cr.Name, map => map.MapFrom(c => c.FullName))
                .ForMember(cr => cr.Email, map => map.MapFrom(c => c.AccountIdentity.UserName))
                .ForMember(cr => cr.MobilePhone, map => map.MapFrom(c => c.AccountIdentity.PhoneNumber))
                .ForMember(cr => cr.CpfCnpj, map => map.MapFrom(c => c.DocumentNumber))
                .ForMember(cr => cr.PostalCode, map => map.MapFrom(c => c.ShippingAddresses!.FirstOrDefault(sa => sa.SelectedForShipping)!.ZipCode))
                .ForMember(cr => cr.AddressNumber, map => map.MapFrom(c => c.ShippingAddresses!.FirstOrDefault(sa => sa.SelectedForShipping)!.Number))
                .ForMember(cr => cr.ExternalReference, map => map.MapFrom(c => c.CustomerId))
                .ReverseMap();
    }
}
