﻿using System.Text.Json.Serialization;

namespace RDS_Commerce.API.Settings;

public static class ControllersConfiguration
{
    public static void AddControllersConfiguration(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    }
}
