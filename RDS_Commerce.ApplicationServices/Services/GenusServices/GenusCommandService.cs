using Microsoft.EntityFrameworkCore;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Request.GenusRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Services.GenusServices;
public sealed class GenusCommandService : BaseService<Genus>, IGenusCommandService
{
    private readonly IGenusRespository _genusRespository;

    public GenusCommandService(INotificationHandler notification,
                        IValidate<Genus> validate,
                        IGenusRespository genusRespository)
        : base(notification, validate)
    {
        _genusRespository = genusRespository;
    }

    public async Task<bool> CreateNewGenusAsync(GenusDtoForRegister saveRequest)
    {
        if (await _genusRespository.ExistInTheDatabaseAsync(g => g.GenusName == saveRequest.GenusName))
            return _notification.CreateNotification("Gênero", EMessage.Exist.GetDescription().FormatTo($"{saveRequest.GenusName}"));

        var genus = saveRequest.MapTo<GenusDtoForRegister, Genus>();

        if (await EntityValidationAsync(genus))
            return await _genusRespository.SaveAsync(genus);

        return false;
    }

    public async Task<bool> UpdateGenusAsync(GenusDtoForUpdate updateRequest)
    {
        if (await _genusRespository.ExistInTheDatabaseAsync(g => g.Id != updateRequest.GenusId && g.GenusName == updateRequest.GenusName))
            return _notification.CreateNotification("Gênero", "Existe um gênero com esse nome na base de dados.");

        var genus = await _genusRespository.FindByIdAsync(updateRequest.GenusId, null, false);

        if (genus is null)
            return _notification.CreateNotification("Gênero", EMessage.NotFound.GetDescription().FormatTo("Gênero"));

        SetGenusUpdate(genus, updateRequest);

        if (await EntityValidationAsync(genus))
            return await _genusRespository.UpdateAsync(genus);

        return false;
    }

    private void SetGenusUpdate(Genus genus, GenusDtoForUpdate updateRequest)
    {
        genus.Specie = updateRequest.Specie;
        genus.GenusName = updateRequest.GenusName;
    }

    public async Task<bool> DeleteGeneusAsync(int genusId)
    {
        var genus = await _genusRespository.FindByIdAsync(genusId, i => i.Include(g => g.Plants)!, true);

        if (genus is null)
            return _notification.CreateNotification("Gênero", EMessage.NotFound.GetDescription().FormatTo($"Gênero"));

        if (genus.Plants.Any())
            return _notification.CreateNotification("Gênero", "Existe plantas vinculadas a esse gênero.");

        return await _genusRespository.DeleteAsync(genusId);
    }

    public void Dispose() => _genusRespository.Dispose();
}
