using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class _567 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Commission", "Name", "Srl" },
                values: new object[,]
                {
                    { "21cb5d47-3015-49ac-987a-b49d7122f08b", 0m, "PIONEER", 2 },
                    { "487f9e3c-91a5-4ea9-ab48-4887b55fb40b", 0m, "MID-WEEK", 5 },
                    { "5e64d84b-a016-4bdd-b2c7-fca9c26bac0d", 0m, "VAG WEST", 6 },
                    { "62c09607-2c76-4910-a952-146307eb5971", 0m, "ASEDA", 13 },
                    { "6ca9945b-918e-4d3d-8448-55bbe4281b21", 0m, "FORTUNE THURSDAY", 7 },
                    { "70485801-8011-48cf-9f51-44f0edcdfdc6", 0m, "OBIRI", 10 },
                    { "83f26d92-1431-4f60-bf18-bb2e7f010e8d", 0m, "VAG EAST", 4 },
                    { "8cb029d1-74d4-4308-b0c3-13406508f736", 0m, "AFRICA", 8 },
                    { "922f6620-1f84-4abf-b7c9-9651adf905a1", 0m, "MONDAY SPECIAL", 1 },
                    { "b088ec21-a5d9-43f6-a3fb-3e29ca44ebc4", 0m, "LUCKY TUESDAY", 3 },
                    { "b1db3c92-707a-404a-b621-c549c639ea16", 0m, "SUNDAY SPECIAL", 14 },
                    { "b4764c70-df91-4049-b3bc-6a1a7edaeae8", 0m, "NATIONAL", 11 },
                    { "d83b7665-61a3-4ee1-9133-59d86bbbdd2a", 0m, "OLD SOLDIER", 12 },
                    { "e04b762b-d674-4287-a8c6-d49ff703af06", 0m, "FRIDAY BONANZA", 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "21cb5d47-3015-49ac-987a-b49d7122f08b");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "487f9e3c-91a5-4ea9-ab48-4887b55fb40b");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "5e64d84b-a016-4bdd-b2c7-fca9c26bac0d");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "62c09607-2c76-4910-a952-146307eb5971");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "6ca9945b-918e-4d3d-8448-55bbe4281b21");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "70485801-8011-48cf-9f51-44f0edcdfdc6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "83f26d92-1431-4f60-bf18-bb2e7f010e8d");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "8cb029d1-74d4-4308-b0c3-13406508f736");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "922f6620-1f84-4abf-b7c9-9651adf905a1");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "b088ec21-a5d9-43f6-a3fb-3e29ca44ebc4");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "b1db3c92-707a-404a-b621-c549c639ea16");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "b4764c70-df91-4049-b3bc-6a1a7edaeae8");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "d83b7665-61a3-4ee1-9133-59d86bbbdd2a");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "e04b762b-d674-4287-a8c6-d49ff703af06");
        }
    }
}
