using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Data.Migrations
{
    public partial class AccountTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Accounts_AccountId",
                table: "AccountTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTransaction",
                table: "AccountTransaction");

            migrationBuilder.RenameTable(
                name: "AccountTransaction",
                newName: "AccountTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransaction_AccountId",
                table: "AccountTransactions",
                newName: "IX_AccountTransactions_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTransactions",
                table: "AccountTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransactions_Accounts_AccountId",
                table: "AccountTransactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransactions_Accounts_AccountId",
                table: "AccountTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTransactions",
                table: "AccountTransactions");

            migrationBuilder.RenameTable(
                name: "AccountTransactions",
                newName: "AccountTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransactions_AccountId",
                table: "AccountTransaction",
                newName: "IX_AccountTransaction_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTransaction",
                table: "AccountTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Accounts_AccountId",
                table: "AccountTransaction",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId");
        }
    }
}
