using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class AgentGameCommission : Migration
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

            migrationBuilder.CreateTable(
                name: "AgentGameCommissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentGameCommissions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentGameCommissions");

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
