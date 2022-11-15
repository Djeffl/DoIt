using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

using DoIt.Api.Data;
using DoIt.Api.Exceptions;
using DoIt.Api.Services.Todo.Dto;
using DoIt.Interface.Todos;
using Microsoft.EntityFrameworkCore;

namespace DoIt.Api.Services.Todo
{
    public class TodoService : ITodoService
    {
        private readonly DoItContext _context;

        public TodoService(DoItContext context)
        {
            _context = context;
        }

        public async Task<GetTodoDto> CreateTodoAsync(CreateTodoDto createTodoDto)
        {
            var newTodo = createTodoDto.ToData();

            if (newTodo.Goal is not null)
            {
                var goal = await _context.Goals.FindAsync(newTodo.Goal.Id);
                if (goal is null)
                    throw new ObjectNotFoundException($"Related goal with id '{goal.Id}' not found.");
            }

            newTodo.CreatedAt = DateTime.UtcNow;

            await _context.Todos.AddAsync(newTodo);
            await _context.SaveChangesAsync();

            return newTodo.ToDto();
        }

        public async Task<IEnumerable<GetTodoDto>> GetListAsync(GetTodoListQueryDto query)
        {
            var list = await _context.Todos.Where(x => x.PlannedAt == query.PlannedAt).ToListAsync();

            return list.Select(x => x.ToDto());
        }

        public async Task<GetTodoDto> GetTodoById(long id)
        {
            var newTodo = await _context.Todos.FindAsync(id);

            return newTodo.ToDto();
        }

        public async Task<IEnumerable<GetTodoDto>> GetTodos()
        {
            var todos = await _context.Todos.ToListAsync();

            return todos.Select(x => x.ToDto());
        }

        public async Task<GetTodoDto> UpdateAsync(long id, UpdateTodoDto request)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo is null)
            {
                throw new ObjectNotFoundException($"Todo with id '{id}' not found.");
            }

            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.DueAt = request.DueAt;
            todo.PlannedAt = request.PlannedAt;

            await _context.SaveChangesAsync();

            return todo.ToDto();
        }
    }
}
