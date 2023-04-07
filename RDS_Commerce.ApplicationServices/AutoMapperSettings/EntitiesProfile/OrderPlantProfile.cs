using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.OrderPlantResponse;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class OrderPlantProfile : Profile
{
	public OrderPlantProfile()
	{
		CreateMap<OrderPlant, OrderPlantDtoForAddPlantInOrder>()
			.ReverseMap();


		CreateMap<OrderPlant, OrderPlantDtoForUpdatePlantInOrder>()
			.ReverseMap();

		CreateMap<OrderPlant, OrderPlantDtoSearchResponse>()
			.ForMember(or => or.Plant, map => map.MapFrom(op => op.Plant))
			.ReverseMap();



	}
}
