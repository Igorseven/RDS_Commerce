using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class PlantProfile : Profile
{
	public PlantProfile()
	{
		CreateMap<Plant, PlantDtoForRegister>().ReverseMap();

		CreateMap<Plant, PlantDtoForUpdate>()
			.ForMember(pr => pr.PlantId, map => map.MapFrom(p => p.Id))
			.ReverseMap();
		
		CreateMap<Plant, PlantDtoResponse>()
			.ForMember(pr => pr.PlantId, map => map.MapFrom(p => p.Id));
			

        CreateMap<Plant, PlantsDtoResponse>()
            .ForMember(pr => pr.PlantId, map => map.MapFrom(p => p.Id))
            .ForMember(pr => pr.MainImage, map => map.MapFrom(p => p.Images.SingleOrDefault(pi => pi.MainImage)));
            

        CreateMap<PageList<Plant>, PageList<PlantsDtoResponse>>();
	}
}
