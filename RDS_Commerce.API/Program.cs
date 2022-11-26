using RDS_Commerce.API.Settings;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.IoC.DependencyInjectionSettings;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

AutoMapperFactoryConfigurations.Initialize();

builder.Services.AddControllersConfiguration();
builder.Services.AddDependencyInjectionHandler(configuration);
builder.Services.AddFiltersHandler();
builder.Services.AddCorsConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();
app.Run();
