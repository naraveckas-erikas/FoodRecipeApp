using FoodRecipeAppAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeAppAPI.Data.Repositories.Recipes
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly RecipeAppDbContext _dbContext;
        public RecipesRepository(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recipe recipe)
        {
            _dbContext.Recipes.Remove(recipe);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Recipe>> GetAllAsync(int categoryId)
        {
            return await _dbContext.Recipes.Where(r => r.Category.Id == categoryId).ToListAsync();
        }

        public async Task<Recipe?> GetAsync(int id)
        {
            return await _dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            _dbContext.Recipes.Update(recipe);
            await _dbContext.SaveChangesAsync();
        }
    }
}
