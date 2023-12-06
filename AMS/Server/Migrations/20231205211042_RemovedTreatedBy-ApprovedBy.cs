using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class RemovedTreatedByApprovedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "08bb2037-b34a-45e7-a928-fa4978c20320");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "0b4e2f14-72b8-4637-a27d-df96b3c9de7d");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "0bdb1c9e-6383-4e70-baf5-4937cd2ac8da");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "2e76359c-a143-4689-95fa-8d6e00402b99");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "376ecf06-b3ba-4d9c-adc3-dccf3c8884ab");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4e3cf598-796e-43ae-9cbd-a1dd9a6404f2");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4fbf32b2-a201-40f3-ae2a-54ad56dab0ba");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "596529e9-b5f5-4741-a560-f620d201d9de");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "6be243f4-98cb-49eb-8329-e7929acbbe58");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "a7c6d1fa-0715-4f47-b691-ef466c0e4c9e");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "b4ef3086-688b-4985-957b-05e815f42ef2");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "c01879f3-23c2-4904-b258-b84611eaf859");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "ead1d20d-1335-4c88-bc46-2c06402621d0");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "fb359d48-dccf-410f-8e76-01ebfcc72ed7");

            migrationBuilder.DropColumn(
                name: "WinsApprovedBy",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "WinsTreatedBy",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSheets",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "NumberOfSheets",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "WinsApprovedBy",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WinsTreatedBy",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Commission", "Name", "Srl" },
                values: new object[,]
                {
                    { "08bb2037-b34a-45e7-a928-fa4978c20320", 0m, "AFRICA", 8 },
                    { "0b4e2f14-72b8-4637-a27d-df96b3c9de7d", 0m, "LUCKY TUESDAY", 3 },
                    { "0bdb1c9e-6383-4e70-baf5-4937cd2ac8da", 0m, "NATIONAL", 11 },
                    { "2e76359c-a143-4689-95fa-8d6e00402b99", 0m, "VAG EAST", 4 },
                    { "376ecf06-b3ba-4d9c-adc3-dccf3c8884ab", 0m, "OLD SOLDIER", 12 },
                    { "4e3cf598-796e-43ae-9cbd-a1dd9a6404f2", 0m, "MONDAY SPECIAL", 1 },
                    { "4fbf32b2-a201-40f3-ae2a-54ad56dab0ba", 0m, "VAG WEST", 6 },
                    { "596529e9-b5f5-4741-a560-f620d201d9de", 0m, "FORTUNE THURSDAY", 7 },
                    { "6be243f4-98cb-49eb-8329-e7929acbbe58", 0m, "MID-WEEK", 5 },
                    { "a7c6d1fa-0715-4f47-b691-ef466c0e4c9e", 0m, "FRIDAY BONANZA", 9 },
                    { "b4ef3086-688b-4985-957b-05e815f42ef2", 0m, "OBIRI", 10 },
                    { "c01879f3-23c2-4904-b258-b84611eaf859", 0m, "ASEDA", 13 },
                    { "ead1d20d-1335-4c88-bc46-2c06402621d0", 0m, "PIONEER", 2 },
                    { "fb359d48-dccf-410f-8e76-01ebfcc72ed7", 0m, "SUNDAY SPECIAL", 14 }
                });
        }
    }
}
