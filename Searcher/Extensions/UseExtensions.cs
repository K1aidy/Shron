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
			builder.RegisterType<SearchClient>()
				.As<ISearchClient>();

			return builder;
		}
	}
}
