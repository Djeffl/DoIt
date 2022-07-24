using System.Threading.Tasks;

using DoIt.Api.Services.Todo.Dto;

namespace DoIt.Api.Services.Todo
{
    public interface ITodoService
    {
        Task<GetTodoDto> CreateTodoAsync(CreateTodoDto createTodoDto);
        Task<GetTodoDto> GetTodoById(long id);
    }
}
