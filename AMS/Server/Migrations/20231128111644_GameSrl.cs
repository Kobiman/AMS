using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Server.Migrations
{
    public partial class GameSrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Srl",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Srl",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
