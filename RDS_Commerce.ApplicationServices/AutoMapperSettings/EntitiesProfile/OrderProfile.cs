using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.OrderRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.OrderResponse;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class OrderProfile : Profile
{
	public OrderProfile()
	{
		CreateMap<Order, OrderDtoForCreate>()
			.ForMember(oc => oc.OrderPlantDtoForAddPlantInOrders, map => map.MapFrom(o => o.OrderPlants))
			.ReverseMap();

		CreateMap<Order, OrderDtoForUpdate>()
			.ForMember(oc => oc.OrderId, map => map.MapFrom(o => o.Id))
            .ForMember(oc => oc.OrderPlantDtoForUpdatePlantInOrders, map => map.MapFrom(o => o.OrderPlants))
            .ReverseMap();

		CreateMap<Order, OrderDtoSearchResponse>()
			.ForMember(oc => oc.OrderId, map => map.MapFrom(o => o.Id))
			.ForMember(oc => oc.OrderPlantDtoSearchResponses, map => map.MapFrom(o => o.OrderPlants));



    }
}
