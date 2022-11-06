using FoodRecipeAppAPI.Auth.Models;
using FoodRecipeAppAPI.Data.Dtos.Categories;
using FoodRecipeAppAPI.Data.Entities;
using FoodRecipeAppAPI.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FoodRecipeAppAPI.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IAuthorizationService _authorizationService;

        public CategoriesController(ICategoriesRepository categoriesRepository, IAuthorizationService authorizationService)
        {
            _categoriesRepository = categoriesRepository;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoriesRepository.GetAllAsync();

            return categories.Select(c => new CategoryDto { Id = c.Id, Name = c.Name, Description = c.Description, CreationDate = c.CreationDate });
        }

        [HttpGet]
        [Route("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> GetAsync(int categoryId)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return new CategoryDto { Id = category.Id, Name = category.Name, Description = category.Description, CreationDate = category.CreationDate };
        }

        [HttpPost]
        [Authorize(Roles = AppRoles.User)]
        public async Task<ActionResult<CategoryDto>> CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                CreationDate = DateTime.UtcNow,
                UserId = User.FindFirst(JwtRegisteredClaimNames.Sub).Value
            };

            await _categoriesRepository.CreateAsync(category);

            return Created("", new CategoryDto { Id = category.Id, Name = category.Name, Description = category.Description, CreationDate = category.CreationDate });
        }

        [HttpPut]
        [Route("{categoryId}")]
        [Authorize(Roles = AppRoles.User)]
        public async Task<ActionResult<CategoryDto>> UpdateAsync(int categoryId, UpdateCategoryDto dto)
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

            category.Description = dto.Description;
            await _categoriesRepository.UpdateAsync(category);

            return Ok(new CategoryDto { Id = category.Id, Name = category.Name, Description = category.Description, CreationDate = category.CreationDate });
        }

        [HttpDelete]
        [Route("{categoryId}")]
        [Authorize(Roles = AppRoles.User)]
        public async Task<ActionResult> DeleteAsync(int categoryId)
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

            await _categoriesRepository.DeleteAsync(category);

            return NoContent();
        }
    }
}
