using System.ComponentModel;

namespace Searcher.Enums
{
	public enum FkEnums
	{
		[Description("01_fk_tasks_deps_prev")]
		tasks_deps_prev,
		[Description("02_fk_tasks_deps_next")]
		tasks_deps_next,
		[Description("03_fk_tasks_shedule")]
		tasks_shedule,
		[Description("04_fk_tasks_job")]
		tasks_job,
	}
}
