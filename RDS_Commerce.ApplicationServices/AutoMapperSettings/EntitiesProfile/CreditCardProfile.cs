using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class CreditCardProfile : Profile
{
	public CreditCardProfile()
	{
		CreateMap<CreditCardRequest, CreditCardSaveRequest>().ReverseMap();
	}
}
