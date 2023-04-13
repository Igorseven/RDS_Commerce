using RDS_Commerce.API.Settings;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.IoC.DependencyInjectionSettings;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

AutoMapperFactoryConfigurations.Initialize();

builder.Services.AddControllersConfiguration();
builder.Services.AddFiltersHandler();
builder.Services.AddDependencyInjectionHandler(configuration);
builder.Services.AddCorsConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
