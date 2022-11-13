using FoodRecipeAppAPI.Auth.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipeAppAPI.Data.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public Recipe Recipe { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
    }
}
