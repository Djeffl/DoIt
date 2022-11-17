using DoIt.Api.Services.Goal;
using DoIt.Api.Services.Todo.Dto;
using DoIt.Interface.Todos;

namespace DoIt.Api.Services.Todo
{
    public static class TodoMapping
    {
        public static Domain.Todo ToDomain(this CreateTodoDto todo)
        {
            return new Domain.Todo()
            {
                Title = todo.Title,
                GoalId = todo.GoalId.Value,
                DueAt = todo.DueAt,
                IsFinished = todo.IsFinished
            };
        }

        public static Domain.Todo ToDomain(this TodoDto todo, Domain.Goal goal)
        {
            return new Domain.Todo()
            {
                Title = todo.Title,
                GoalId = todo.GoalId.Value,
                DueAt = todo.DueAt,
                IsFinished = todo.IsFinished,
                PlannedAt = todo.PlannedAt,
                Description = todo.Description,
                Id = todo.Id,
                CreatedAt = todo.CreatedAt,
                FinishedAt = todo.FinishedAt,
                Goal = goal,
            };
        }

        public static TodoDto ToDto(this Domain.Todo todo)
        {
            return new TodoDto()
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
