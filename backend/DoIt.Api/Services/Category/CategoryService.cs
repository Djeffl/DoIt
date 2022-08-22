using System.Linq;
using System.Threading.Tasks;

using DoIt.Api.Data;
using DoIt.Api.Exceptions;
using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;

using Microsoft.EntityFrameworkCore;

namespace DoIt.Api.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly DoItContext _context;

        public CategoryService(DoItContext context)
        {
            _context = context;
        }

        public async Task<CategoriesDto> GetCategoriesListAsync()
        {
            var ideaCategories = await _context.Categories.ToListAsync();

            return ideaCategories.ToDto();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var dbCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryDto.Name);

            if (dbCategory is not null)
                throw new ObjectExistsException();

            var newCategory = categoryDto.ToDomain();

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return newCategory.ToDto();
        }

        public async Task<CategoriesDto> CreateCategoriesAsync(CreateCategoryBulkDto categoryBulkDto)
        {
            var dbIdeaCategoriesFound = await _context.Categories.AnyAsync(dbCategory => categoryBulkDto.Categories.Select(x => x.Name).Contains(dbCategory.Name));

            if (dbIdeaCategoriesFound)
                throw new ObjectExistsException();

            var newCategories = categoryBulkDto.Categories.Select(category => category.ToDomain()).ToArray();

            await _context.Categories.AddRangeAsync(newCategories);
            await _context.SaveChangesAsync();

            return newCategories.ToDto();
        }
    }
}
