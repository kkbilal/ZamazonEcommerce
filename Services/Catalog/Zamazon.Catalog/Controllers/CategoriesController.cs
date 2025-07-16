using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Catalog.Dtos.CategoryDtos;
using Zamazon.Catalog.Services.CategoryServices;

namespace Zamazon.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);           
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Category Added Successfully");

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
                  
            await _categoryService.UpdateCategoryAsync( updateCategoryDto);
            return Ok("Category Updated Successfully");
        }
        [HttpDelete("{id}")]   
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Category Deleted Successfully");
        }

    }
}
