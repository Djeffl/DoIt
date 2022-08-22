using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoIt.Api.Migrations
{
    public partial class PatchCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaIdeaCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Idea-Categories",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdeaCategory",
                schema: "dbo",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    IdeasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaCategory", x => new { x.CategoriesId, x.IdeasId });
                    table.ForeignKey(
                        name: "FK_IdeaCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaCategory_Ideas_IdeasId",
                        column: x => x.IdeasId,
                        principalSchema: "dbo",
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdeaCategory_IdeasId",
                schema: "dbo",
                table: "IdeaCategory",
                column: "IdeasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Idea-Categories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idea-Categories", x => x.Id);
                });

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
    }
}
