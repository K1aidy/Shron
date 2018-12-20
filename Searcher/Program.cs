using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Searcher.Api;
using Searcher.Api.Extensions;
using Searcher.Context;
using System.IO;
using System.Threading.Tasks;

namespace Searcher
{
	class Program
	{
		private const string hostSettings = "appsettings.json";
		private const string connectionString = "Shron";

		static async Task Main(string[] args)
		{
			var host = new HostBuilder()
				.ConfigureHostConfiguration(configHost =>
				{
					configHost.SetBasePath(Directory.GetCurrentDirectory());
					configHost.AddJsonFile(
						hostSettings, 
						optional: true, 
						reloadOnChange: true);
					//configHost.AddEnvironmentVariables(prefix: prefix);
					configHost.AddCommandLine(args);
				})
				.ConfigureServices((hostContext, services) =>
				{
					services.AddHostedService<SearchManager>();
					services.AddDbContext<ShronContext>(options => 
						options.UseSqlServer(
							hostContext.Configuration
								.GetConnectionString(connectionString)));
				})
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureContainer<ContainerBuilder>((hostContext, builder) =>
				{
					builder
						.UseTicketSearch(hostContext.Configuration);
				})
				.Build();

				await host.RunAsync();
		}
	}
}
