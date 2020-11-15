using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class EditProjectForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects");

            migrationBuilder.CreateIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects");

            migrationBuilder.CreateIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects",
                column: "ProjectId",
                unique: true);
        }
    }
}
