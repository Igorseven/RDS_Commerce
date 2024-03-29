﻿using AutoMapper;
using System.Reflection;

namespace RDS_Commerce.ApplicationServices.AutoMapperSettings;
public static class AutoMapperFactoryConfigurations
{
    public static IMapper Mapper { get; private set; }
    public static MapperConfiguration Configuration { get; private set; }
    public static bool Initialized;

    public static void Initialize()
    {
        if (!Initialized)
        {
            Configuration = new MapperConfiguration(config =>
            {
                var profiles = Assembly.GetExecutingAssembly()
                                       .GetExportedTypes()
                                       .Where(p => p.IsClass && typeof(Profile).IsAssignableFrom(p));

                foreach (var profile in profiles)
                {
                    config.AddProfile((Profile)Activator.CreateInstance(profile)!);
                }
            });

            Initialized = true;
        }

        Mapper = Configuration.CreateMapper();
    }
}
