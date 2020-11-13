using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDesign71.Data.Migrations
{
    public partial class RemoveImageAndAddEntityForImageReviewAndImageProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Images_ImageId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Images_ImageId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Images_ImageId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Images_ImageId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.CreateTable(
                name: "ImageToProjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(nullable: false),
                    FileId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageToProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageToProjects_FileOnFileSystem_FileId",
                        column: x => x.FileId,
                        principalTable: "FileOnFileSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageToReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageToReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageToReviews_FileOnFileSystem_FileId",
                        column: x => x.FileId,
                        principalTable: "FileOnFileSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageToProjects_FileId",
                table: "ImageToProjects",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageToReviews_FileId",
                table: "ImageToReviews",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_ImageToProjects_ImageId",
                table: "Offers",
                column: "ImageId",
                principalTable: "ImageToProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ImageToProjects_ImageId",
                table: "Projects",
                column: "ImageId",
                principalTable: "ImageToProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ImageToReviews_ImageId",
                table: "Reviews",
                column: "ImageId",
                principalTable: "ImageToReviews",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_ImageToProjects_ImageId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ImageToProjects_ImageId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ImageToReviews_ImageId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ImageToProjects_ImageId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ImageToProjects");

            migrationBuilder.DropTable(
                name: "ImageToReviews");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_FileOnFileSystem_FileId",
                        column: x => x.FileId,
                        principalTable: "FileOnFileSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_FileId",
                table: "Images",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Images_ImageId",
                table: "Offers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Images_ImageId",
                table: "Projects",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Images_ImageId",
                table: "Reviews",
                column: "ImageId",
                principalTable: "Images",
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
    }
}
