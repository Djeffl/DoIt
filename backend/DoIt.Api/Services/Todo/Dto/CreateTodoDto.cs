using System;

namespace DoIt.Api.Services.Todo.Dto
{
    public class CreateTodoDto
    {
        public string Title { get; set; }
        public long? GoalId { get; set; }
        public DateTime? DueAt { get; set; }
        public bool IsFinished { get; set; }
    }
}
