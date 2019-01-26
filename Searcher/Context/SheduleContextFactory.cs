using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Searcher.Context
{
	public class SheduleContextFactory : IDesignTimeDbContextFactory<SheduleContext>
	{
		public SheduleContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<SheduleContext>();

			optionsBuilder
				.UseSqlServer(configuration.GetConnectionString("Shron"));

			return new SheduleContext(optionsBuilder.Options);
		}
	}
}
