using Microsoft.EntityFrameworkCore;
using Searcher.Domain.Sheduler;
using Searcher.Enums;
using Searcher.Extensions;

namespace Searcher.Context
{
	public class SheduleContext : DbContext
	{
		public DbSet<Shedule> Shedules { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<TaskDependency> TaskDependencies { get; set; }
		public DbSet<TaskStatus> TaskStatuses { get; set; }
		public DbSet<Job> Jobs { get; set; }

		public SheduleContext(DbContextOptions options) : 
			base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(
			ModelBuilder modelBuilder)
		{
			RegisterSheduleEntity(modelBuilder);
			RegisterTaskEntity(modelBuilder);
			RegisterJobEntity(modelBuilder);
			RegisterTaskDepenendenciesEntity(modelBuilder);
			RegisterTaskStatusEntity(modelBuilder);
		}

		private void RegisterSheduleEntity(
			ModelBuilder builder)
		{
			builder.Entity<Shedule>()
				.ToTable("shedules", "sheduler")
				.HasKey(s => s.Id)
				.HasName(PkEnums.shedules.GetDesc());

			builder.Entity<Shedule>()
				.Property(s => s.Id)
				.HasColumnName("id");
			builder.Entity<Shedule>()
				.Property(s => s.Information)
				.HasColumnName("info");
			builder.Entity<Shedule>()
				.Property(s => s.IsBusy)
				.HasColumnName("is_busy");
		}

		private void RegisterTaskEntity(
			ModelBuilder builder)
		{
			builder.Entity<Task>()
				.ToTable("tasks", "sheduler")
				.HasKey(s => s.Id)
				.HasName(PkEnums.tasks.GetDesc());

			builder.Entity<Task>()
				.HasOne(t => t.Shedule)
				.WithMany(s => s.Tasks)
				.HasForeignKey(t => t.SheduleId)
				.HasConstraintName(FkEnums.tasks_shedule.GetDesc());

			builder.Entity<Task>()
				.HasOne(t => t.Job)
				.WithMany(s => s.Tasks)
				.HasForeignKey(t => t.JobId)
				.HasConstraintName(FkEnums.tasks_job.GetDesc());

			builder.Entity<Task>()
				.HasMany(g => g.PrevDependencies)
				.WithOne(s => s.ChildTask)
				.HasForeignKey(s => s.ChildTaskId)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName(FkEnums.tasks_deps_prev.GetDesc());

			builder.Entity<Task>()
				.HasMany(g => g.NextDependencies)
				.WithOne(s => s.Task)
				.HasForeignKey(s => s.TaskId)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName(FkEnums.tasks_deps_next.GetDesc());

			builder.Entity<Task>()
				.Property(s => s.Id)
				.HasColumnName("id");
			builder.Entity<Task>()
				.Property(s => s.JobId)
				.HasColumnName("job_id");
			builder.Entity<Task>()
				.Property(s => s.SheduleId)
				.HasColumnName("shedule_id");
			builder.Entity<Task>()
				.Property(s => s.CronPattern)
				.HasColumnName("cron");
			builder.Entity<Task>()
				.Property(s => s.ExecutionCount)
				.HasColumnName("exec_count");
		}

		private void RegisterJobEntity(
			ModelBuilder builder)
		{
			builder.Entity<Job>()
				.ToTable("jobs", "sheduler")
				.HasKey(s => s.Id)
				.HasName(PkEnums.jobs.GetDesc());

			builder.Entity<Job>()
				.Property(s => s.Id)
				.HasColumnName("id");
			builder.Entity<Job>()
				.Property(s => s.Parameter)
				.HasColumnName("payload");
		}

		private void RegisterTaskDepenendenciesEntity(
			ModelBuilder builder)
		{
			builder.Entity<TaskDependency>()
				.ToTable("task_dependencies", "sheduler")
				.HasKey(s => s.Id)
				.HasName(PkEnums.task_dependencies.GetDesc());

			builder.Entity<TaskDependency>()
				.HasIndex(td => new { td.TaskId, td.ChildTaskId })
				.IsUnique();

			builder.Entity<TaskDependency>()
				.Property(s => s.Id)
				.HasColumnName("id");

			builder.Entity<TaskDependency>()
				.Property(s => s.TaskId)
				.HasColumnName("task_id");

			builder.Entity<TaskDependency>()
				.Property(s => s.TaskId)
				.HasColumnName("childtask_id");
		}

		private void RegisterTaskStatusEntity(
			ModelBuilder builder)
		{
			builder.Entity<TaskStatus>()
				.ToTable("task_statuses", "sheduler")
				.HasKey(s => s.Id)
				.HasName(PkEnums.task_statuses.GetDesc());

			builder.Entity<TaskStatus>()
				.HasIndex(ts => new { ts.Ident })
				.IsUnique();

			builder.Entity<TaskStatus>()
				.Property(s => s.Id)
				.HasColumnName("id");
			builder.Entity<TaskStatus>()
				.Property(s => s.Ident)
				.HasColumnName("ident");
			builder.Entity<TaskStatus>()
				.Property(s => s.Description)
				.HasColumnName("description");
		}
	}
}
