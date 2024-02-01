using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeColumnAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingList_AspNetUsers_ApplicationUserId",
                table: "shoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_toDoListItems_AspNetUsers_UserId",
                table: "toDoListItems");

            migrationBuilder.DropIndex(
                name: "IX_toDoListItems_UserId",
                table: "toDoListItems");

            migrationBuilder.DropIndex(
                name: "IX_shoppingList_ApplicationUserId",
                table: "shoppingList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "toDoListItems");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "shoppingList");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surrname",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "toDoListItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "shoppingList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surrname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_toDoListItems_UserId",
                table: "toDoListItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingList_ApplicationUserId",
                table: "shoppingList",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingList_AspNetUsers_ApplicationUserId",
                table: "shoppingList",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_toDoListItems_AspNetUsers_UserId",
                table: "toDoListItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
