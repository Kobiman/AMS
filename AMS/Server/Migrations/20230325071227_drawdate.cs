using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class drawdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                table: "Payouts",
                newName: "EntryDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DrawDate",
                table: "Payouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrawDate",
                table: "Payouts");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "Payouts",
                newName: "TransactionDate");
        }
    }
}
