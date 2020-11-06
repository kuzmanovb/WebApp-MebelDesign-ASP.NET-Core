using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class ModifyingSomeoneEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_FileOnFileSystem_ImagePathId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FileOnFileSystem_DocumentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Services_ServiceId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Images_ImageId1",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ImageId1",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DocumentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ServiceId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Images_ImagePathId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageId1",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ServiceId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ImagePathId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Services",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "Images",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId",
                table: "Services",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FileId",
                table: "Orders",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_FileId",
                table: "Images",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_FileOnFileSystem_FileId",
                table: "Images",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Images_ImageId",
                table: "Services",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_FileOnFileSystem_FileId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FileOnFileSystem_FileId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Images_ImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FileId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Images_FileId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ImageId1",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePathId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId1",
                table: "Services",
                column: "ImageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DocumentId",
                table: "Orders",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId1",
                table: "Orders",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImagePathId",
                table: "Images",
                column: "ImagePathId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_FileOnFileSystem_ImagePathId",
                table: "Images",
                column: "ImagePathId",
                principalTable: "FileOnFileSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FileOnFileSystem_DocumentId",
                table: "Orders",
                column: "DocumentId",
                principalTable: "FileOnFileSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Services_ServiceId1",
                table: "Orders",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Images_ImageId1",
                table: "Services",
                column: "ImageId1",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
