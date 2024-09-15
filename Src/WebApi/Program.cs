using WebApi;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//My Configurations
builder.AddWebServiceCollection();
builder.Services.AddInfrastructureServices(builder.Configuration);


var app = builder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
//auto migration
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ApplicationDbContext>();
try
{
	await context.Database.MigrateAsync();
	await GenerateFakeData.SeedDataAsync(context, loggerFactory);
}
catch (Exception e)
{
	var logger = loggerFactory.CreateLogger<Program>();
	logger.LogError($"[{DateTime.Now}][ERROR: {e.Message}]");
}
//
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
