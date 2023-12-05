using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class uio88888 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "5bd46ef4-3843-4121-940f-93a276001172", 0m, "MID-WEEK", 5 },
                    { "6058748d-6eca-4370-b241-44f01b20ea54", 0m, "VAG WEST", 6 },
                    { "69808a35-1a81-47fb-a77a-259998dbcddd", 0m, "NATIONAL", 11 },
                    { "6a1ae0ce-6670-4fed-9753-d7b26e4def41", 0m, "PIONEER", 2 },
                    { "6e37e316-9a89-4d2d-990e-04fd44cf4455", 0m, "LUCKY TUESDAY", 3 },
                    { "7e2151eb-85e9-4ee5-ba8a-6a46b4498496", 0m, "AFRICA", 8 },
                    { "980f1b79-5d1c-437a-98b1-a3d2d4b4ca6c", 0m, "MONDAY SPECIAL", 1 },
                    { "aee0ec01-21b9-4188-bf2f-c030bdd04e37", 0m, "ASEDA", 13 },
                    { "d05bec01-26cb-457e-9afe-53869831ef4c", 0m, "OLD SOLDIER", 12 },
                    { "d685e889-5edd-469d-9237-4867d73f530f", 0m, "FORTUNE THURSDAY", 7 },
                    { "e1c30a60-dbb9-41a5-93dc-632b840a0bfd", 0m, "VAG EAST", 4 },
                    { "e4c9cb37-eb9a-48c1-96f5-3aa22c07d364", 0m, "FRIDAY BONANZA", 9 },
                    { "e89ee947-72d5-4f89-8775-01693e37f61e", 0m, "OBIRI", 10 },
                    { "eeecca82-b14b-48c5-9588-6caa0c54fbee", 0m, "SUNDAY SPECIAL", 14 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "5bd46ef4-3843-4121-940f-93a276001172");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "6058748d-6eca-4370-b241-44f01b20ea54");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "69808a35-1a81-47fb-a77a-259998dbcddd");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "6a1ae0ce-6670-4fed-9753-d7b26e4def41");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "6e37e316-9a89-4d2d-990e-04fd44cf4455");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "7e2151eb-85e9-4ee5-ba8a-6a46b4498496");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "980f1b79-5d1c-437a-98b1-a3d2d4b4ca6c");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "aee0ec01-21b9-4188-bf2f-c030bdd04e37");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "d05bec01-26cb-457e-9afe-53869831ef4c");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "d685e889-5edd-469d-9237-4867d73f530f");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "e1c30a60-dbb9-41a5-93dc-632b840a0bfd");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "e4c9cb37-eb9a-48c1-96f5-3aa22c07d364");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "e89ee947-72d5-4f89-8775-01693e37f61e");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "eeecca82-b14b-48c5-9588-6caa0c54fbee");

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
    }
}
