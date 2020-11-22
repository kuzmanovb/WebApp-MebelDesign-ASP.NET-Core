using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class UpdateServiceAndOrderAndAddUserDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FileOnFileSystems_FileId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FileId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "DownloadDocumentId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadDocumentId",
                table: "Services",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserDocument",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UsrId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DocumentId = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocument_FileOnFileSystems_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "FileOnFileSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDocument_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDocument_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_DownloadDocumentId",
                table: "Services",
                column: "DownloadDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UploadDocumentId",
                table: "Services",
                column: "UploadDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_DocumentId",
                table: "UserDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_IsDeleted",
                table: "UserDocument",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_OrderId",
                table: "UserDocument",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_UserId",
                table: "UserDocument",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FileOnFileSystems_DownloadDocumentId",
                table: "Services",
                column: "DownloadDocumentId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FileOnFileSystems_UploadDocumentId",
                table: "Services",
                column: "UploadDocumentId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_FileOnFileSystems_DownloadDocumentId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_FileOnFileSystems_UploadDocumentId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "UserDocument");

            migrationBuilder.DropIndex(
                name: "IX_Services_DownloadDocumentId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UploadDocumentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DownloadDocumentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UploadDocumentId",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FileId",
                table: "Orders",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FileOnFileSystems_FileId",
                table: "Orders",
                column: "FileId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
