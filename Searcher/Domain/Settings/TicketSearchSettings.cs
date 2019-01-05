using Searcher.Abstractions;
using System.Collections.Generic;

namespace Searcher
{
	public class TicketSearchSettings : ITicketSettings
	{
		public Dictionary<string, string> Values { get; set; }

		public string Url { get; set; }

		public string ContentType { get; set; }
}
}
