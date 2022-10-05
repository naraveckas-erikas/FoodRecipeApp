using FoodRecipeAppAPI.Data.Dtos.Recipes;
using FoodRecipeAppAPI.Data.Entities;
using FoodRecipeAppAPI.Data.Repositories;
using FoodRecipeAppAPI.Data.Repositories.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipeAppAPI.Controllers
{
    [Route("api/v1/{categoryId}/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesRepository _recipesRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public RecipesController(IRecipesRepository recipesRepository, ICategoriesRepository categoriesRepository)
        {
            _recipesRepository = recipesRepository;
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<RecipeDto>> GetAllAsync(int categoryId)
        {
            var recipes = await _recipesRepository.GetAllAsync(categoryId);

            return recipes
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Type = r.Type,
                    CreationDate = r.CreationDate,
                    OriginCountry = r.OriginCountry,
                    TimeToPrepare = r.TimeToPrepare,
                    PortionsCount = r.PortionsCount,
                    IsVegetarian = r.IsVegetarian,
                    IsVegan = r.IsVegan,
                });
        }

        [HttpGet]
        [Route("{recipeId}")]
        public async Task<ActionResult<RecipeDto>> GetAsync(int categoryId, int recipeId)
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

            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Type = recipe.Type,
                CreationDate = recipe.CreationDate,
                OriginCountry = recipe.OriginCountry,
                TimeToPrepare = recipe.TimeToPrepare,
                PortionsCount = recipe.PortionsCount,
                IsVegetarian = recipe.IsVegetarian,
                IsVegan = recipe.IsVegan,
            };
        }

        [HttpPost]
        public async Task<ActionResult<RecipeDto>> CreateAsync(int categoryId, CreateRecipeDto dto)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var recipe = new Recipe
            {
                Name = dto.Name,
                Type = dto.Type,
                CreationDate = DateTime.UtcNow,
                OriginCountry = dto.OriginCountry,
                TimeToPrepare = dto.TimeToPrepare,
                PortionsCount = dto.PortionsCount,
                IsVegetarian = dto.IsVegetarian,
                IsVegan = dto.IsVegan,
                Category = category
            };

            await _recipesRepository.CreateAsync(recipe);

            return Created("", new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Type = recipe.Type,
                CreationDate = recipe.CreationDate,
                OriginCountry = recipe.OriginCountry,
                TimeToPrepare = recipe.TimeToPrepare,
                PortionsCount = recipe.PortionsCount,
                IsVegetarian = recipe.IsVegetarian,
                IsVegan = recipe.IsVegan,
            });
        }

        [HttpPut]
        [Route("{recipeId}")]
        public async Task<ActionResult<RecipeDto>> UpdateAsync(int categoryId, int recipeId, UpdateRecipeDto dto)
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

            recipe.Type = dto.Type;
            recipe.OriginCountry = dto.OriginCountry;
            recipe.TimeToPrepare = dto.TimeToPrepare;
            recipe.PortionsCount = dto.PortionsCount;
            recipe.IsVegetarian = dto.IsVegetarian;
            recipe.IsVegan = dto.IsVegan;

            await _recipesRepository.UpdateAsync(recipe);

            return Ok(new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Type = recipe.Type,
                CreationDate = recipe.CreationDate,
                OriginCountry = recipe.OriginCountry,
                TimeToPrepare = recipe.TimeToPrepare,
                PortionsCount = recipe.PortionsCount,
                IsVegetarian = recipe.IsVegetarian,
                IsVegan = recipe.IsVegan,
            });
        }

        [HttpDelete]
        [Route("{recipeId}")]
        public async Task<ActionResult> DeleteAsync(int categoryId, int recipeId)
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

            await _recipesRepository.DeleteAsync(recipe);

            return NoContent();
        }
    }
}
