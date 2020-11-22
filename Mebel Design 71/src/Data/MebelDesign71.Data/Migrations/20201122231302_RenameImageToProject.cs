using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class RenameImageToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDocument_FileOnFileSystems_DocumentId",
                table: "UserDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocument_Orders_OrderId",
                table: "UserDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocument_AspNetUsers_UserId",
                table: "UserDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDocument",
                table: "UserDocument");

            migrationBuilder.RenameTable(
                name: "UserDocument",
                newName: "UserDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocument_UserId",
                table: "UserDocuments",
                newName: "IX_UserDocuments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocument_OrderId",
                table: "UserDocuments",
                newName: "IX_UserDocuments_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocument_IsDeleted",
                table: "UserDocuments",
                newName: "IX_UserDocuments_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocument_DocumentId",
                table: "UserDocuments",
                newName: "IX_UserDocuments_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDocuments",
                table: "UserDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocuments_FileOnFileSystems_DocumentId",
                table: "UserDocuments",
                column: "DocumentId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocuments_Orders_OrderId",
                table: "UserDocuments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocuments_AspNetUsers_UserId",
                table: "UserDocuments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDocuments_FileOnFileSystems_DocumentId",
                table: "UserDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocuments_Orders_OrderId",
                table: "UserDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocuments_AspNetUsers_UserId",
                table: "UserDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDocuments",
                table: "UserDocuments");

            migrationBuilder.RenameTable(
                name: "UserDocuments",
                newName: "UserDocument");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocuments_UserId",
                table: "UserDocument",
                newName: "IX_UserDocument_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocuments_OrderId",
                table: "UserDocument",
                newName: "IX_UserDocument_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocuments_IsDeleted",
                table: "UserDocument",
                newName: "IX_UserDocument_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocuments_DocumentId",
                table: "UserDocument",
                newName: "IX_UserDocument_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDocument",
                table: "UserDocument",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocument_FileOnFileSystems_DocumentId",
                table: "UserDocument",
                column: "DocumentId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocument_Orders_OrderId",
                table: "UserDocument",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocument_AspNetUsers_UserId",
                table: "UserDocument",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
