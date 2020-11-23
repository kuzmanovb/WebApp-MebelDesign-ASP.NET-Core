using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class RenameEntityToService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_FileOnFileSystems_DownloadDocumentId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_DownloadDocumentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DownloadDocumentId",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Services",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_DocumentId",
                table: "Services",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FileOnFileSystems_DocumentId",
                table: "Services",
                column: "DocumentId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_FileOnFileSystems_DocumentId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_DocumentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "DownloadDocumentId",
                table: "Services",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_DownloadDocumentId",
                table: "Services",
                column: "DownloadDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FileOnFileSystems_DownloadDocumentId",
                table: "Services",
                column: "DownloadDocumentId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
