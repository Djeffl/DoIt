using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoIt.Api.Migrations
{
    public partial class Update_Todo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                schema: "dbo",
                table: "Todo");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                schema: "dbo",
                table: "Todo",
                newName: "PlannedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlannedAt",
                schema: "dbo",
                table: "Todo",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                schema: "dbo",
                table: "Todo",
                type: "datetime2",
                nullable: true);
        }
    }
}
