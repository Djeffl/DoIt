using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoIt.Api.Migrations
{
    public partial class PatchCategoryTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdeaCategory_Categories_CategoriesId",
                schema: "dbo",
                table: "IdeaCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_IdeaCategory_Ideas_IdeasId",
                schema: "dbo",
                table: "IdeaCategory");

            migrationBuilder.RenameColumn(
                name: "IdeasId",
                schema: "dbo",
                table: "IdeaCategory",
                newName: "IdeaId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                schema: "dbo",
                table: "IdeaCategory",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_IdeaCategory_IdeasId",
                schema: "dbo",
                table: "IdeaCategory",
                newName: "IX_IdeaCategory_IdeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdeaCategory_Categories_CategoryId",
                schema: "dbo",
                table: "IdeaCategory",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdeaCategory_Ideas_IdeaId",
                schema: "dbo",
                table: "IdeaCategory",
                column: "IdeaId",
                principalSchema: "dbo",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdeaCategory_Categories_CategoryId",
                schema: "dbo",
                table: "IdeaCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_IdeaCategory_Ideas_IdeaId",
                schema: "dbo",
                table: "IdeaCategory");

            migrationBuilder.RenameColumn(
                name: "IdeaId",
                schema: "dbo",
                table: "IdeaCategory",
                newName: "IdeasId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "IdeaCategory",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_IdeaCategory_IdeaId",
                schema: "dbo",
                table: "IdeaCategory",
                newName: "IX_IdeaCategory_IdeasId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdeaCategory_Categories_CategoriesId",
                schema: "dbo",
                table: "IdeaCategory",
                column: "CategoriesId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdeaCategory_Ideas_IdeasId",
                schema: "dbo",
                table: "IdeaCategory",
                column: "IdeasId",
                principalSchema: "dbo",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
