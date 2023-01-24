using Microsoft.EntityFrameworkCore;
using Parking.Context;
using Parking.Interfaces;
using Parking.Services;

var builder = WebApplication.CreateBuilder(args);               
var configuration = builder.Configuration;

builder.Services.AddDbContext<ParkingContext>(
    options => options.UseSqlServer(configuration.GetConnectionString("MsSqlServerExpress")));

builder.Services.AddControllers();

builder.Services.AddTransient<IClientDbService, ClientService>();
builder.Services.AddTransient<ICarDbService, CarService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
