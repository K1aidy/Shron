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

			var dict = new Dict
			{
				Ident = "currency",
				Name = "Валюты",
				Description = "Содержит в себе типы валют"
			};

			Context.Dicts.Add(dict);
			Context.Indicators.Add(indicator);

			await Context.SaveChangesAsync();
		}
	}
}
