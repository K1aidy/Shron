namespace Searcher.Domain.Sheduler
{
	public class TaskDependency
	{
		public int Id { get; set; }
		public int TaskId { get; set; }
		public int ChildTaskId { get; set; }

		public Task Task { get; set; }
		public Task ChildTask { get; set; }
	}
}
