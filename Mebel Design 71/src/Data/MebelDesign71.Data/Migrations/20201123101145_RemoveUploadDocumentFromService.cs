using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class RemoveUploadDocumentFromService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_FileOnFileSystems_UploadDocumentId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UploadDocumentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UploadDocumentId",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UploadDocumentId",
                table: "Services",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_UploadDocumentId",
                table: "Services",
                column: "UploadDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FileOnFileSystems_UploadDocumentId",
                table: "Services",
                column: "UploadDocumentId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
