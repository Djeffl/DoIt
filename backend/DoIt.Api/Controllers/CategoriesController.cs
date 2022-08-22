using System.Collections.Generic;
using System.Threading.Tasks;
using DoIt.Api.Services.Category;
using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;

using Microsoft.AspNetCore.Mvc;

namespace DoIt.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        [ActionName("GetCategoriesAsync")]
        public async Task<ActionResult<CategoriesDto>> GetCategoriesAsync()
        {
            var result = await _categoryService.GetCategoriesListAsync();

            return result;
        }

        [HttpPost]
        [Route("")]
        [ActionName("CreateCategoryAsync")]
        public async Task<ActionResult<CategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var result = await _categoryService.CreateCategoryAsync(categoryDto);

            return result;
        }


        [HttpPost]
        [Route("bulk")]
        [ActionName("CreateBulkAsync")]
        public async Task<ActionResult<CategoriesDto>> CreateBulkAsync(CreateCategoryBulkDto categoryBulkDto)
        {
            var result = await _categoryService.CreateCategoriesAsync(categoryBulkDto);

            return result;
        }
    }
}
