using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class _3989 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "06545619-bef9-4be8-828d-121fcda94000");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "106ee7b5-2d0b-4576-b804-2c4f233c36e9");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "310015b7-9d58-4d7d-b880-a39b13d6142b");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "3598acf2-591a-4a4a-8dd0-cfd0a504723d");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "39ffec0a-e242-4483-9f5d-08695570249b");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4b21d758-2bbd-4903-ae3b-01c13623fa7b");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "58b6f50c-6b49-44f2-9012-7ea095852284");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "5cf6a21a-d24b-4e4c-96eb-e89048921934");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "616b2c11-a0a2-4fe5-a5a8-866a30156b00");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "76135e28-52f0-43fb-9c49-7527a90ec311");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "93b577a9-3402-4b2d-a574-f8ef3f4f37a6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "95c8f482-1f8e-4d8d-a6f6-2ddeff0c89e4");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "cdc7816e-9fdb-4e7f-aaa3-b9d43fd748eb");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "ce4ba0ce-46d2-4818-bd86-da66d1a84e1a");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Commission", "Name", "Srl" },
                values: new object[,]
                {
                    { "06545619-bef9-4be8-828d-121fcda94000", 0m, "ASEDA", 13 },
                    { "106ee7b5-2d0b-4576-b804-2c4f233c36e9", 0m, "MID-WEEK", 5 },
                    { "310015b7-9d58-4d7d-b880-a39b13d6142b", 0m, "PIONEER", 2 },
                    { "3598acf2-591a-4a4a-8dd0-cfd0a504723d", 0m, "FRIDAY BONANZA", 9 },
                    { "39ffec0a-e242-4483-9f5d-08695570249b", 0m, "FORTUNE THURSDAY", 7 },
                    { "4b21d758-2bbd-4903-ae3b-01c13623fa7b", 0m, "VAG EAST", 4 },
                    { "58b6f50c-6b49-44f2-9012-7ea095852284", 0m, "AFRICA", 8 },
                    { "5cf6a21a-d24b-4e4c-96eb-e89048921934", 0m, "MONDAY SPECIAL", 1 },
                    { "616b2c11-a0a2-4fe5-a5a8-866a30156b00", 0m, "VAG WEST", 6 },
                    { "76135e28-52f0-43fb-9c49-7527a90ec311", 0m, "OLD SOLDIER", 12 },
                    { "93b577a9-3402-4b2d-a574-f8ef3f4f37a6", 0m, "SUNDAY SPECIAL", 14 },
                    { "95c8f482-1f8e-4d8d-a6f6-2ddeff0c89e4", 0m, "OBIRI", 10 },
                    { "cdc7816e-9fdb-4e7f-aaa3-b9d43fd748eb", 0m, "NATIONAL", 11 },
                    { "ce4ba0ce-46d2-4818-bd86-da66d1a84e1a", 0m, "LUCKY TUESDAY", 3 }
                });
        }
    }
}
