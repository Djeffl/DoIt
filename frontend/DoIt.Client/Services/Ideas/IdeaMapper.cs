namespace DoIt.Client.Services.Ideas
{
    public static class IdeaMapper
    {
        public static Interface.Ideas.CreateIdeaDto ToService(this Models.Ideas.CreateIdeaDto idea)
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
