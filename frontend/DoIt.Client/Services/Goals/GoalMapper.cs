namespace DoIt.Client.Services.Goals
{
    public static class GoalMapper
    {
        public static Interface.Goals.CreateGoalDto ToService(this Models.Goals.GoalFormDto goal)
        {
            return new DoIt.Interface.Goals.CreateGoalDto
            {
                Title = goal.Title,
                CategoryIds = goal.CategoryIds,
                Description = goal.Description,
                CreatedAt = goal.CreatedAt,
                Reason = goal.Reason,
                Location = goal.Location,
                DueAt = goal.DueAt,
                IdeaId = goal.IdeaId, 
            };
        }
    }
}
