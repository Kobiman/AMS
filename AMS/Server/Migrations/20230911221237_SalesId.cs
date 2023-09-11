using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class SalesId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalesId",
                table: "Payouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesId",
                table: "Payouts");
        }
    }
}
