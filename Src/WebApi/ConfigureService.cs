using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace WebApi
{
	public static class ConfigureService
	{
		public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			return builder.Services;
		}
	}
}
