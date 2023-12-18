using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changestoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingDescription",
                table: "shoppingList",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "NameShopping",
                table: "shoppingList",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "shoppingList",
                newName: "NameShopping");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "shoppingList",
                newName: "ShoppingDescription");
        }
    }
}
