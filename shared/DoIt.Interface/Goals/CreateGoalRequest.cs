namespace DoIt.Interface.Goals
{
    public class CreateGoalRequest
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public string Reason { get; set; }

        public DateTime DueAt { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime? FinishedAt { get; set; }

        //public bool IsFinished { get; set; }

        //public GoalType Type { get; set; }

        //public long? IdeaId { get; set; }
    }
}