using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class SalesStaffId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Sales",
                newName: "WinsStaffId");

            migrationBuilder.AddColumn<string>(
                name: "SalesStaffId",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesStaffId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "WinsStaffId",
                table: "Sales",
                newName: "StaffId");
        }
    }
}
