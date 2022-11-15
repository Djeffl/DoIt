namespace DoIt.Interface.Todos
{
    public class UpdateTodoDto
    {
        public string Title { get; set; }

        public long? GoalId { get; set; }

        public DateTime? DueAt { get; set; }

        public DateTime? PlannedAt { get; set; }

        public string Description { get; set; }
    }
}
