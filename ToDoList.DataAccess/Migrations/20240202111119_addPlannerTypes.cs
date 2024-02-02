using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addPlannerTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "planner");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "planner",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "planner");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "planner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
