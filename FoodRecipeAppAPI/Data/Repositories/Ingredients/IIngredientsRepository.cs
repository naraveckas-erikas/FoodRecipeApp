using FoodRecipeAppAPI.Data.Entities;

namespace FoodRecipeAppAPI.Data.Repositories.Ingredients
{
    public interface IIngredientsRepository
    {
        Task CreateAsync(Ingredient ingredient);
        Task DeleteAsync(Ingredient ingredient);
        Task<IReadOnlyList<Ingredient>> GetAllAsync(int recipeId);
        Task<Ingredient?> GetAsync(int id);
        Task UpdateAsync(Ingredient ingredient);
    }
}