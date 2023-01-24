using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.GenusRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class GenusProfile : Profile
{
	public GenusProfile()
	{
		CreateMap<Genus, GenusSaveRequest>()
			.ReverseMap();
		
		CreateMap<Genus, GenusUpdateRequest>()
			.ForMember(gr => gr.GenusId, map => map.MapFrom(g => g.Id))
			.ReverseMap();

        CreateMap<Genus, GenusSearchResponse>()
            .ForMember(gr => gr.GenusId, map => map.MapFrom(g => g.Id));
    } 
}
