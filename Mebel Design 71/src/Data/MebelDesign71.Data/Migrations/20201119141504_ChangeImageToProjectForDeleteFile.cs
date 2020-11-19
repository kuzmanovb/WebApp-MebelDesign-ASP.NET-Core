using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class ChangeImageToProjectForDeleteFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageToProjects_IsDeleted",
                table: "ImageToProjects");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ImageToProjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ImageToProjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ImageToProjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ImageToProjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ImageToProjects_IsDeleted",
                table: "ImageToProjects",
                column: "IsDeleted");
        }
    }
}
