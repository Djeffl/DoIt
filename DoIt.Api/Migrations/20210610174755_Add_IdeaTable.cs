using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoIt.Api.Migrations
{
    public partial class Add_IdeaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Todo",
                newName: "Todo",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "Goals",
                newSchema: "dbo");

            migrationBuilder.CreateTable(
                name: "Ideas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ideas",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "Todo",
                schema: "dbo",
                newName: "Todo");

            migrationBuilder.RenameTable(
                name: "Goals",
                schema: "dbo",
                newName: "Goals");
        }
    }
}
