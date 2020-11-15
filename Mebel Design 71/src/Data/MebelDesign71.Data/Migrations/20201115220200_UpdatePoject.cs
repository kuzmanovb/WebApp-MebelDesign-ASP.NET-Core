using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class UpdatePoject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeadImageId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_HeadImageId",
                table: "Projects",
                column: "HeadImageId");

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

            migrationBuilder.AlterColumn<string>(
                name: "HeadImageId",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
