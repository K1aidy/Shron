using Microsoft.EntityFrameworkCore.Migrations;

namespace Searcher.Migrations
{
    public partial class Adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(
				"insert into dbo.Indicators (Ident, Name, Description)" +
				"values ('airticket', 'AirTicket', 'Price on airticket')"
			);

			migrationBuilder.Sql(
				"insert into dbo.Dicts (Ident, Name, Description)" +
				"values ('currency', 'Currency', 'Currency')"
			);

			migrationBuilder.Sql(
				"insert into dbo.Dicts (Ident, Name, Description)" +
				"values ('airport', 'Airport', 'Airport')"
			);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(
				"delete from dbo.Indicators" +
				"where Ident = 'airticket')"
			);

			migrationBuilder.Sql(
				"delete from dbo.Dicts" +
				"where Ident = 'currency')"
			);
		}
    }
}
