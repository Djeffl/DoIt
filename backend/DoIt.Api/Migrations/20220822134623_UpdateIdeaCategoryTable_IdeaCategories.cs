using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoIt.Api.Migrations
{
    public partial class UpdateIdeaCategoryTable_IdeaCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Idea-Categories_CategoryId",
                schema: "dbo",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_CategoryId",
                schema: "dbo",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Ideas");

            migrationBuilder.CreateTable(
                name: "IdeaIdeaCategory",
                schema: "dbo",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    IdeasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaIdeaCategory", x => new { x.CategoriesId, x.IdeasId });
                    table.ForeignKey(
                        name: "FK_IdeaIdeaCategory_Idea-Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "dbo",
                        principalTable: "Idea-Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaIdeaCategory_Ideas_IdeasId",
                        column: x => x.IdeasId,
                        principalSchema: "dbo",
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdeaIdeaCategory_IdeasId",
                schema: "dbo",
                table: "IdeaIdeaCategory",
                column: "IdeasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaIdeaCategory",
                schema: "dbo");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                schema: "dbo",
                table: "Ideas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_CategoryId",
                schema: "dbo",
                table: "Ideas",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Idea-Categories_CategoryId",
                schema: "dbo",
                table: "Ideas",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Idea-Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
