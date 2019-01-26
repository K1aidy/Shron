using System;
using System.Collections.Generic;

namespace Searcher.Domain.Sheduler
{
	public class Job
	{
		public Int32 Id { get; set; }
		public String Parameter { get; set; }

		public ICollection<Task> Tasks { get; set; }
	}
}
