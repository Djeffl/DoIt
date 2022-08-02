using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoIt.Api.Migrations
{
    public partial class UpdateGoalModal_GoalTableAndTodoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueAt",
                schema: "dbo",
                table: "Todo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueAt",
                schema: "dbo",
                table: "Goals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueAt",
                schema: "dbo",
                table: "Todo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueAt",
                schema: "dbo",
                table: "Goals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
