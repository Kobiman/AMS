using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class GameCommission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "08e46806-f915-4a28-9b33-3ee856bff792");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "3f0286fb-4d6b-4121-96f7-bb4f3e567c1e");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4023d2aa-dca2-4077-9318-1df7e4fefe85");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "6b4314b2-ddd2-491b-b79d-18210f25ce85");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "72d2c964-c73b-4369-885a-a953496c9852");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "79cac339-16eb-429c-905f-1e7d6c7aed74");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "89b1df81-e5d8-48be-b3dc-3c6e647b601a");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "9479a6df-de29-4e01-8a57-8dff37875903");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "a062b20b-cd7d-4a7d-b39a-1ffc464af334");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "a5c49f5d-f597-4274-b950-0c168b7e7377");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "ab74a590-2762-4eb8-820f-e62d9ccfbaef");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "dca7dd73-98f5-47ca-8906-3b9662090bad");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "e3433ab5-ddd8-4a34-9c50-f7800c2dfff6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "f425b971-7e73-42f0-b8a4-fd65a3860bbf");

            migrationBuilder.AddColumn<decimal>(
                name: "Commission",
                table: "Games",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Commission", "Name", "Srl" },
                values: new object[,]
                {
                    { "1432e60e-9ad0-4668-b46f-acc6cf0f5e1f", 0m, "VAG WEST", 6 },
                    { "179c642c-4cd4-41ea-9c8d-15793bb1bb81", 0m, "ASEDA", 13 },
                    { "26fd8c69-b382-4a24-8f9d-07871b6a2bf3", 0m, "MONDAY SPECIAL", 1 },
                    { "2d7fa351-11cf-49d5-8d88-04c1d72f6a02", 0m, "OBIRI", 10 },
                    { "3965e043-437a-4168-9836-ecc1792343ce", 0m, "LUCKY TUESDAY", 3 },
                    { "4d63d266-1c15-4608-82cf-e0e43918cc8a", 0m, "MID-WEEK", 5 },
                    { "7b5e5cfe-d2ec-4c8c-8849-5f0b304f4cd5", 0m, "AFRICA", 8 },
                    { "7e6c14b1-9f9c-4e95-a2c0-489f705025ec", 0m, "VAG EAST", 4 },
                    { "95bd1983-a589-4cc8-b7ef-b45987128c75", 0m, "FORTUNE THURSDAY", 7 },
                    { "a99582fb-ac12-4ad8-bcf3-79d428336f11", 0m, "FRIDAY BONANZA", 9 },
                    { "c2a5bfbb-01a1-4738-a82d-5497a03b6bc9", 0m, "PIONEER", 2 },
                    { "c4441cda-e572-437c-838a-97a8989d1292", 0m, "OLD SOLDIER", 12 },
                    { "dd88cd0c-ffce-420f-82a9-ead607cc70f7", 0m, "SUNDAY SPECIAL", 14 },
                    { "edf4bd41-c39a-4cfc-b108-72fca384ed80", 0m, "NATIONAL", 11 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "1432e60e-9ad0-4668-b46f-acc6cf0f5e1f");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "179c642c-4cd4-41ea-9c8d-15793bb1bb81");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "26fd8c69-b382-4a24-8f9d-07871b6a2bf3");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "2d7fa351-11cf-49d5-8d88-04c1d72f6a02");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "3965e043-437a-4168-9836-ecc1792343ce");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4d63d266-1c15-4608-82cf-e0e43918cc8a");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "7b5e5cfe-d2ec-4c8c-8849-5f0b304f4cd5");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "7e6c14b1-9f9c-4e95-a2c0-489f705025ec");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "95bd1983-a589-4cc8-b7ef-b45987128c75");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "a99582fb-ac12-4ad8-bcf3-79d428336f11");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "c2a5bfbb-01a1-4738-a82d-5497a03b6bc9");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "c4441cda-e572-437c-838a-97a8989d1292");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "dd88cd0c-ffce-420f-82a9-ead607cc70f7");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "edf4bd41-c39a-4cfc-b108-72fca384ed80");

            migrationBuilder.DropColumn(
                name: "Commission",
                table: "Games");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "Srl" },
                values: new object[,]
                {
                    { "08e46806-f915-4a28-9b33-3ee856bff792", "SUNDAY SPECIAL", 14 },
                    { "3f0286fb-4d6b-4121-96f7-bb4f3e567c1e", "LUCKY TUESDAY", 3 },
                    { "4023d2aa-dca2-4077-9318-1df7e4fefe85", "AFRICA", 8 },
                    { "6b4314b2-ddd2-491b-b79d-18210f25ce85", "FORTUNE THURSDAY", 7 },
                    { "72d2c964-c73b-4369-885a-a953496c9852", "PIONEER", 2 },
                    { "79cac339-16eb-429c-905f-1e7d6c7aed74", "FRIDAY BONANZA", 9 },
                    { "89b1df81-e5d8-48be-b3dc-3c6e647b601a", "VAG EAST", 4 },
                    { "9479a6df-de29-4e01-8a57-8dff37875903", "VAG WEST", 6 },
                    { "a062b20b-cd7d-4a7d-b39a-1ffc464af334", "NATIONAL", 11 },
                    { "a5c49f5d-f597-4274-b950-0c168b7e7377", "MONDAY SPECIAL", 1 },
                    { "ab74a590-2762-4eb8-820f-e62d9ccfbaef", "OBIRI", 10 },
                    { "dca7dd73-98f5-47ca-8906-3b9662090bad", "MID-WEEK", 5 },
                    { "e3433ab5-ddd8-4a34-9c50-f7800c2dfff6", "OLD SOLDIER", 12 },
                    { "f425b971-7e73-42f0-b8a4-fd65a3860bbf", "ASEDA", 13 }
                });
        }
    }
}
