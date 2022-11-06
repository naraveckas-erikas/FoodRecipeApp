using FoodRecipeAppAPI.Auth.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipeAppAPI.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
        public string OriginCountry { get; set; }
        public int TimeToPrepare { get; set; }
        public int PortionsCount { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public Category Category { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
    }
}
