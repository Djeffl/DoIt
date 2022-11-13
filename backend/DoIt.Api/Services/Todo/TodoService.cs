using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

using DoIt.Api.Data;
using DoIt.Api.Exceptions;
using DoIt.Api.Services.Todo.Dto;

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
    }
}
