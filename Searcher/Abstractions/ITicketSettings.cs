using System.Collections.Generic;

namespace Searcher.Abstractions
{
	public interface ITicketSettings
	{
		Dictionary<string, string> Values { get; }
		string Url { get; }
		string ContentType { get; }
	}
}
