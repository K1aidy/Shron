using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Searcher.Abstractions;
using Searcher.Api;
using Searcher.Api.Extensions;
using Searcher.Context;
using System.IO;
using System.Threading.Tasks;

namespace Searcher
{
	class Program
	{
		private const string HOST_SETTINGS = "appsettings.json";
		private const string CONNECTION_STRING = "Shron";
		private const string TICKET_SETTINGS = "TicketSearchSettings";

		static async Task Main(string[] args)
		{
			var host = new HostBuilder()
				.ConfigureHostConfiguration(configHost =>
				{
					configHost.SetBasePath(Directory.GetCurrentDirectory())
						.AddJsonFile(
							HOST_SETTINGS,
							optional: true,
							reloadOnChange: true)
						.AddCommandLine(args)
						.Build();
				})
				.ConfigureServices((hostContext, services) =>
				{
					services.AddHostedService<SearchManager>();
					services.AddDbContext<ShronContext>(options => 
						options.UseSqlServer(
							hostContext.Configuration
								.GetConnectionString(CONNECTION_STRING)));
				})
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureContainer<ContainerBuilder>((hostContext, builder) =>
				{
					builder
						.UseTicketSearch(hostContext.Configuration);

					builder
						.RegisterType<TicketSearcher>();

					builder.Register((ctx) =>
						hostContext
							.Configuration
							.GetSection(TICKET_SETTINGS)
							.Get<TicketSearchSettings>()
					)
					.As<ITicketSettings>();
				})
				.Build();

				await host.RunAsync();
		}
	}
}
