using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoIt.Api.Migrations
{
    public partial class AddIdeaCategory_IdeaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                schema: "dbo",
                table: "Ideas",
                type: "bigint",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Idea-Categories_CategoryId",
                schema: "dbo",
                table: "Ideas");

            migrationBuilder.DropTable(
                name: "Idea-Categories",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_CategoryId",
                schema: "dbo",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Ideas");
        }
    }
}
