using RDS_Commerce.API.Settings;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.IoC.DependencyInjectionSettings;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
IConfiguration configuration = builder.Configuration;

AutoMapperFactoryConfigurations.Initialize();

builder.Services.AddConfigurations();
builder.Services.AddDependencyInjectionHandler(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
