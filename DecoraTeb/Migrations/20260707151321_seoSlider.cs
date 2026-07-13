using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecoraTeb.Migrations
{
    /// <inheritdoc />
    public partial class seoSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CanonicalUrl",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Robots",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeoKeywords",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanonicalUrl",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Robots",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SeoKeywords",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Sliders");
        }
    }
}
