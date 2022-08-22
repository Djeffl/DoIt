using System.Collections.Generic;
using System.Threading.Tasks;

using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;

namespace DoIt.Client.Services.IdeaCategories;

public interface ICategoryService
{
    Task<CategoryDto> CreateAsync(CreateCategoryDto newIdeaCategory);
    Task<CategoriesDto> CreateBulkAsync(CreateCategoryBulkDto newIdeaCategoryBulk);
    Task DeleteAsync(long id);
    Task<CategoriesDto> GetListAsync();
}