using FoodRecipeAppAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeAppAPI.Data.Repositories.Ingredients
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly RecipeAppDbContext _dbContext;
        public IngredientsRepository(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ingredient ingredient)
        {
            _dbContext.Ingredients.Remove(ingredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Ingredient>> GetAllAsync(int recipeId)
        {
            return await _dbContext.Ingredients.Where(i => i.Recipe.Id == recipeId).ToListAsync();
        }

        public async Task<Ingredient?> GetAsync(int id)
        {
            return await _dbContext.Ingredients.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(Ingredient ingredient)
        {
            _dbContext.Ingredients.Update(ingredient);
            await _dbContext.SaveChangesAsync();
        }
    }
}
