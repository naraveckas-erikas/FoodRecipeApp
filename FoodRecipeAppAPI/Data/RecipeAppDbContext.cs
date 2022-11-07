using FoodRecipeAppAPI.Auth.Models;
using FoodRecipeAppAPI.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeAppAPI.Data
{
    public class RecipeAppDbContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public RecipeAppDbContext(DbContextOptions<RecipeAppDbContext> options) : base(options)
        {

        }
    }
}
