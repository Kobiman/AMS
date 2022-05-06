using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class UserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "5a61e24f-c32d-4c26-95cb-02b6d307fe21");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "bbc12d8c-f5a7-4dd9-ad20-79a9e22ae441");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "d7eb473a-f889-45a3-9d93-f9af06d0cda8");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "5a61e24f-c32d-4c26-95cb-02b6d307fe21", "Pay-Out", 0m, null, new DateTime(2022, 4, 15, 10, 4, 22, 665, DateTimeKind.Local).AddTicks(2280), null, "Liability" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "bbc12d8c-f5a7-4dd9-ad20-79a9e22ae441", "GCB Bank", 0m, null, new DateTime(2022, 4, 15, 10, 4, 22, 665, DateTimeKind.Local).AddTicks(2284), null, "Asset" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "d7eb473a-f889-45a3-9d93-f9af06d0cda8", "Pay-In", 0m, null, new DateTime(2022, 4, 15, 10, 4, 22, 665, DateTimeKind.Local).AddTicks(2274), null, "Revenue" });
        }
    }
}
