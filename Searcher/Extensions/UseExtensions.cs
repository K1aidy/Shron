using Autofac;
using Microsoft.Extensions.Configuration;
using Searcher.Abstractions;
using Searcher.Context;
using System.IO;

namespace Searcher.Api.Extensions
{
	public static class UseExtensions
	{
		public static ContainerBuilder UseDataBase(this ContainerBuilder builder)
		{
			builder.RegisterType<ShronContext>();

			return builder;
		}

		public static ContainerBuilder UseConfiguration(this ContainerBuilder builder)
		{
			var configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

			var configuration = configurationBuilder.Build();

			builder.RegisterInstance(configuration)
				.As<IConfigurationRoot>();

			return builder;
		}

		public static ContainerBuilder UseTicketSearch(this ContainerBuilder builder)
		{
			builder.RegisterType<SearchManager>()
				.As<ISearchManager>();

			builder.RegisterType<SearchClient>()
				.As<ISearchClient>();

			return builder;
		}
	}
}
