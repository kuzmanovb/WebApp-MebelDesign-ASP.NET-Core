using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class EditProjectsAndImageToProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ImageToProjects_ImageId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ImageId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "ImageToProjects");

            migrationBuilder.AddColumn<int>(
                name: "HeadImageId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ImageToProjects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ImageToProjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ImageToProjects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ImageToProjects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ImageToProjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ImageToProjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ImageToProjects_IsDeleted",
                table: "ImageToProjects",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageToProjects_Projects_ProjectId",
                table: "ImageToProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageToProjects_Projects_ProjectId",
                table: "ImageToProjects");

            migrationBuilder.DropIndex(
                name: "IX_ImageToProjects_IsDeleted",
                table: "ImageToProjects");

            migrationBuilder.DropIndex(
                name: "IX_ImageToProjects_ProjectId",
                table: "ImageToProjects");

            migrationBuilder.DropColumn(
                name: "HeadImageId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ImageToProjects");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ImageToProjects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ImageToProjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ImageToProjects");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ImageToProjects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ImageToProjects");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "ImageToProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ImageId",
                table: "Projects",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ImageToProjects_ImageId",
                table: "Projects",
                column: "ImageId",
                principalTable: "ImageToProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
