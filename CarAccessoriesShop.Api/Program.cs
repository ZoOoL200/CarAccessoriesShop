using CarAccessoriesShop.Api.MiddelWare;
using CarAccessoriesShop.Application.Extensions;
using CarAccessoriesShop.Infrastructure.Seeders;
using CarAccessoriesShop.Infrastucture.Extension;
using CarAccessoriesShop.Infrastucture.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Register the database context and other services
builder.Services.AddMarketInfrastructure(builder.Configuration);

// Register the seeder service
builder.Services.ApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// seed the database with initial data
var scop = app.Services.CreateScope();
var service = scop.ServiceProvider;
await service.GetRequiredService<ICountryKeySeeder>().SeedAsync();
await service.GetRequiredService<IBranchSeeder>().SeedAsync();

// Configure the middleware to handle exceptions globally
app.UseMiddleware<MiddelWareException>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Accessories Shop API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
