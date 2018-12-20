using RestSharp;
using System.Collections.Generic;

namespace Searcher.Api
{
	public class TicketSearcher
	{
		public List<string> GetFlights()
		{
			var client = new RestClient(
				"http://api.travelpayouts.com/v2/prices/latest");
					////"currency=rub&" +
					//"period_type=year&" +
					//"one_way=true&" +
					//"origin=VKO&" +
					//"destination=OVB&" +
					//"page=1&" +
					//"limit=100&" +
					//"show_to_affiliates=false&" +
					//"sorting=price&" +
					//"token=415a1706615599194fec5dfea6d7eab1");

			var request = new RestRequest(Method.GET);
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			request.AddQueryParameter("currency", "rub");
			request.AddQueryParameter("period_type", "year");
			request.AddQueryParameter("one_way", "true");
			request.AddQueryParameter("origin", "VKO");
			request.AddQueryParameter("destination", "OVB");
			request.AddQueryParameter("page", "1");
			request.AddQueryParameter("limit", "100");
			request.AddQueryParameter("show_to_affiliates", "false");
			request.AddQueryParameter("sorting", "price");
			request.AddQueryParameter("token", "415a1706615599194fec5dfea6d7eab1");
			var response = client.Execute(request);

			return new List<string>();
		}
	}
}
