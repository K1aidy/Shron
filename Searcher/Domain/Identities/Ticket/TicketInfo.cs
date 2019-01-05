using Newtonsoft.Json;
using System;

namespace Searcher.Domain.Identities
{
	public class TicketInfo
	{
		[JsonProperty("value")]
		public decimal Price { get; set; }
		[JsonProperty("trip_class")]
		public int TripClass { get; set; }
		[JsonProperty("show_to_affiliates")]
		public bool ShowToAffiliates { get; set; }
		[JsonProperty("return_date")]
		public DateTime? ReturnDate { get; set; }
		[JsonProperty("origin")]
		public string Origin { get; set; }
		[JsonProperty("number_of_changes")]
		public int NumberOfChanges { get; set; }
		[JsonProperty("gate")]
		public string Gate { get; set; }
		[JsonProperty("found_at")]
		public DateTime FoundAt { get; set; }
		[JsonProperty("duration")]
		public int Duration { get; set; }
		[JsonProperty("distance")]
		public int Distance { get; set; }
		[JsonProperty("destination")]
		public string Destination { get; set; }
		[JsonProperty("depart_date")]
		public DateTime DepartDate { get; set; }
		[JsonProperty("actual")]
		public bool Actual { get; set; }
	}
}
