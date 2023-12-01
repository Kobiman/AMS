using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class sheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Sheet",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Commission", "Name", "Srl" },
                values: new object[,]
                {
                    { "06cb7224-8262-441b-ac86-1174130657fa", 0m, "VAG EAST", 4 },
                    { "254549ee-e1bd-42ed-993d-7fadee7d8dc1", 0m, "FRIDAY BONANZA", 9 },
                    { "4d255b61-8867-456c-b4ad-5e00f267e299", 0m, "VAG WEST", 6 },
                    { "53e551ef-ca3d-442b-bb7d-19b452f3d604", 0m, "PIONEER", 2 },
                    { "5fbf8d2e-0b2e-4173-aedb-88d877551e0a", 0m, "MONDAY SPECIAL", 1 },
                    { "874cbf44-543c-4434-85ad-243107fc6a11", 0m, "OLD SOLDIER", 12 },
                    { "9be05100-aac1-4780-95f7-b14ebd1537de", 0m, "OBIRI", 10 },
                    { "9f74bfd0-05ed-423e-af28-eeb325dbaeab", 0m, "AFRICA", 8 },
                    { "9fe49e6f-1dfa-437f-9444-62cec6be8288", 0m, "SUNDAY SPECIAL", 14 },
                    { "ae7c8555-6bc5-4332-9a89-6b372d23b9d2", 0m, "FORTUNE THURSDAY", 7 },
                    { "dbe0aec5-cea3-44aa-84b4-da76f4252ebb", 0m, "LUCKY TUESDAY", 3 },
                    { "dc00e042-4ce7-43f7-8321-865b8997c869", 0m, "ASEDA", 13 },
                    { "eb36222b-6253-4fc1-bcb4-c47bca6a42d0", 0m, "NATIONAL", 11 },
                    { "fe933a9e-c06f-44f9-96dc-618f3b09b060", 0m, "MID-WEEK", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "06cb7224-8262-441b-ac86-1174130657fa");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "254549ee-e1bd-42ed-993d-7fadee7d8dc1");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4d255b61-8867-456c-b4ad-5e00f267e299");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "53e551ef-ca3d-442b-bb7d-19b452f3d604");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "5fbf8d2e-0b2e-4173-aedb-88d877551e0a");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "874cbf44-543c-4434-85ad-243107fc6a11");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "9be05100-aac1-4780-95f7-b14ebd1537de");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "9f74bfd0-05ed-423e-af28-eeb325dbaeab");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "9fe49e6f-1dfa-437f-9444-62cec6be8288");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "ae7c8555-6bc5-4332-9a89-6b372d23b9d2");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "dbe0aec5-cea3-44aa-84b4-da76f4252ebb");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "dc00e042-4ce7-43f7-8321-865b8997c869");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "eb36222b-6253-4fc1-bcb4-c47bca6a42d0");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "fe933a9e-c06f-44f9-96dc-618f3b09b060");

            migrationBuilder.DropColumn(
                name: "Sheet",
                table: "Sales");

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
    }
}
