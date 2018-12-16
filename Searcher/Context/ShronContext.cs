using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Searcher.Domain;

namespace Searcher.Context
{
	public class ShronContext : DbContext
	{
		private const string ConnectionStringName = "Shron";

		public DbSet<Indicator> Indicators { get; set; }

		private IConfigurationRoot Configuration { get; }

		public ShronContext(IConfigurationRoot configuration) : base()
		{
			Configuration = configuration
				?? throw new System.ArgumentNullException(nameof(configuration));

			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = Configuration.GetConnectionString(ConnectionStringName);

			optionsBuilder
				.UseSqlServer(connectionString);
		}
	}
}
