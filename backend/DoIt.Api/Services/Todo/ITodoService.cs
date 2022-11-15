using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using DoIt.Api.Services.Todo.Dto;
using DoIt.Interface.Todos;

namespace DoIt.Api.Services.Todo
{
    public interface ITodoService
    {
        Task<GetTodoDto> CreateTodoAsync(CreateTodoDto createTodoDto);
        Task<GetTodoDto> GetTodoById(long id);
        Task<IEnumerable<GetTodoDto>> GetTodos();
        Task<GetTodoDto> UpdateAsync(long id, UpdateTodoDto todo);

        Task<IEnumerable<GetTodoDto>> GetListAsync(GetTodoListQueryDto query);
    }
}
