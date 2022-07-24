using DoIt.Client.Models.Todos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace DoIt.Client.Services.Todos
{
	public class TodoService : ITodoService
    {
        private readonly string baseUrl = "api/todos";
        private readonly HttpClient client;

        public TodoService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<TodoDto>> GetAllAsync()
        {
            return await client.GetFromJsonAsync<List<TodoDto>>(baseUrl);
        }

        public async Task<TodoDto> CreateAsync(CreateTodoDto newTodo)
        {
            var response = await client.PostAsJsonAsync<CreateTodoDto>(baseUrl, newTodo);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TodoDto>(responseString);

            return result;
        }
    }
}
