using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class ChangeProjectEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects");

            migrationBuilder.AlterColumn<string>(
                name: "HeadImageId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects",
                column: "ProjectId",
                unique: true);
        }
    }
}
