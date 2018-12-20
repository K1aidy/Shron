using Searcher.Abstractions;
using Searcher.Context;
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
			await Context.SaveChangesAsync();
		}
	}
}
