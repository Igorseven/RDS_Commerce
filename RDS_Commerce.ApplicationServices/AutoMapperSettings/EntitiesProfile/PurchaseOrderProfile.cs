using AutoMapper;
using RDS_Commerce.ApplicationServices.Dtos.Request.PurchaseOrderRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PurchaseOrderResponse;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings.EntitiesProfile;
public sealed class PurchaseOrderProfile : Profile
{
	public PurchaseOrderProfile()
	{
		CreateMap<PurchaseOrder, PurchaseOrderDtoForCreate>()
			.ForMember(oc => oc.OrderPlantDtoForAddPlantInOrders, map => map.MapFrom(o => o.OrderPlants))
			.ReverseMap();

		CreateMap<PurchaseOrder, PurchaseOrderDtoForUpdate>()
			.ForMember(oc => oc.OrderId, map => map.MapFrom(o => o.Id))
            .ForMember(oc => oc.OrderPlantDtoForUpdatePlantInOrders, map => map.MapFrom(o => o.OrderPlants))
            .ReverseMap();

		CreateMap<PurchaseOrder, PurchaseOrderDtoSearchResponse>()
			.ForMember(oc => oc.OrderId, map => map.MapFrom(o => o.Id))
			.ForMember(oc => oc.OrderPlantDtoSearchResponses, map => map.MapFrom(o => o.OrderPlants));



    }
}
