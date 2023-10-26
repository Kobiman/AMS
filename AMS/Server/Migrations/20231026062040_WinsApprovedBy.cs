using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class WinsApprovedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TreatedBy",
                table: "Sales",
                newName: "WinsTreatedBy");

            migrationBuilder.RenameColumn(
                name: "ApprovedBy",
                table: "Sales",
                newName: "WinsApprovedBy");

            migrationBuilder.AddColumn<string>(
                name: "SalesApprovedBy",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SalesTreatedBy",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesApprovedBy",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SalesTreatedBy",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "WinsTreatedBy",
                table: "Sales",
                newName: "TreatedBy");

            migrationBuilder.RenameColumn(
                name: "WinsApprovedBy",
                table: "Sales",
                newName: "ApprovedBy");
        }
    }
}
