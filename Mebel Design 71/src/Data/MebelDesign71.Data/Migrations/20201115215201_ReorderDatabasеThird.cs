using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class ReorderDatabasеThird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "HeadImageId",
                table: "Services",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Services_HeadImageId",
                table: "Services",
                column: "HeadImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FileOnFileSystems_HeadImageId",
                table: "Services",
                column: "HeadImageId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_FileOnFileSystems_HeadImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_HeadImageId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "HeadImageId",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
