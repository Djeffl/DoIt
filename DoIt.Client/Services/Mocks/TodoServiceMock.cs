using DoIt.Client.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DoIt.Client.Services.Mocks
{
    public class TodoServiceMock : ITodoService
    {
        private readonly HttpClient client;

        public TodoServiceMock(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await client.GetFromJsonAsync<List<Todo>>("sample-data/todos.json");
        }
    }
}
