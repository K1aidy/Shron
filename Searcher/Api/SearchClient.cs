using Searcher.Abstractions;
using Searcher.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Searcher.Api
{
	public class SearchClient : ISearchClient
	{
		public SearchClient(
			ShronContext context,
			TicketSearcher searcher)
		{
			Context = context 
				?? throw new ArgumentNullException(nameof(context));
			Searcher = searcher 
				?? throw new ArgumentNullException(nameof(searcher));
		}

		public ShronContext Context { get; }
		public TicketSearcher Searcher { get; }

		public async Task Search(CancellationToken cancellationToken)
		{
			var list = Searcher.GetTickets("VKO", "OVB");
			await Context.SaveChangesAsync();
		}
	}
}
