using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class bnmI8 : Migration
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

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "Srl" },
                values: new object[,]
                {
                    { "005ad43b-4bf6-4520-ac80-1e4f0bfb5a1d", "NATIONAL", 11 },
                    { "030c7b21-0abd-45b1-b24e-740b6e13fd2b", "LUCKY TUESDAY", 3 },
                    { "0580ca71-539e-4640-937f-8cf9480209df", "MID-WEEK", 5 },
                    { "18f37add-b69e-433d-9446-48effb840333", "PIONEER", 2 },
                    { "254324c4-b22c-4c05-8f8f-da7cb7cf9807", "FORTUNE THURSDAY", 7 },
                    { "2b43ca98-608e-4591-91d0-a3ab25fe92bf", "AFRICA", 8 },
                    { "4198aa12-2dac-43c1-ac1c-4138f99e4a06", "VAG EAST", 4 },
                    { "4e271a72-1522-4853-9da8-746db9bb69aa", "OLD SOLDIER", 12 },
                    { "52ade10c-778f-49cc-8e40-7a59c1fedb94", "ASEDA", 13 },
                    { "77b86cd2-e9f6-4b33-a459-04739ecaf147", "FRIDAY BONANZA", 9 },
                    { "9df62d06-d4ca-4d14-b077-0fe92b2224d8", "SUNDAY SPECIAL", 14 },
                    { "db03b47f-0f32-48b5-b339-76fd48ce970a", "OBIRI", 10 },
                    { "f5390da2-7c1d-4658-ac72-fb7271b69cbf", "MONDAY SPECIAL", 1 },
                    { "fcf8cb32-6d8f-4fda-b7f3-2a53a2c4c963", "VAG WEST", 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "005ad43b-4bf6-4520-ac80-1e4f0bfb5a1d");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "030c7b21-0abd-45b1-b24e-740b6e13fd2b");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "0580ca71-539e-4640-937f-8cf9480209df");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "18f37add-b69e-433d-9446-48effb840333");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "254324c4-b22c-4c05-8f8f-da7cb7cf9807");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "2b43ca98-608e-4591-91d0-a3ab25fe92bf");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4198aa12-2dac-43c1-ac1c-4138f99e4a06");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4e271a72-1522-4853-9da8-746db9bb69aa");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "52ade10c-778f-49cc-8e40-7a59c1fedb94");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "77b86cd2-e9f6-4b33-a459-04739ecaf147");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "9df62d06-d4ca-4d14-b077-0fe92b2224d8");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "db03b47f-0f32-48b5-b339-76fd48ce970a");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "f5390da2-7c1d-4658-ac72-fb7271b69cbf");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "fcf8cb32-6d8f-4fda-b7f3-2a53a2c4c963");

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
