using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Data.Migrations
{
    public partial class TransactionColumnsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "AccountTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "AccountTransactions");
        }
    }
}
