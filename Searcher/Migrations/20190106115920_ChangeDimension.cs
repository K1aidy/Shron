using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Searcher.Migrations
{
    public partial class ChangeDimension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

			migrationBuilder.CreateTable(
                name: "Dicts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Ident = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dicts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ident = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Ident = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictItems_Dicts_DictId",
                        column: x => x.DictId,
                        principalTable: "Dicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IndId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalIndicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalIndicators_Indicators_IndId",
                        column: x => x.IndId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TechIndId = table.Column<int>(nullable: false),
                    DictId = table.Column<int>(nullable: false),
                    DictItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dimensions_Dicts_DictId",
                        column: x => x.DictId,
                        principalTable: "Dicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dimensions_DictItems_DictItemId",
                        column: x => x.DictItemId,
                        principalTable: "DictItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dimensions_TechnicalIndicators_TechIndId",
                        column: x => x.TechIndId,
                        principalTable: "TechnicalIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateLoad = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    TechIndId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorValues_TechnicalIndicators_TechIndId",
                        column: x => x.TechIndId,
                        principalTable: "TechnicalIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DictItems_DictId",
                table: "DictItems",
                column: "DictId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_DictId",
                table: "Dimensions",
                column: "DictId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_DictItemId",
                table: "Dimensions",
                column: "DictItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_TechIndId",
                table: "Dimensions",
                column: "TechIndId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorValues_TechIndId",
                table: "IndicatorValues",
                column: "TechIndId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalIndicators_IndId",
                table: "TechnicalIndicators",
                column: "IndId");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "IndicatorValues");

            migrationBuilder.DropTable(
                name: "DictItems");

            migrationBuilder.DropTable(
                name: "TechnicalIndicators");

            migrationBuilder.DropTable(
                name: "Dicts");

            migrationBuilder.DropTable(
                name: "Indicators");
        }
    }
}
