﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodRecipeAppAPI.Migrations
{
    public partial class AddedNameToIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ingredients");
        }
    }
}
