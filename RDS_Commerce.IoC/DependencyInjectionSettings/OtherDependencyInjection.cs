﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.Business.Handler.NotificationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.ORM.UoW;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class OtherDependencyInjection
{
    public static void AddOtherDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<RdsApplicationDbContext>();
        services.AddScoped<INotificationHandler, NotificationHandler>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
