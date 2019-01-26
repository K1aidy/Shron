using System.Collections.Generic;

namespace Searcher.Domain.Sheduler
{
	public class Task
	{
		public int Id { get; set; }

		public int JobId { get; set; }

		public int SheduleId { get; set; }

		public string CronPattern { get; set; }

		public int ExecutionCount { get; set; }

		public Shedule Shedule { get; set; }

		public Job Job { get; set; }

		public ICollection<TaskDependency> PrevDependencies { get; set; }
		public ICollection<TaskDependency> NextDependencies { get; set; }
	}
}
