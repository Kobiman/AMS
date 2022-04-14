using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class expenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "0b38d1c4-b94e-479b-a543-c99697919c51");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "76ee8a1b-eea9-4741-b62b-35cecd0c731b");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "984402ba-e8a6-426f-81e7-792125f97867");

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "2741a9dc-2119-4a88-9a6c-82da97cc7c68", "GCB Bank", 0m, null, new DateTime(2022, 4, 14, 12, 22, 2, 521, DateTimeKind.Local).AddTicks(188), null, "Asset" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "e7881ab3-9e9a-48cf-9a6c-7cd292ea3ac4", "Pay-Out", 0m, null, new DateTime(2022, 4, 14, 12, 22, 2, 521, DateTimeKind.Local).AddTicks(184), null, "Liability" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "f3642e97-7667-4367-86da-4d1b61f2db64", "Pay-In", 0m, null, new DateTime(2022, 4, 14, 12, 22, 2, 521, DateTimeKind.Local).AddTicks(179), null, "Revenue" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "2741a9dc-2119-4a88-9a6c-82da97cc7c68");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "e7881ab3-9e9a-48cf-9a6c-7cd292ea3ac4");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "f3642e97-7667-4367-86da-4d1b61f2db64");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "0b38d1c4-b94e-479b-a543-c99697919c51", "Pay-In", 0m, null, new DateTime(2022, 4, 8, 11, 12, 54, 401, DateTimeKind.Local).AddTicks(3452), null, "Revenue" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "76ee8a1b-eea9-4741-b62b-35cecd0c731b", "Pay-Out", 0m, null, new DateTime(2022, 4, 8, 11, 12, 54, 401, DateTimeKind.Local).AddTicks(3457), null, "Liability" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "984402ba-e8a6-426f-81e7-792125f97867", "GCB Bank", 0m, null, new DateTime(2022, 4, 8, 11, 12, 54, 401, DateTimeKind.Local).AddTicks(3462), null, "Asset" });
        }
    }
}
