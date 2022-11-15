using DoIt.Client.Models.Todos;
using DoIt.Interface.Todos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoIt.Client.Services.Todos
{
    public interface ITodoService
    {
        Task<List<TodoDto>> GetAllAsync();

        Task<TodoDto> CreateAsync(CreateTodoDto newTodo);

        Task<IEnumerable<TodoDto>> GetListAsync(GetTodoListQueryDto query);

        Task<TodoDto> UpdateAsync(long id, UpdateTodoDto todo);
    }
}