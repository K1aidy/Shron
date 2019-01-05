using RestSharp;
using Searcher.Abstractions;

namespace Searcher.Extensions
{
	public static class TicketRequestHelper
	{
		public static RestRequest AddHeaders(
			this RestRequest request,
			ITicketSettings settings)
		{
			request.AddHeader("Content-Type", settings.ContentType);
			return request;
		}

		public static RestRequest AddQueryParameters(
			this RestRequest request,
			ITicketSettings settings,
			string origin, 
			string destination)
		{
			request.AddQueryParameter("origin", origin);
			request.AddQueryParameter("destination", destination);
			foreach (var key in settings.Values.Keys)
			{
				request.AddQueryParameter(key, settings.Values[key]);
			}
			return request;
		}
	}
}
