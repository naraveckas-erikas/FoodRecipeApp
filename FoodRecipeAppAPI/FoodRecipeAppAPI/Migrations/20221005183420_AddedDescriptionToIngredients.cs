using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodRecipeAppAPI.Migrations
{
    public partial class AddedDescriptionToIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ingredients");
        }
    }
}
