using FoodRecipeAppAPI.Data.Entities;

namespace FoodRecipeAppAPI.Data.Repositories
{
    public interface ICategoriesRepository
    {
        Task CreateAsync(Category category);
        Task DeleteAsync(Category category);
        Task<IReadOnlyList<Category>> GetAllAsync();
        Task<Category?> GetAsync(int id);
        Task UpdateAsync(Category category);
    }
}