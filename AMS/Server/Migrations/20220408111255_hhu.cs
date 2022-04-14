using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class hhu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "2dc50144-171c-4fe6-8c22-883a8dff843c");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "4f27423f-d177-4869-8b67-8d3f8674485a");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: "62225fb9-0d05-4e9d-bcfb-29cbb29b06c8");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "2dc50144-171c-4fe6-8c22-883a8dff843c", "Pay-Out", 0m, null, new DateTime(2022, 4, 5, 14, 30, 24, 456, DateTimeKind.Local).AddTicks(7927), null, "Liability" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "4f27423f-d177-4869-8b67-8d3f8674485a", "GCB Bank", 0m, null, new DateTime(2022, 4, 5, 14, 30, 24, 456, DateTimeKind.Local).AddTicks(7934), null, "Asset" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "Balance", "Code", "CreatedDate", "SubType", "Type" },
                values: new object[] { "62225fb9-0d05-4e9d-bcfb-29cbb29b06c8", "Pay-In", 0m, null, new DateTime(2022, 4, 5, 14, 30, 24, 456, DateTimeKind.Local).AddTicks(7909), null, "Revenue" });
        }
    }
}
