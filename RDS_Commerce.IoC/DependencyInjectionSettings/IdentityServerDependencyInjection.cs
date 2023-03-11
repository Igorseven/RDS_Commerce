using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class IdentityServerDependencyInjection
{
    public static void AddIdentityDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityCore<AccountIdentity>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            options.User.AllowedUserNameCharacters = IdentityExtension.GetAllWritableCharacters(Encoding.UTF8);
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
        })
            .AddRoles<IdentityRole>()
            .AddSignInManager<SignInManager<AccountIdentity>>()
            .AddEntityFrameworkStores<RdsApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtToken:JwtKey"])),
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ClockSkew = TimeSpan.Zero
               };

           })
           .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(IdentityConstants.ApplicationScheme);

        services.AddScoped<RdsApplicationDbContext>();
    }
}
