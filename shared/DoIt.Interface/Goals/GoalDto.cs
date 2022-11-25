using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;
using DoIt.Interface.Todos;

namespace DoIt.Interface.Goals
{
    public class GoalDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DueAt { get; set; }
        
        public DateTime? FinishedAt { get; set; }

        public bool IsFinished { get; set; }

        public string Location { get; set; }

        public string Reason { get; set; }

        public IdeaDto Idea { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }

        public IEnumerable<TodoDto> ActionPlan { get; set; }

        public State State { get; set; }

        public double? CompletionPercentage { get; set; }
    }
}
