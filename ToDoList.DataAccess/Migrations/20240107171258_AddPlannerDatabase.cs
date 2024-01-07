using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPlannerDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "planner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoodOption = table.Column<bool>(type: "bit", nullable: false),
                    ProductiveOption = table.Column<bool>(type: "bit", nullable: false),
                    SelfCareOption = table.Column<bool>(type: "bit", nullable: false),
                    ToDoOption = table.Column<bool>(type: "bit", nullable: false),
                    NotesOption = table.Column<bool>(type: "bit", nullable: false),
                    QuotesOption = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planner", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "planner");
        }
    }
}
