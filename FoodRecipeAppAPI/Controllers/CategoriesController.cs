using FoodRecipeAppAPI.Data.Dtos.Categories;
using FoodRecipeAppAPI.Data.Entities;
using FoodRecipeAppAPI.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipeAppAPI.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
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
        public async Task<ActionResult<CategoryDto>> CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name, Description = dto.Description, CreationDate = DateTime.UtcNow
            };

            await _categoriesRepository.CreateAsync(category);

            return Created("", new CategoryDto { Id = category.Id, Name = category.Name, Description = category.Description, CreationDate = category.CreationDate });
        }

        [HttpPut]
        [Route("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> UpdateAsync(int categoryId, UpdateCategoryDto dto)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            category.Description = dto.Description;
            await _categoriesRepository.UpdateAsync(category);

            return Ok(new CategoryDto { Id = category.Id, Name = category.Name, Description = category.Description, CreationDate = category.CreationDate });
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public async Task<ActionResult> DeleteAsync(int categoryId)
        {
            var category = await _categoriesRepository.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            await _categoriesRepository.DeleteAsync(category);

            return NoContent();
        }
    }
}
