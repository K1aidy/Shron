using System.ComponentModel;

namespace Searcher.Enums
{
	public enum PkEnums
	{
		[Description("01_pk_shedules")]
		shedules,
		[Description("02_pk_tasks")]
		tasks,
		[Description("03_pk_jobs")]
		jobs,
		[Description("04_pk_task_dependencies")]
		task_dependencies,
		[Description("05_pk_task_statuses")]
		task_statuses,
	}
}
