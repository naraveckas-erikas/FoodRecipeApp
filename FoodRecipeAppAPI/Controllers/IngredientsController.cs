using FoodRecipeAppAPI.Data.Dtos.Ingredients;
using FoodRecipeAppAPI.Data.Entities;
using FoodRecipeAppAPI.Data.Repositories;
using FoodRecipeAppAPI.Data.Repositories.Ingredients;
using FoodRecipeAppAPI.Data.Repositories.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipeAppAPI.Controllers
{
    [Route("api/v1/categories/{categoryId}/recipes/{recipeId}/ingredients")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsRepository _ingredientsRepository;
        private readonly IRecipesRepository _recipesRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public IngredientsController(IIngredientsRepository ingredientsRepository, IRecipesRepository recipesRepository, ICategoriesRepository categoriesRepository)
        {
            _ingredientsRepository = ingredientsRepository;
            _recipesRepository = recipesRepository;
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientDto>> GetAllAsync(int recipeId)
        {
            var ingredients = await _ingredientsRepository.GetAllAsync(recipeId);

            return ingredients.Select(i => new IngredientDto
            {
                Id = i.Id,
                Name = i.Name,
                Type = i.Type,
                IsVegetarian = i.IsVegetarian,
                IsVegan = i.IsVegan
            });
        }

        [HttpGet]
        [Route("{ingredientId}")]
        public async Task<ActionResult<IngredientDto>> GetAsync(int categoryId, int recipeId, int ingredientId)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var recipe = await _recipesRepository.GetAsync(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredient = await _ingredientsRepository.GetAsync(ingredientId);

            if (ingredient == null)
            {
                return NotFound();
            }

            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Type = ingredient.Type,
                IsVegetarian = ingredient.IsVegetarian,
                IsVegan = ingredient.IsVegan
            };
        }

        [HttpPost]
        public async Task<ActionResult<IngredientDto>> CreateAsync(int categoryId, int recipeId, CreateIngredientDto dto)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var recipe = await _recipesRepository.GetAsync(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredient = new Ingredient
            {
                Name = dto.Name,
                Type = dto.Type,
                IsVegetarian = dto.IsVegetarian,
                IsVegan = dto.IsVegan,
                Recipe = recipe
            };

            await _ingredientsRepository.CreateAsync(ingredient);

            return Created("", new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Type = ingredient.Type,
                IsVegetarian = ingredient.IsVegetarian,
                IsVegan = ingredient.IsVegan
            });
        }

        [HttpPut]
        [Route("{ingredientId}")]
        public async Task<ActionResult<IngredientDto>> UpdateAsync(int categoryId, int recipeId, int ingredientId, CreateIngredientDto dto)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var recipe = await _recipesRepository.GetAsync(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredient = await _ingredientsRepository.GetAsync(ingredientId);

            if (ingredient == null)
            {
                return NotFound();
            }

            ingredient.Name = dto.Name;
            ingredient.Type = dto.Type;
            ingredient.IsVegetarian = dto.IsVegetarian;
            ingredient.IsVegan = dto.IsVegan;

            await _ingredientsRepository.UpdateAsync(ingredient);

            return Ok(new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Type = ingredient.Type,
                IsVegetarian = ingredient.IsVegetarian,
                IsVegan = ingredient.IsVegan
            });
        }

        [HttpDelete]
        [Route("{ingredientId}")]
        public async Task<ActionResult> DeleteAsync(int categoryId, int recipeId, int ingredientId)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var recipe = await _recipesRepository.GetAsync(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredient = await _ingredientsRepository.GetAsync(ingredientId);

            if (ingredient == null)
            {
                return NotFound();
            }

            await _ingredientsRepository.DeleteAsync(ingredient);

            return NoContent();
        }
    }
}
