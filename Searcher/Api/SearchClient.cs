using Searcher.Abstractions;
using Searcher.Context;
using Searcher.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Searcher.Api
{
	public class SearchClient : ISearchClient
	{
		public SearchClient(ShronContext context)
		{
			Context = context 
				?? throw new ArgumentNullException(nameof(context));
		}

		public ShronContext Context { get; }

		public async Task Search(CancellationToken cancellationToken)
		{
			await Task.Delay(1000);

			var indicator = new Indicator
			{
				Ident = DateTime.Now.ToString(),
				Name = DateTime.Now.ToString(),
				Description = "Описание"
			};

			Context.Add(indicator);

			await Context.SaveChangesAsync();
		}
	}
}
