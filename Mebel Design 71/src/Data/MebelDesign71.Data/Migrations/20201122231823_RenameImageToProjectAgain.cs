using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class RenameImageToProjectAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageToProjects_FileOnFileSystems_FileId",
                table: "ImageToProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageToProjects_Projects_ProjectId",
                table: "ImageToProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageToProjects",
                table: "ImageToProjects");

            migrationBuilder.RenameTable(
                name: "ImageToProjects",
                newName: "GalleryProjects");

            migrationBuilder.RenameIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "GalleryProjects",
                newName: "IX_GalleryProjects_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageToProjects_FileId",
                table: "GalleryProjects",
                newName: "IX_GalleryProjects_FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GalleryProjects",
                table: "GalleryProjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryProjects_FileOnFileSystems_FileId",
                table: "GalleryProjects",
                column: "FileId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryProjects_Projects_ProjectId",
                table: "GalleryProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryProjects_FileOnFileSystems_FileId",
                table: "GalleryProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_GalleryProjects_Projects_ProjectId",
                table: "GalleryProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GalleryProjects",
                table: "GalleryProjects");

            migrationBuilder.RenameTable(
                name: "GalleryProjects",
                newName: "ImageToProjects");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryProjects_ProjectId",
                table: "ImageToProjects",
                newName: "IX_ImageToProjects_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryProjects_FileId",
                table: "ImageToProjects",
                newName: "IX_ImageToProjects_FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageToProjects",
                table: "ImageToProjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageToProjects_FileOnFileSystems_FileId",
                table: "ImageToProjects",
                column: "FileId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageToProjects_Projects_ProjectId",
                table: "ImageToProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
