using Searcher.Abstractions;
using Searcher.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Searcher.Api
{
	public class TicketSearchClient : ITicketSearchClient
	{
		public TicketSearchClient(
			ShronContext context,
			ITicketReader reader)
		{
			Context = context 
				?? throw new ArgumentNullException(nameof(context));
			Reader = reader
				?? throw new ArgumentNullException(nameof(reader));
		}

		public ShronContext Context { get; }
		public ITicketReader Reader { get; }

		public async Task Search(CancellationToken cancellationToken)
		{
			var dict = Context
				.Dicts
				.First(d => d.Ident == "airport");

			var dictItems = Context
				.DictItems
				.Where(di => di.DictId == dict.Id);

			foreach(var origin in dictItems)
			{
				var dictItemsExcept = dictItems
					.Except(dictItems
						.Where(di => di.Id == origin.Id));
				foreach (var destination in dictItemsExcept)
				{
					var list = Reader.GetTickets(
						origin.Ident,
						destination.Ident);
				}
			}

			
			await Context.SaveChangesAsync();
		}
	}
}
