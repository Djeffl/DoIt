using DoIt.Interface.Todos;

namespace DoIt.Interface.Goals
{
    public class UpdateGoalRequest
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public string Reason { get; set; }

        public DateTime DueAt { get; set; }

        public IEnumerable<TodoDto> ActionPlan { get; set; }
    }
}
