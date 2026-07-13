using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DecoraTeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedWebPages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WebPages",
                columns: new[] { "Id", "BannerImage", "ButtonLink", "ButtonText", "CanonicalUrl", "Content", "CreateAt", "DeletedAt", "Heading", "Image", "IsActive", "IsDeleted", "Robots", "SeoDescription", "SeoKeywords", "SeoTitle", "ShortDescription", "ShowInMenu", "Slug", "SortOrder", "Title", "Type", "UpdateAt" },
                values: new object[,]
                {
                    { 1L, "", "", "", "/aboutus", "<p>محتوای صفحه درباره ما...</p>", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", "", true, false, "aboutus", "آشنایی با مجموعه دکوراطب", "دکوراطب, طراحی داخلی مطب", "درباره دکوراطب", "آشنایی با مجموعه دکوراطب", false, "about", 1, "درباره ما", 2, null },
                    { 2L, "", "", "", "/contact", "<p>محتوای صفحه تماس با ما...</p>", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", "", true, false, "contact", "راه های ارتباط با دکوراطب", "تماس, دکوراطب", "تماس با دکوراطب", "راه های ارتباط با دکوراطب", false, "contact", 2, "تماس با ما", 3, null },
                    { 3L, "", "", "", "/privacy", "<p>متن حریم خصوصی...</p>", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", "", true, false, "privacy", "حریم خصوصی کاربران", "حریم خصوصی", "حریم خصوصی", "حفظ اطلاعات کاربران", false, "privacy", 4, "حریم خصوصی", 4, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WebPages",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "WebPages",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "WebPages",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
