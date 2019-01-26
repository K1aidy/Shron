using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Searcher.Migrations.Shedule
{
    public partial class ShedulerInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sheduler");

            migrationBuilder.CreateTable(
                name: "jobs",
                schema: "sheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    payload = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("03_pk_jobs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shedules",
                schema: "sheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    info = table.Column<string>(nullable: true),
                    is_busy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("01_pk_shedules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_statuses",
                schema: "sheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ident = table.Column<int>(nullable: false),
                    description = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("05_pk_task_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                schema: "sheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    job_id = table.Column<int>(nullable: false),
                    shedule_id = table.Column<int>(nullable: false),
                    cron = table.Column<string>(nullable: true),
                    exec_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("02_pk_tasks", x => x.id);
                    table.ForeignKey(
                        name: "04_fk_tasks_job",
                        column: x => x.job_id,
                        principalSchema: "sheduler",
                        principalTable: "jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "03_fk_tasks_shedule",
                        column: x => x.shedule_id,
                        principalSchema: "sheduler",
                        principalTable: "shedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "task_dependencies",
                schema: "sheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    childtask_id = table.Column<int>(nullable: false),
                    ChildTaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("04_pk_task_dependencies", x => x.id);
                    table.ForeignKey(
                        name: "01_fk_tasks_deps_prev",
                        column: x => x.ChildTaskId,
                        principalSchema: "sheduler",
                        principalTable: "tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "02_fk_tasks_deps_next",
                        column: x => x.childtask_id,
                        principalSchema: "sheduler",
                        principalTable: "tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_dependencies_ChildTaskId",
                schema: "sheduler",
                table: "task_dependencies",
                column: "ChildTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_task_dependencies_childtask_id_ChildTaskId",
                schema: "sheduler",
                table: "task_dependencies",
                columns: new[] { "childtask_id", "ChildTaskId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_task_statuses_ident",
                schema: "sheduler",
                table: "task_statuses",
                column: "ident",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_job_id",
                schema: "sheduler",
                table: "tasks",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_shedule_id",
                schema: "sheduler",
                table: "tasks",
                column: "shedule_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task_dependencies",
                schema: "sheduler");

            migrationBuilder.DropTable(
                name: "task_statuses",
                schema: "sheduler");

            migrationBuilder.DropTable(
                name: "tasks",
                schema: "sheduler");

            migrationBuilder.DropTable(
                name: "jobs",
                schema: "sheduler");

            migrationBuilder.DropTable(
                name: "shedules",
                schema: "sheduler");
        }
    }
}
