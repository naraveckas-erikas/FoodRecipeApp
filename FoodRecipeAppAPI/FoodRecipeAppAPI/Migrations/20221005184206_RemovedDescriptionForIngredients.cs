using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodRecipeAppAPI.Migrations
{
    public partial class RemovedDescriptionForIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ingredients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
