using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class _34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "0410ebc1-fcb7-4f26-8485-24f9b77cb4f0");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "21472e68-1794-4891-9093-5a71abd43704");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "23836ba8-11cb-4539-85b3-134d5a3ef21a");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4e014f10-5644-4002-a694-ce063b569fce");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "79b10969-6fb3-4adc-a454-9bc6b89b6780");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "86316f68-6f59-4a30-bb9e-5c4128e9a093");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "b6010ebc-5f4f-43ed-9590-ea1d1c1e1d33");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "d0dd7c73-3ee9-45ac-8b40-41013ba99e1d");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "d8687acb-8280-4c90-9e70-d2fddf6908c6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "d9d8631e-7744-4ec5-81ee-86126623109c");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "ddcfeb79-76f1-4b10-a8c2-127b5e67c24e");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "f81fa797-fbdd-43cb-b549-c5174197559e");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "f8a49624-d2c8-49e8-be6c-f5fdbcc91fdc");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "f910f66c-fa9c-42e3-84de-b125a5cb4b22");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Commission", "Name", "Srl" },
                values: new object[,]
                {
                    { "0410ebc1-fcb7-4f26-8485-24f9b77cb4f0", 0m, "OBIRI", 10 },
                    { "21472e68-1794-4891-9093-5a71abd43704", 0m, "PIONEER", 2 },
                    { "23836ba8-11cb-4539-85b3-134d5a3ef21a", 0m, "AFRICA", 8 },
                    { "4e014f10-5644-4002-a694-ce063b569fce", 0m, "OLD SOLDIER", 12 },
                    { "79b10969-6fb3-4adc-a454-9bc6b89b6780", 0m, "FRIDAY BONANZA", 9 },
                    { "86316f68-6f59-4a30-bb9e-5c4128e9a093", 0m, "VAG EAST", 4 },
                    { "b6010ebc-5f4f-43ed-9590-ea1d1c1e1d33", 0m, "SUNDAY SPECIAL", 14 },
                    { "d0dd7c73-3ee9-45ac-8b40-41013ba99e1d", 0m, "FORTUNE THURSDAY", 7 },
                    { "d8687acb-8280-4c90-9e70-d2fddf6908c6", 0m, "ASEDA", 13 },
                    { "d9d8631e-7744-4ec5-81ee-86126623109c", 0m, "MID-WEEK", 5 },
                    { "ddcfeb79-76f1-4b10-a8c2-127b5e67c24e", 0m, "LUCKY TUESDAY", 3 },
                    { "f81fa797-fbdd-43cb-b549-c5174197559e", 0m, "VAG WEST", 6 },
                    { "f8a49624-d2c8-49e8-be6c-f5fdbcc91fdc", 0m, "MONDAY SPECIAL", 1 },
                    { "f910f66c-fa9c-42e3-84de-b125a5cb4b22", 0m, "NATIONAL", 11 }
                });
        }
    }
}
