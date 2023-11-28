using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class bnmI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "0fbb9b06-1ed4-403f-a1e0-432599bf928e");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "2071dc0d-9e76-4003-92f6-d9d701b99016");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "23c9de8d-ec28-48c8-8b4f-5d7fe78d30d6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "44cc98e0-8b05-4119-baa1-2bf2f8acd76b");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "5739778d-8365-4371-a795-6c72f0287da6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "658e170b-40ff-4121-8b63-451b72c9ef9e");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "78c27457-e9bd-4e22-8ccb-5ecded47f5b0");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "7cbebd14-4d4a-4cdc-9f89-987e22fb0e60");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "91cccb6d-c0a3-4bd8-b4cd-15d7644ce80b");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "a2f4c581-8d1a-4e53-88f2-edefc4212b49");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "a5038b9d-334b-43e9-a469-c7ae1b1aa9d0");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "b44c7c0f-33df-442a-ad25-35dae2b2314f");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "c1a4344c-b1a4-4905-91b5-44a0134d9501");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "e8b5c6f8-4fd1-4c1b-880b-39fc8d588ccd");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "Srl" },
                values: new object[,]
                {
                    { "0fbb9b06-1ed4-403f-a1e0-432599bf928e", "Obiri", 10 },
                    { "2071dc0d-9e76-4003-92f6-d9d701b99016", "Friday Bonanza", 9 },
                    { "23c9de8d-ec28-48c8-8b4f-5d7fe78d30d6", "Lucky Tuesday", 3 },
                    { "44cc98e0-8b05-4119-baa1-2bf2f8acd76b", "Africa", 8 },
                    { "5739778d-8365-4371-a795-6c72f0287da6", "Sunday Special", 14 },
                    { "658e170b-40ff-4121-8b63-451b72c9ef9e", "Old Soldier", 12 },
                    { "78c27457-e9bd-4e22-8ccb-5ecded47f5b0", "Mid-Week", 5 },
                    { "7cbebd14-4d4a-4cdc-9f89-987e22fb0e60", "National", 11 },
                    { "91cccb6d-c0a3-4bd8-b4cd-15d7644ce80b", "Vag West", 6 },
                    { "a2f4c581-8d1a-4e53-88f2-edefc4212b49", "Fortune Thursday", 7 },
                    { "a5038b9d-334b-43e9-a469-c7ae1b1aa9d0", "Pioneer", 2 },
                    { "b44c7c0f-33df-442a-ad25-35dae2b2314f", "Monday Special", 1 },
                    { "c1a4344c-b1a4-4905-91b5-44a0134d9501", "Vag East", 4 },
                    { "e8b5c6f8-4fd1-4c1b-880b-39fc8d588ccd", "Aseda", 13 }
                });
        }
    }
}
