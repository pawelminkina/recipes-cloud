using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "Path" },
                values: new object[,]
                {
                    { new Guid("13d9b14d-b06f-4a50-90c5-71435bdbe75e"), "photo8.png" },
                    { new Guid("2c8dc7ca-2392-42c0-a525-fdaa992f8baa"), "photo10.png" },
                    { new Guid("a1b2c3d4-e5f6-4768-abcd-1234567890ab"), "photo1.png" },
                    { new Guid("a7b8c9da-ebfc-ae0f-abcd-1234567890f2"), "photo7.png" },
                    { new Guid("b2c3d4e5-f6a7-5899-abcd-1234567890bc"), "photo2.png" },
                    { new Guid("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f"), "photo9.png" },
                    { new Guid("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd"), "photo3.png" },
                    { new Guid("d4e5f6a7-b8c9-7bac-abcd-1234567890de"), "photo4.png" },
                    { new Guid("e5f6a7b8-c9da-8cbd-abcd-1234567890ef"), "photo5.png" },
                    { new Guid("f6a7b8c9-daeb-9dce-abcd-1234567890f1"), "photo6.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("13d9b14d-b06f-4a50-90c5-71435bdbe75e"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c8dc7ca-2392-42c0-a525-fdaa992f8baa"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4768-abcd-1234567890ab"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9da-ebfc-ae0f-abcd-1234567890f2"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-5899-abcd-1234567890bc"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-7bac-abcd-1234567890de"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9da-8cbd-abcd-1234567890ef"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-daeb-9dce-abcd-1234567890f1"));
        }
    }
}
