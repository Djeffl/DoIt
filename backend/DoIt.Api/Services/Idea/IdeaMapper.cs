using System;
using System.Linq;
using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;

namespace DoIt.Api.Services.Idea
{
    public static class IdeaMapper
    {
        public static Domain.Idea ToDomain(this CreateIdeaDto idea, System.Collections.Generic.List<Domain.Category> categories)
        {
            if (idea == null)
                return null;

            return new Domain.Idea()
            {
                Title = idea.Title,
                Description = idea.Description,
                CreatedAt = DateTime.UtcNow,
                Categories = categories
            };
        }

        public static IdeaDto ToDto(this Domain.Idea idea)
        {
            if (idea == null)
                return null;

            return new IdeaDto()
            {
                Id = idea.Id,
                Title = idea.Title,
                Description = idea.Description,
                CreatedAt = idea.CreatedAt,
                Categories = idea.Categories.Select(category => category.ToDto())
            };
        }

        public static Domain.Category ToDomain(this CategoryDto ideaCategory)
        {
            if (ideaCategory == null)
                return null;

            return new Domain.Category()
            {
                Id = ideaCategory.Id,
                Name = ideaCategory.Name,
            };
        }

        public static CategoryDto ToDto(this Domain.Category ideaCategory)
        {
            if (ideaCategory == null)
                return null;

            return new CategoryDto()
            {
                Id = ideaCategory.Id,
                Name = ideaCategory.Name
            };
        }
    }
}
