using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class receivedby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ReceivedBy",
                table: "Payouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceivedFrom",
                table: "Payouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverPhone",
                table: "Payouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Commission", "Name", "Srl" },
                values: new object[,]
                {
                    { "00e06461-ba34-4d7d-8dff-b99669871058", 0m, "NATIONAL", 11 },
                    { "241b4ea3-175f-457b-9c92-442009e05d39", 0m, "FRIDAY BONANZA", 9 },
                    { "2b4b4e98-559e-4dae-b423-586fb2279332", 0m, "SUNDAY SPECIAL", 14 },
                    { "322dc242-ca9b-4602-b7de-089fef146e46", 0m, "AFRICA", 8 },
                    { "452f01fc-e6a9-45c1-9b0a-31327cfa7105", 0m, "VAG WEST", 6 },
                    { "52cbc16e-254a-44ff-9837-bbae8632fc8c", 0m, "ASEDA", 13 },
                    { "586f58e9-ae80-4d4c-b132-10f3e4076820", 0m, "PIONEER", 2 },
                    { "5a317465-ec25-464d-a83d-3bad8d41b77c", 0m, "OLD SOLDIER", 12 },
                    { "7040606c-ca49-4625-bdf1-c208c9149696", 0m, "OBIRI", 10 },
                    { "7daffa34-3287-4022-893b-92ba4f02cdab", 0m, "MID-WEEK", 5 },
                    { "810529d6-20ec-4a0b-8061-2ef9e1690423", 0m, "LUCKY TUESDAY", 3 },
                    { "b0f07250-a284-4daa-8993-0108f09a9867", 0m, "FORTUNE THURSDAY", 7 },
                    { "bff33831-a59d-436d-9e85-05d3ef5b9dc6", 0m, "MONDAY SPECIAL", 1 },
                    { "cd61cfaa-f8fd-46a9-b28a-a3341b1692dc", 0m, "VAG EAST", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "00e06461-ba34-4d7d-8dff-b99669871058");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "241b4ea3-175f-457b-9c92-442009e05d39");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "2b4b4e98-559e-4dae-b423-586fb2279332");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "322dc242-ca9b-4602-b7de-089fef146e46");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "452f01fc-e6a9-45c1-9b0a-31327cfa7105");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "52cbc16e-254a-44ff-9837-bbae8632fc8c");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "586f58e9-ae80-4d4c-b132-10f3e4076820");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "5a317465-ec25-464d-a83d-3bad8d41b77c");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "7040606c-ca49-4625-bdf1-c208c9149696");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "7daffa34-3287-4022-893b-92ba4f02cdab");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "810529d6-20ec-4a0b-8061-2ef9e1690423");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "b0f07250-a284-4daa-8993-0108f09a9867");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "bff33831-a59d-436d-9e85-05d3ef5b9dc6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "cd61cfaa-f8fd-46a9-b28a-a3341b1692dc");

            migrationBuilder.DropColumn(
                name: "ReceivedBy",
                table: "Payouts");

            migrationBuilder.DropColumn(
                name: "ReceivedFrom",
                table: "Payouts");

            migrationBuilder.DropColumn(
                name: "ReceiverPhone",
                table: "Payouts");

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
    }
}
