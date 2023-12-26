﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFKtoShoopingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "shoppingList",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingList_AspNetUsers_UserId",
                table: "shoppingList");

            migrationBuilder.DropIndex(
                name: "IX_shoppingList_UserId",
                table: "shoppingList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "shoppingList");
        }
    }
}
