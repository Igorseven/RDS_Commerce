﻿using RDS_Commerce.ApplicationServices.Dtos.Request.GenusRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IGenusService : IDisposable
{
    Task<bool> CreateNewGenusAsync(GenusDtoForRegister saveRequest);
    Task<bool> UpdateGenusAsync(GenusDtoForUpdate updateRequest);
    Task<bool> DeleteGeneusAsync(int genusId);
    Task<GenusDtoResponse?> FindByIdAsync(int genusId);
    Task<GenusDtoResponse?> FindByGenusNameAsync(string genusName);
}
