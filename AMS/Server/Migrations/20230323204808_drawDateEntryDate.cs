using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class drawDateEntryDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                table: "Sales",
                newName: "EntryDate");

            migrationBuilder.RenameColumn(
                name: "PayInAmount",
                table: "Sales",
                newName: "WinAmount");

            migrationBuilder.AddColumn<DateTime>(
                name: "DrawDate",
                table: "Sales",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrawDate",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "WinAmount",
                table: "Sales",
                newName: "PayInAmount");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "Sales",
                newName: "TransactionDate");
        }
    }
}
