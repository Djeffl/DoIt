using DoIt.Client.Models.Todos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.WebUtilities;
using DoIt.Interface.Todos;
using System.Net.Mime;
using System.Text;

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

        public async Task<IEnumerable<TodoDto>> GetListAsync(GetTodoListQueryDto query)
        {
            var url = QueryHelpers.AddQueryString(baseUrl, new Dictionary<string, string>()
            {
                { nameof(query.PlannedAt), query.PlannedAt.ToString()},
            });

            return await client.GetFromJsonAsync<IEnumerable<TodoDto>>(url);
        }

        public async Task<TodoDto> UpdateAsync(long id, UpdateTodoDto todo)
        {
            var json = JsonConvert.SerializeObject(todo);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await client.PatchAsync($"{baseUrl}/{id}", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Updating todo failed.");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TodoDto>(responseString);

            return result;
        }
    }
}
