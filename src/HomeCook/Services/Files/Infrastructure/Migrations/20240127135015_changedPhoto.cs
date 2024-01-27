using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("13d9b14d-b06f-4a50-90c5-71435bdbe75e"),
                column: "Path",
                value: "food-photo8.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c8dc7ca-2392-42c0-a525-fdaa992f8baa"),
                column: "Path",
                value: "food-photo10.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4768-abcd-1234567890ab"),
                column: "Path",
                value: "food-photo1.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9da-ebfc-ae0f-abcd-1234567890f2"),
                column: "Path",
                value: "food-photo7.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-5899-abcd-1234567890bc"),
                column: "Path",
                value: "food-photo2.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f"),
                column: "Path",
                value: "food-photo9.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd"),
                column: "Path",
                value: "food-photo3.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-7bac-abcd-1234567890de"),
                column: "Path",
                value: "food-photo4.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9da-8cbd-abcd-1234567890ef"),
                column: "Path",
                value: "food-photo5.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-daeb-9dce-abcd-1234567890f1"),
                column: "Path",
                value: "food-photo6.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("13d9b14d-b06f-4a50-90c5-71435bdbe75e"),
                column: "Path",
                value: "photo8.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c8dc7ca-2392-42c0-a525-fdaa992f8baa"),
                column: "Path",
                value: "photo10.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4768-abcd-1234567890ab"),
                column: "Path",
                value: "photo1.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9da-ebfc-ae0f-abcd-1234567890f2"),
                column: "Path",
                value: "photo7.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-5899-abcd-1234567890bc"),
                column: "Path",
                value: "photo2.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f"),
                column: "Path",
                value: "photo9.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd"),
                column: "Path",
                value: "photo3.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-7bac-abcd-1234567890de"),
                column: "Path",
                value: "photo4.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9da-8cbd-abcd-1234567890ef"),
                column: "Path",
                value: "photo5.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-daeb-9dce-abcd-1234567890f1"),
                column: "Path",
                value: "photo6.jpg");
        }
    }
}
