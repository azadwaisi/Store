using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.SeedData
{
	public class GenerateFakeData
	{
		public static async Task SeedDataAsync(ApplicationDbContext context,ILoggerFactory logger)
		{
			try
			{
				if ( !await context.Products.AnyAsync() )
				{

				}
				if (!await context.ProductTypes.AnyAsync())
				{

				}
				if (!await context.ProductBrands.AnyAsync())
				{

				}
			}
			catch (Exception)
			{

				throw;
			}
			return Task.FromResult(0);
		}
	}
}
