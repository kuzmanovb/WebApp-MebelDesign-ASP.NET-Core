using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class ChangeImageToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_FileOnFileSystems_HeadImageId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_HeadImageId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects");

            migrationBuilder.AlterColumn<string>(
                name: "HeadImageId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects");

            migrationBuilder.AlterColumn<string>(
                name: "HeadImageId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_HeadImageId",
                table: "Projects",
                column: "HeadImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_FileOnFileSystems_HeadImageId",
                table: "Projects",
                column: "HeadImageId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
