using RestSharp;
using Searcher.Abstractions;
using Searcher.Domain.Identities;
using Searcher.Extensions;
using System.Collections.Generic;

namespace Searcher.Api
{
	public class TicketSearcher
	{
		public TicketSearcher(ITicketSettings searchSettings)
		{
			Settings = searchSettings 
				?? throw new System.ArgumentNullException(nameof(searchSettings));
			Client = new RestClient(Settings.Url);
		}

		private ITicketSettings Settings { get; }

		private RestClient Client { get; }

		/// <summary>
		/// Загрузка всех билетов
		/// </summary>
		/// <param name="origin">Аэропорт вылета</param>
		/// <param name="destination">Аэропорт прилета</param>
		/// <returns>Список билетов</returns>
		public List<TicketInfo> GetTickets(string origin, string destination)
		{
			var request = new RestRequest(Method.GET)
				.AddHeaders(Settings)
				.AddQueryParameters(Settings, origin, destination);

			var result = Client
				.Execute(request)
				.Content
				.FromJson<TicketSearchResult>();

			if (result.Success)
				return result.Data;

			return new List<TicketInfo>();
		}
	}
}
