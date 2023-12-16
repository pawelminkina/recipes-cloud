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
                table: "Recipes",
                columns: new[] { "Id", "AuthorEmail", "Content", "MainPhotoId", "Title" },
                values: new object[,]
                {
                    { new Guid("3aa73c46-3907-4be8-a837-e4617a9d3138"), "author2@example.com", "Content 4", new Guid("a7b8c9da-ebfc-ae0f-abcd-1234567890f2"), "Recipe 4" },
                    { new Guid("50616e81-d7bc-452c-a37c-9dd03490c94d"), "author5@example.com", "Content 9", new Guid("e5f6a7b8-c9da-8cbd-abcd-1234567890ef"), "Recipe 9" },
                    { new Guid("686be816-80f2-4298-8abe-80679f366b48"), "author3@example.com", "Content 6", new Guid("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f"), "Recipe 6" },
                    { new Guid("6fbaeba0-85ad-4f6a-b84d-cf13f2df3e46"), "author5@example.com", "Content 10", new Guid("f6a7b8c9-daeb-9dce-abcd-1234567890f1"), "Recipe 10" },
                    { new Guid("75e94b5e-0ab0-424b-8ac3-47e6b8c58632"), "author4@example.com", "Content 8", new Guid("d4e5f6a7-b8c9-7bac-abcd-1234567890de"), "Recipe 8" },
                    { new Guid("9ab3d8d3-fb07-4c70-9c9a-3aaa7697c139"), "author3@example.com", "Content 5", new Guid("b2c3d4e5-f6a7-5899-abcd-1234567890bc"), "Recipe 5" },
                    { new Guid("b6eb4feb-41d2-40ea-95d3-2b5b2d03a379"), "author1@example.com", "Content 1", new Guid("13d9b14d-b06f-4a50-90c5-71435bdbe75e"), "Recipe 1" },
                    { new Guid("bf1252a3-d6a7-4355-bb1d-cf04307cb274"), "author1@example.com", "Content 2", new Guid("2c8dc7ca-2392-42c0-a525-fdaa992f8baa"), "Recipe 2" },
                    { new Guid("d518e1a1-d0e3-459e-8f75-2e77a2055446"), "author2@example.com", "Content 3", new Guid("a1b2c3d4-e5f6-4768-abcd-1234567890ab"), "Recipe 3" },
                    { new Guid("f589a9b6-3470-4f4d-8c2e-ea3e1f2b40fc"), "author4@example.com", "Content 7", new Guid("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd"), "Recipe 7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3aa73c46-3907-4be8-a837-e4617a9d3138"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("50616e81-d7bc-452c-a37c-9dd03490c94d"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("686be816-80f2-4298-8abe-80679f366b48"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("6fbaeba0-85ad-4f6a-b84d-cf13f2df3e46"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("75e94b5e-0ab0-424b-8ac3-47e6b8c58632"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("9ab3d8d3-fb07-4c70-9c9a-3aaa7697c139"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b6eb4feb-41d2-40ea-95d3-2b5b2d03a379"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("bf1252a3-d6a7-4355-bb1d-cf04307cb274"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("d518e1a1-d0e3-459e-8f75-2e77a2055446"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f589a9b6-3470-4f4d-8c2e-ea3e1f2b40fc"));
        }
    }
}
