using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using DoIt.Api.Services.Todo.Dto;
using DoIt.Interface.Todos;

namespace DoIt.Api.Services.Todo
{
    public interface ITodoService
    {
        Task<TodoDto> CreateTodoAsync(CreateTodoDto createTodoDto);
        Task<TodoDto> GetTodoById(long id);
        Task<IEnumerable<TodoDto>> GetTodos();
        Task<TodoDto> UpdateAsync(long id, UpdateTodoDto todo);

        Task<IEnumerable<TodoDto>> GetListAsync(GetTodoListQueryDto query);
    }
}
