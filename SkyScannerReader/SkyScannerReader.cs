using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyScannerReader
{
	public class SkyScannerReader
	{
		public List<string> GetFlights()
		{
			var client = new RestClient(
				"http://api.travelpayouts.com/v2/prices/latest?" +
					"currency=rub&" +
					"period_type=year&" +
					"one_way=true&" +
					"origin=VKO&" +
					"destination=OVB&" +
					"page=1&" +
					"limit=100&" +
					"show_to_affiliates=false&" +
					"sorting=price&" +
					"token=415a1706615599194fec5dfea6d7eab1");
			var request = new RestRequest(Method.GET);
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			IRestResponse response = client.Execute(request);

			return new List<string>();
		}
	}
}
