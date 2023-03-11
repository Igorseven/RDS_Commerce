using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantImageRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class PlantImageProfile : Profile
{
	public PlantImageProfile()
	{
		CreateMap<PlantImage, PlantImageDtoForRegister>()
			.ReverseMap();

		CreateMap<PlantImage, PlantImageDtoForUpdate>()
            .ForMember(pir => pir.PlantImageId, map => map.MapFrom(pi => pi.Id))
			.ReverseMap();

        CreateMap<PlantImage, PlantImageDtoResponse>()
			.ForMember(pir => pir.PlantImageId, map => map.MapFrom(pi => pi.Id));
	}
}
