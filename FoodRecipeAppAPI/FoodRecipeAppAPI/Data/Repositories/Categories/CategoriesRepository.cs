using FoodRecipeAppAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeAppAPI.Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly RecipeAppDbContext _dbContext;
        public CategoriesRepository(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
