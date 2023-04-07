using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.ShippingAddressRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.ShippingAddressResponse;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class ShippingAddressProfile : Profile
{
	public ShippingAddressProfile()
	{
		CreateMap<ShippingAddress, ShippingAddressDtoForRegister>().ReverseMap();

		CreateMap<ShippingAddress, ShippingAddressDtoForSearchResponse>()
			.ForMember(sr => sr.ShippingAddressId, map => map.MapFrom(sa => sa.Id))
			.ReverseMap();
	}
}
