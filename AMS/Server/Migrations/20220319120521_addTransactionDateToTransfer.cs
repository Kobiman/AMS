using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class addTransactionDateToTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "Sales",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_AgentId",
                table: "Sales",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Agents_AgentId",
                table: "Sales",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "AgentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Agents_AgentId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_AgentId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Transfers");

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
