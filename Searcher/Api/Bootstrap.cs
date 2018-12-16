using Autofac;
using Searcher.Api.Extensions;

namespace Searcher.Api
{
	public static class Bootstrap
	{
		public static IContainer ConfigureContainer(this ContainerBuilder builder)
		{
			builder.UseConfiguration();

			builder.UseDataBase();

			builder.UseTicketSearch();

			return builder.Build();
		}
	}
}
