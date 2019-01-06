using Microsoft.EntityFrameworkCore.Migrations;

namespace Searcher.Migrations
{
    public partial class Changedimension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_DictItems_DictItemId",
                table: "Dimensions");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_DictItemId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "DictItemId",
                table: "Dimensions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DictItemId",
                table: "Dimensions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_DictItemId",
                table: "Dimensions",
                column: "DictItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_DictItems_DictItemId",
                table: "Dimensions",
                column: "DictItemId",
                principalTable: "DictItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
