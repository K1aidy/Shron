using Autofac;
using Microsoft.Extensions.Configuration;
using Searcher.Abstractions;

namespace Searcher.Api.Extensions
{
	public static class UseExtensions
	{
		public static ContainerBuilder UseTicketSearch(
			this ContainerBuilder builder,
			IConfiguration configuration)
		{
			builder.RegisterType<TicketSearchClient>()
				.As<ITicketSearchClient>();
			builder.RegisterType<TicketReader>()
				.As<ITicketReader>();

			return builder;
		}
	}
}
