using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoIt.Api.Migrations
{
    public partial class Add_State_Todo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                schema: "dbo",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                schema: "dbo",
                table: "Goals");
        }
    }
}
