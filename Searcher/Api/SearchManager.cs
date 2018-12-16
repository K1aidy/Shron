using Searcher.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Searcher.Api
{
	public class SearchManager : ISearchManager
	{
		private ISearchClient Client { get; }

		private CancellationTokenSource CancelTokenSource { get; set; }

		public SearchManager(ISearchClient client)
		{
			Client = client 
				?? throw new ArgumentNullException(nameof(client));

			CancelTokenSource = new CancellationTokenSource();
		}

		public void Start()
		{
			Task.Run(async () =>
			{
				while (!CancelTokenSource.IsCancellationRequested)
				{
					await Client.Search(CancelTokenSource.Token);
				}
			});
		}

		public void Stop() => 
			CancelTokenSource.Cancel();
	}
}
