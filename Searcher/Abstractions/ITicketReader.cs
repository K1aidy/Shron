using Searcher.Domain.Identities;
using System.Collections.Generic;

namespace Searcher.Abstractions
{
	public interface ITicketReader
	{
		List<TicketInfo> GetTickets(string origin, string destination);
	}
}
