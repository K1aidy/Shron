using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Searcher.Context
{
	public class ShronContextFactory : IDesignTimeDbContextFactory<ShronContext>
	{
		public ShronContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<ShronContext>();

			optionsBuilder
				.UseSqlServer(configuration.GetConnectionString("Shron"));

			return new ShronContext(optionsBuilder.Options);
		}
	}
}
