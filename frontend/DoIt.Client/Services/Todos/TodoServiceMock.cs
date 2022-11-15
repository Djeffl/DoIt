using DoIt.Client.Models.Todos;
using DoIt.Interface.Todos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DoIt.Client.Services.Todos
{
    public class TodoServiceMock : ITodoService
    {
        private readonly HttpClient client;

        public TodoServiceMock(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<TodoDto>> GetAllAsync()
        {
            return await client.GetFromJsonAsync<List<TodoDto>>("sample-data/todos.json");
        }

        public Task<TodoDto> CreateAsync(CreateTodoDto newTodo)
        {
            return null;
        }

        public async Task<IEnumerable<TodoDto>> GetListAsync(GetTodoListQueryDto query)
        {
            return await client.GetFromJsonAsync<List<TodoDto>>("sample-data/todos.json");
        }

        public Task<TodoDto> UpdateAsync(long id, UpdateTodoDto todo)
        {
            return null;
        }
    }
}
