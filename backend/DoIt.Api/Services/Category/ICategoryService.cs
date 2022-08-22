using System.Threading.Tasks;

using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;

namespace DoIt.Api.Services.Category;

public interface ICategoryService
{
    Task<CategoriesDto> GetCategoriesListAsync();
    Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto ideaCategoryDto);
    Task<CategoriesDto> CreateCategoriesAsync(CreateCategoryBulkDto ideaCategoryBulkDto);
}