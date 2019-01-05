using Newtonsoft.Json;
using System.Collections.Generic;

namespace Searcher.Domain.Identities
{
	public class TicketSearchResult
	{
		[JsonProperty("success")]
		public bool Success { get; set; }
		[JsonProperty("data")]
		public List<TicketInfo> Data { get; set; }
	}
}
