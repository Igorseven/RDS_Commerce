using Microsoft.AspNetCore.Mvc;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Handler.NotificationSettings;
using System.ComponentModel.DataAnnotations;

namespace RDS_Commerce.API.EndPoints;

public sealed class PlantPost
{
    public static string Template => "/Plants";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handler => Action;



    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public static async Task<bool> Action([FromForm]PlantSaveRequest saveRequest, IPlantService plantService)
    {
        return await plantService.SaveAsync(saveRequest);
    }
}
