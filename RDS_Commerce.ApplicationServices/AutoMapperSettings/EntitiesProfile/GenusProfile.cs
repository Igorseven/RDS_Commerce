using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.GenusRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class GenusProfile : Profile
{
	public GenusProfile()
	{
		CreateMap<Genus, GenusDtoForRegister>()
			.ReverseMap();
		
		CreateMap<Genus, GenusDtoForUpdate>()
			.ForMember(gr => gr.GenusId, map => map.MapFrom(g => g.Id))
			.ReverseMap();

        CreateMap<Genus, GenusDtoResponse>()
            .ForMember(gr => gr.GenusId, map => map.MapFrom(g => g.Id));
    } 
}
