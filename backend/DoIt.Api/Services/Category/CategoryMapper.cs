using System;
using System.Collections.Generic;
using System.Linq;

using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;

namespace DoIt.Api.Services.Category
{
    public static class CategoryMapper
    {
        public static Domain.Category ToDomain(this CreateCategoryDto category)
        {
            if (category == null)
                return null;

            return new Domain.Category()
            {
                Name = category.Name,
            };
        }

        public static Domain.Category ToDomain(this CategoryDto category)
        {
            if (category == null)
                return null;

            return new Domain.Category()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public static CategoryDto ToDto(this Domain.Category category)
        {
            if (category == null)
                return null;

            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static CategoriesDto ToDto(this IEnumerable<Domain.Category> categories)
        {
            if (categories == null)
                return new CategoriesDto()
                {
                    Data = Array.Empty<CategoryDto>()
                };

            return new CategoriesDto()
            {
                Data = categories.Select(x => x.ToDto())
            };
        }
    }
}
