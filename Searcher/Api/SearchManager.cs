using Microsoft.Extensions.Hosting;
using Searcher.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Searcher.Api
{
	public class SearchManager : BackgroundService
	{
		private ITicketSearchClient Client { get; }

		public SearchManager(ITicketSearchClient client)
		{
			Client = client 
				?? throw new ArgumentNullException(nameof(client));
		}

		protected async override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				await Client.Search(stoppingToken);
				await Task.Delay(TIMEOUT);
			}
		}

		private const int TIMEOUT = 1000;
	}
}
