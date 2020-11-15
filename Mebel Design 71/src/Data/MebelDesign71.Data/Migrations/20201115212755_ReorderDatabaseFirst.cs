using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class ReorderDatabaseFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_ImageToProjects_ImageId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ImageToProjects_ImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Offers_ImageId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Services",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "HeadImageId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Offers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_DocumentId",
                table: "Offers",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_FileOnFileSystems_DocumentId",
                table: "Offers",
                column: "DocumentId",
                principalTable: "FileOnFileSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_FileOnFileSystems_DocumentId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_DocumentId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceType",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HeadImageId",
                table: "Projects",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId",
                table: "Services",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ImageId",
                table: "Offers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_ImageToProjects_ImageId",
                table: "Offers",
                column: "ImageId",
                principalTable: "ImageToProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ImageToProjects_ImageId",
                table: "Services",
                column: "ImageId",
                principalTable: "ImageToProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
