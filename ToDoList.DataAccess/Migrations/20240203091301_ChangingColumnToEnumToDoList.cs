using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangingColumnToEnumToDoList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "shoppingList");

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "toDoListItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "shoppingList",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "toDoListItems");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "shoppingList",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "UserId",
            //    table: "shoppingList",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}
