using DoIt.Api.Services.Todo.Dto;

namespace DoIt.Api.Services.Todo
{
    public  static class TodoMapping
    {
        public static Domain.Todo ToData(this CreateTodoDto todo)
        {
            return new Domain.Todo()
            {
                Title = todo.Title,
                GoalId = todo.GoalId.Value
            };
        }

        public static GetTodoDto ToDto(this Domain.Todo todo)
        {
            return new GetTodoDto()
            {
                Id = todo.Id,
                Title = todo.Title,
                GoalId = todo.GoalId,
                PlannedAt = todo.PlannedAt,
                DueAt = todo.DueAt,
            };
        }
    }
}
