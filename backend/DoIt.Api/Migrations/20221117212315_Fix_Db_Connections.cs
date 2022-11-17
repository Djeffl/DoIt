using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoIt.Api.Migrations
{
    public partial class Fix_Db_Connections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaCategory",
                schema: "dbo");

            migrationBuilder.AddColumn<long>(
                name: "IdeaId",
                schema: "dbo",
                table: "Goals",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryGoal",
                schema: "dbo",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    GoalsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGoal", x => new { x.CategoriesId, x.GoalsId });
                    table.ForeignKey(
                        name: "FK_CategoryGoal_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryGoal_Goals_GoalsId",
                        column: x => x.GoalsId,
                        principalSchema: "dbo",
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryIdea",
                schema: "dbo",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    IdeasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryIdea", x => new { x.CategoriesId, x.IdeasId });
                    table.ForeignKey(
                        name: "FK_CategoryIdea_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryIdea_Ideas_IdeasId",
                        column: x => x.IdeasId,
                        principalSchema: "dbo",
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_IdeaId",
                schema: "dbo",
                table: "Goals",
                column: "IdeaId",
                unique: true,
                filter: "[IdeaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGoal_GoalsId",
                schema: "dbo",
                table: "CategoryGoal",
                column: "GoalsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryIdea_IdeasId",
                schema: "dbo",
                table: "CategoryIdea",
                column: "IdeasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Ideas_IdeaId",
                schema: "dbo",
                table: "Goals",
                column: "IdeaId",
                principalSchema: "dbo",
                principalTable: "Ideas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Ideas_IdeaId",
                schema: "dbo",
                table: "Goals");

            migrationBuilder.DropTable(
                name: "CategoryGoal",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CategoryIdea",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Goals_IdeaId",
                schema: "dbo",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "IdeaId",
                schema: "dbo",
                table: "Goals");

            migrationBuilder.CreateTable(
                name: "IdeaCategory",
                schema: "dbo",
                columns: table => new
                {
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    IdeaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaCategory", x => new { x.CategoryId, x.IdeaId });
                    table.ForeignKey(
                        name: "FK_IdeaCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaCategory_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalSchema: "dbo",
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdeaCategory_IdeaId",
                schema: "dbo",
                table: "IdeaCategory",
                column: "IdeaId");
        }
    }
}
