using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class uio3444 : Migration
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

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Commission", "Name", "Srl" },
                values: new object[,]
                {
                    { "04c86eda-3acd-4595-ac91-8c39972444d8", 0m, "VAG EAST", 4 },
                    { "1ec2fa01-6509-4c44-be36-c14fa1671dc2", 0m, "PIONEER", 2 },
                    { "377e0c3e-47d0-4e8d-a268-358fa4dbfa05", 0m, "VAG WEST", 6 },
                    { "51933c44-1c39-493d-8c8c-a2ee51a03e5c", 0m, "ASEDA", 13 },
                    { "82e8258b-1eee-495a-bad7-64384da92505", 0m, "AFRICA", 8 },
                    { "8528e265-9fe8-4f9c-8dc1-21cf9d454356", 0m, "FRIDAY BONANZA", 9 },
                    { "8d064f0f-e39a-4714-9365-73ca7c1e3b6c", 0m, "MONDAY SPECIAL", 1 },
                    { "9d03483c-0926-43ba-91ea-6cea90f4ab9f", 0m, "OBIRI", 10 },
                    { "b91e71d4-b67e-4a33-ad11-2c2117a3e0aa", 0m, "MID-WEEK", 5 },
                    { "ccc4fc02-1778-4b35-a098-5fd1c0caef70", 0m, "SUNDAY SPECIAL", 14 },
                    { "ceb5ebbd-3140-4bf0-9a92-289192d6eb69", 0m, "OLD SOLDIER", 12 },
                    { "dedd7e2b-0ee3-48aa-b486-53255c496de5", 0m, "FORTUNE THURSDAY", 7 },
                    { "fd09b19a-3113-4f94-952a-1ede5a62d869", 0m, "LUCKY TUESDAY", 3 },
                    { "fdc4d54b-b20f-4e92-8a43-4584fdd40328", 0m, "NATIONAL", 11 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "04c86eda-3acd-4595-ac91-8c39972444d8");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "1ec2fa01-6509-4c44-be36-c14fa1671dc2");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "377e0c3e-47d0-4e8d-a268-358fa4dbfa05");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "51933c44-1c39-493d-8c8c-a2ee51a03e5c");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "82e8258b-1eee-495a-bad7-64384da92505");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "8528e265-9fe8-4f9c-8dc1-21cf9d454356");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "8d064f0f-e39a-4714-9365-73ca7c1e3b6c");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "9d03483c-0926-43ba-91ea-6cea90f4ab9f");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "b91e71d4-b67e-4a33-ad11-2c2117a3e0aa");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "ccc4fc02-1778-4b35-a098-5fd1c0caef70");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "ceb5ebbd-3140-4bf0-9a92-289192d6eb69");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "dedd7e2b-0ee3-48aa-b486-53255c496de5");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "fd09b19a-3113-4f94-952a-1ede5a62d869");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "fdc4d54b-b20f-4e92-8a43-4584fdd40328");

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
