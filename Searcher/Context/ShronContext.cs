using Microsoft.EntityFrameworkCore;
using Searcher.Domain;

namespace Searcher.Context
{
	public class ShronContext : DbContext
	{
		public DbSet<Indicator> Indicators { get; set; }
		public DbSet<TechnicalIndicator> TechnicalIndicators { get; set; }
		public DbSet<Dict> Dicts { get; set; }
		public DbSet<DictItem> DictItems { get; set; }
		public DbSet<Dimension> Dimensions { get; set; }
		public DbSet<IndicatorValue> IndicatorValues { get; set; }

		public ShronContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
