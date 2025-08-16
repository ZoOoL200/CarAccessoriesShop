using CarAccessoriesShop.Infrastucture.Extension;
using CarAccessoriesShop.Infrastucture.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Register the database context and other services
builder.Services.AddMarketInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// seed the database with initial data
var scop = app.Services.CreateScope();
var service = scop.ServiceProvider;
await service.GetRequiredService<ICountryKeySeeder>().SeedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
