using AutoMapper;
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
	}
}
