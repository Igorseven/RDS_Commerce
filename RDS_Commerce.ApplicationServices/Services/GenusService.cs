using RDS_Commerce.ApplicationServices.Dtos.Request.GenusRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.ApplicationServices.Services.Base;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS_Commerce.ApplicationServices.Services;
public sealed class GenusService : BaseService<Genus>, IGenusService
{
    private readonly IGenusRespository _genusRespository;

    public GenusService(INotificationHandler notification, 
                        IValidate<Genus> validate,
                        IGenusRespository genusRespository) 
        : base(notification, validate)
    {
        _genusRespository = genusRespository;
    }



    public Task<GenusSearchResponse> FindByAsync(int genusId)
    {
        throw new NotImplementedException();
    }

    public Task<GenusSearchResponse> FindByGenusNameAsync(string genusName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateNewGenusAsync(GenusSaveRequest saveRequest)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateGenusAsync(GenusUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteGeneusAsync(int genusId)
    {
        throw new NotImplementedException();
    }

    public void Dispose() => _genusRespository.Dispose();
}
