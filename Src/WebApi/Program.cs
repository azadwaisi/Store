using WebApi;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.SeedData;
using Application;
using Application.Contracts;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//My Configurations
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebServiceCollection();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
app.UseMiddleware<MiddlewareExceptionHandler>();
app.UseStaticFiles();
await app.AddWebApplicationCollection();  //.ConfigureAwait(false)

app.Run();




//singlton => هر درخواست یکبار متد سازنده ساخته میشود
//transient => به ازای هر درخواست هر بار متد سازنده صدا زده میشود
//scoped  =>  به ازای هر درخواست یکبار متد سازنده ساخته میشود.
