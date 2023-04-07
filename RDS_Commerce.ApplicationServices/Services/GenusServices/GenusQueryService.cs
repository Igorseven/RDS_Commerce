using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.Services.GenusServices;
public sealed class GenusQueryService : IGenusQueryService
{
    private readonly IGenusRespository _genusRespository;

    public GenusQueryService(IGenusRespository genusRespository)
    {
        _genusRespository = genusRespository;
    }

    public async Task<GenusDtoResponse?> FindByIdAsync(int genusId)
    {
        var genus = await _genusRespository.FindByIdAsync(genusId, null, true);

        return genus?.MapTo<Genus, GenusDtoResponse>();
    }

    public async Task<GenusDtoResponse?> FindByGenusNameAsync(string genusName)
    {
        var genus = await _genusRespository.FindByNameAsync(g => g.GenusName == genusName, true);

        return genus?.MapTo<Genus, GenusDtoResponse>();
    }
}
