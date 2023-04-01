﻿using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.ClientRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.ClientResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IClientService : IDisposable
{
    Task<bool> RegisterClientAsync(ClientDtoForRegister clientDtoForRegister);
    Task<ClientDtoForLoginResponse?> LoginAsync(UserLogin userLogin);
}
