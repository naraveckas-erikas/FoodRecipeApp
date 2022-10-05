using FoodRecipeAppAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeAppAPI.Data
{
    public class RecipeAppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FoodRecipeAppDb");
        }
    }
}
