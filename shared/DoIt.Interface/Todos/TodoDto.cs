using DoIt.Interface.Goals;

namespace DoIt.Interface.Todos
{
    public class TodoDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsFinished { get; set; }

        public DateTime? DueAt { get; set; }

        public DateTime? PlannedAt { get; set; }

        public long? GoalId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
