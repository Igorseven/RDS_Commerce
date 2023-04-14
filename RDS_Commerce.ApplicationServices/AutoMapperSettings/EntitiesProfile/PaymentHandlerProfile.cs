using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.PaymentHandlerRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PaymentHandlerResponse;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class PaymentHandlerProfile : Profile
{
	public PaymentHandlerProfile()
	{
		CreateMap<PaymentHandler, PaymentHandlerDtoForRegister>().ReverseMap();

		CreateMap<PaymentHandler, PaymentHandlerDtoForUpdate>().ReverseMap();

		CreateMap<PaymentHandler, PaymentHandlerDtoForSearchResponse>();
	}
}
