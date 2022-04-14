using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class columnUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "6f7f8cd4-6950-4946-85ef-9a9ec144f24b");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "92e8ee28-28f2-42f1-815b-644b5e77ad95");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "948d098a-eec3-429b-a51a-7549a1310938");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "b644dbe5-76ab-47f4-8815-188eb1352db3", "GCB Bank", 0m, null, new DateTime(2022, 4, 11, 19, 34, 34, 687, DateTimeKind.Local).AddTicks(9463), null, "Asset" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "bb517b60-da0c-4c8a-846a-4adee6d56a8b", "Pay-Out", 0m, null, new DateTime(2022, 4, 11, 19, 34, 34, 687, DateTimeKind.Local).AddTicks(9419), null, "Liability" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "e425187a-8b95-41b9-a257-dbe2b2209b80", "Pay-In", 0m, null, new DateTime(2022, 4, 11, 19, 34, 34, 687, DateTimeKind.Local).AddTicks(9410), null, "Revenue" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "b644dbe5-76ab-47f4-8815-188eb1352db3");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "bb517b60-da0c-4c8a-846a-4adee6d56a8b");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "e425187a-8b95-41b9-a257-dbe2b2209b80");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Sales");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "6f7f8cd4-6950-4946-85ef-9a9ec144f24b", "Pay-In", 0m, null, new DateTime(2022, 4, 11, 16, 35, 52, 567, DateTimeKind.Local).AddTicks(4294), null, "Revenue" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "92e8ee28-28f2-42f1-815b-644b5e77ad95", "Pay-Out", 0m, null, new DateTime(2022, 4, 11, 16, 35, 52, 567, DateTimeKind.Local).AddTicks(4303), null, "Liability" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "948d098a-eec3-429b-a51a-7549a1310938", "GCB Bank", 0m, null, new DateTime(2022, 4, 11, 16, 35, 52, 567, DateTimeKind.Local).AddTicks(4310), null, "Asset" });
        }
    }
}
