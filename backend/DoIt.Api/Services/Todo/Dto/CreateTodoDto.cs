namespace DoIt.Api.Services.Todo.Dto
{
    public class CreateTodoDto
    {
        public string Title { get; set; }
        public long? GoalId { get; set; }
    }
}
