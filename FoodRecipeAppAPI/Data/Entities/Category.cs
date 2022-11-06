using FoodRecipeAppAPI.Auth.Models;

namespace FoodRecipeAppAPI.Data.Entities
{
    public class Category : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
    }
}
