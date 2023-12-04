using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class AgentId_Epen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "AgentId",
                table: "Expenses");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
