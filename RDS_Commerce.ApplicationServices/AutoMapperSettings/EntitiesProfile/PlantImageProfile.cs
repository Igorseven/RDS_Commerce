using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantImageRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class PlantImageProfile : Profile
{
	public PlantImageProfile()
	{
		CreateMap<PlantImage, PlantImageSaveRequest>();

		CreateMap<PlantImage, PlantImageUpdateRequest>();

		CreateMap<PlantImage, PlantImageSearchResponse>();
	}
}
