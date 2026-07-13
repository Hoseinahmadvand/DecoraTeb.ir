using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecoraTeb.Migrations
{
    /// <inheritdoc />
    public partial class projectRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImsges_ProjectId",
                table: "ProjectImsges",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImsges_Projects_ProjectId",
                table: "ProjectImsges",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId",
                principalTable: "ProjectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImsges_Projects_ProjectId",
                table: "ProjectImsges");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectImsges_ProjectId",
                table: "ProjectImsges");
        }
    }
}
