using DoIt.Client.Models.Todos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DoIt.Client.Services.Todos
{
	public class TodoService : ITodoService
    {
        private readonly HttpClient client;

        public TodoService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await client.GetFromJsonAsync<List<Todo>>("api/todos");
        }
    }
}
