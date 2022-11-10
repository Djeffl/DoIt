using DoIt.Client.Models.Ideas;
using System.Linq;

namespace DoIt.Client.Services.Ideas
{
    public static class IdeaMapper
    {
        public static Interface.Ideas.CreateIdeaDto ToService(this IdeaFormDto idea)
        {
            return new DoIt.Interface.Ideas.CreateIdeaDto
            {
                Title = idea.Title,
                CategoryIds = idea.CategoryIds,
                Description = idea.Description,
            };
        }
    }
}
