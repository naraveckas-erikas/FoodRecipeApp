using FoodRecipeAppAPI.Data.Entities;

namespace FoodRecipeAppAPI.Data.Repositories.Recipes
{
    public interface IRecipesRepository
    {
        Task CreateAsync(Recipe recipe);
        Task DeleteAsync(Recipe recipe);
        Task<IReadOnlyList<Recipe>> GetAllAsync(int categoryId);
        Task<Recipe?> GetAsync(int id);
        Task UpdateAsync(Recipe recipe);
    }
}