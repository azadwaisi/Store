using WebApi;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.SeedData;
using Application;
using Application.Contracts;
using WebApi.Middleware;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//My Configurations
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebServiceCollection();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddApiVersioning(options =>
{
	// Report API versions in response headers (recommended for discoverability)
	options.ReportApiVersions = true;

	// Default version if not specified.  Important!
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new ApiVersion(1, 0); // e.g., v1.0

	// Choose your versioning methods (combine as needed)
	options.ApiVersionReader = ApiVersionReader.Combine(
		new UrlSegmentApiVersionReader(), // URL Path
		new QueryStringApiVersionReader("api-version"), // Query String (customizable parameter name)
		new HeaderApiVersionReader("X-Api-Version")  // Header (customizable header name)
													 //new MediaTypeApiVersionReader("version") //For Media Type Versioning, need to specify media type in Accept Header
	);
})
.AddApiExplorer(options =>
{
	// Add the versioned API explorer, which adds support for Swagger/OpenAPI
	options.GroupNameFormat = "'v'VVV"; // Format the version as "v[major].[minor]" in Swagger

	// Substitute the version in the URL template for Swagger
	options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();
app.UseMiddleware<MiddlewareExceptionHandler>();
app.UseStaticFiles();
await app.AddWebApplicationCollection();  //.ConfigureAwait(false)

app.Run();




//singlton => هر درخواست یکبار متد سازنده ساخته میشود
//transient => به ازای هر درخواست هر بار متد سازنده صدا زده میشود
//scoped  =>  به ازای هر درخواست یکبار متد سازنده ساخته میشود.
