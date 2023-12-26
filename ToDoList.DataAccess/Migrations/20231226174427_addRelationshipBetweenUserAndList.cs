using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addRelationshipBetweenUserAndList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "toDoListItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_toDoListItems_UserId",
                table: "toDoListItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_toDoListItems_AspNetUsers_UserId",
                table: "toDoListItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDoListItems_AspNetUsers_UserId",
                table: "toDoListItems");

            migrationBuilder.DropIndex(
                name: "IX_toDoListItems_UserId",
                table: "toDoListItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "toDoListItems");
        }
    }
}
