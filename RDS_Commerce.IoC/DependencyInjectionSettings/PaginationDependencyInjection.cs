﻿using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.Services;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class PaginationDependencyInjection
{
    public static void AddPaginationDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IPaginationService<Plant>, PaginationService<Plant>>();
        services.AddScoped<IPaginationService<PaymentHistory>, PaginationService<PaymentHistory>>();
    }
}
