using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Data.Migrations
{
    public partial class ModifyTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondaryAccountId",
                table: "AccountTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "AccountTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryAccountId",
                table: "AccountTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "AccountTransactions");
        }
    }
}
