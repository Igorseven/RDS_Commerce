using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.ManagerRequest;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class ManagerProfile : Profile
{
	public ManagerProfile()
	{
		CreateMap<Manager, ManagerDtoForRegister>()
			.ForMember(mr => mr.Login, map => map.MapFrom(m => m.AccountIdentity.UserName))
			.ForMember(mr => mr.ConfirmPassword, map => map.MapFrom(m => m.AccountIdentity.PasswordHash))
			.ReverseMap();
	}
}
