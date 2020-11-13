using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class AddFileoNFileSystemDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileOnFileSystem_AspNetUsers_UserId",
                table: "FileOnFileSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageToProjects_FileOnFileSystem_FileId",
                table: "ImageToProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageToReviews_FileOnFileSystem_FileId",
                table: "ImageToReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FileOnFileSystem_FileId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileOnFileSystem",
                table: "FileOnFileSystem");

            migrationBuilder.RenameTable(
                name: "FileOnFileSystem",
                newName: "FileOnFileSystems");

            migrationBuilder.RenameIndex(
                name: "IX_FileOnFileSystem_UserId",
                table: "FileOnFileSystems",
                newName: "IX_FileOnFileSystems_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileOnFileSystems",
                table: "FileOnFileSystems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileOnFileSystems_AspNetUsers_UserId",
                table: "FileOnFileSystems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageToProjects_FileOnFileSystems_FileId",
                table: "ImageToProjects",
                column: "FileId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageToReviews_FileOnFileSystems_FileId",
                table: "ImageToReviews",
                column: "FileId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FileOnFileSystems_FileId",
                table: "Orders",
                column: "FileId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileOnFileSystems_AspNetUsers_UserId",
                table: "FileOnFileSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageToProjects_FileOnFileSystems_FileId",
                table: "ImageToProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageToReviews_FileOnFileSystems_FileId",
                table: "ImageToReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FileOnFileSystems_FileId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileOnFileSystems",
                table: "FileOnFileSystems");

            migrationBuilder.RenameTable(
                name: "FileOnFileSystems",
                newName: "FileOnFileSystem");

            migrationBuilder.RenameIndex(
                name: "IX_FileOnFileSystems_UserId",
                table: "FileOnFileSystem",
                newName: "IX_FileOnFileSystem_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileOnFileSystem",
                table: "FileOnFileSystem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileOnFileSystem_AspNetUsers_UserId",
                table: "FileOnFileSystem",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageToProjects_FileOnFileSystem_FileId",
                table: "ImageToProjects",
                column: "FileId",
                principalTable: "FileOnFileSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageToReviews_FileOnFileSystem_FileId",
                table: "ImageToReviews",
                column: "FileId",
                principalTable: "FileOnFileSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FileOnFileSystem_FileId",
                table: "Orders",
                column: "FileId",
                principalTable: "FileOnFileSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
