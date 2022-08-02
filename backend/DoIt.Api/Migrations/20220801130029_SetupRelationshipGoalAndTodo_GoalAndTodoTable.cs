using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoIt.Api.Migrations
{
    public partial class SetupRelationshipGoalAndTodo_GoalAndTodoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Goals_GoalId",
                schema: "dbo",
                table: "Todo");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Goals_GoalId",
                schema: "dbo",
                table: "Todo",
                column: "GoalId",
                principalSchema: "dbo",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Goals_GoalId",
                schema: "dbo",
                table: "Todo");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Goals_GoalId",
                schema: "dbo",
                table: "Todo",
                column: "GoalId",
                principalSchema: "dbo",
                principalTable: "Goals",
                principalColumn: "Id");
        }
    }
}
