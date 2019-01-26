using System;
using System.Collections.Generic;

namespace Searcher.Domain.Sheduler
{
	public class Shedule
	{
		public Int32 Id { get; set; }

		public String Information { get; set; }

		public Boolean IsBusy { get; set; }

		public ICollection<Task> Tasks { get; set; }
	}
}
