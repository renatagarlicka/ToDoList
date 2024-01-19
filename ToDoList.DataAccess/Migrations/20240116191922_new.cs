using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingList_AspNetUsers_UserId",
                table: "shoppingList");

            migrationBuilder.DropIndex(
                name: "IX_shoppingList_UserId",
                table: "shoppingList");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "shoppingList",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "shoppingList",
                type: "nvarchar(450)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingList_AspNetUsers_ApplicationUserId",
                table: "shoppingList");

            migrationBuilder.DropIndex(
                name: "IX_shoppingList_ApplicationUserId",
                table: "shoppingList");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "shoppingList");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "shoppingList",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingList_UserId",
                table: "shoppingList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingList_AspNetUsers_UserId",
                table: "shoppingList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
