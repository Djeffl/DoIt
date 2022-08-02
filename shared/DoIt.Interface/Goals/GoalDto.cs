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

        public IEnumerable<GoalTodoDto> ActionPlan { get; set; }
    }
}
