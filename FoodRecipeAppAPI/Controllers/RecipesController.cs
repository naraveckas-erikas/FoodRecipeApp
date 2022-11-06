using FoodRecipeAppAPI.Auth.Models;
using FoodRecipeAppAPI.Data.Dtos.Recipes;
using FoodRecipeAppAPI.Data.Entities;
using FoodRecipeAppAPI.Data.Repositories;
using FoodRecipeAppAPI.Data.Repositories.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FoodRecipeAppAPI.Controllers
{
    [Route("api/v1/categories/{categoryId}/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesRepository _recipesRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IAuthorizationService _authorizationService;

        public RecipesController(IRecipesRepository recipesRepository, ICategoriesRepository categoriesRepository, IAuthorizationService authorizationService)
        {
            _recipesRepository = recipesRepository;
            _categoriesRepository = categoriesRepository;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetAllAsync(int categoryId)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var recipes = await _recipesRepository.GetAllAsync(categoryId);

            return Ok(recipes
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
                }));
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
        [Authorize(Roles = AppRoles.User)]
        public async Task<ActionResult<RecipeDto>> CreateAsync(int categoryId, CreateRecipeDto dto)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, category, PolicyNames.ResourceOwner);

            if (!authorizationResult.Succeeded)
            {
                return Forbid();
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
                Category = category,
                UserId = User.FindFirst(JwtRegisteredClaimNames.Sub).Value
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
        [Authorize(Roles = AppRoles.User)]
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

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, recipe, PolicyNames.ResourceOwner);

            if (!authorizationResult.Succeeded)
            {
                return Forbid();
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
        [Authorize(Roles = AppRoles.User)]
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

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, recipe, PolicyNames.ResourceOwner);

            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            await _recipesRepository.DeleteAsync(recipe);

            return NoContent();
        }
    }
}
