using System;

using DoIt.Client.Models;
using DoIt.Client.Models.Goals;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

using DoIt.Client.Models.Todos;
using DoIt.Interface.Goals;


namespace DoIt.Client.Services.Goals
{
	public class GoalService : IGoalService
    {
        private readonly string _baseUrl = "api/goals";
		private readonly HttpClient client;

		public GoalService(HttpClient client)
		{
			this.client = client;
		}

		public async Task<GoalDto> CreateGoalAsync(CreateGoalRequest goal)
		{
			var response = await client.PostAsJsonAsync(_baseUrl, goal);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

			var jsonContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GoalDto>(jsonContent);
		}

		public async Task DeleteGoalAsync(long goalId)
		{
			await client.DeleteAsync($"{_baseUrl}/{goalId}");
		}

        public async Task<TodoDto> CreateGoalTodoAsync(long goalId, CreateTodoDto createTodoDto)
        {
			var response = await client.PostAsJsonAsync($"{_baseUrl}/{goalId}/todos", createTodoDto);
            var jsonContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TodoDto>(jsonContent);
		}

        public async Task<GoalDto> UpdateGoalAsync(long goalId, UpdateGoalRequest updateGoalRequest)
        {
            var json = JsonConvert.SerializeObject(updateGoalRequest);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

			var response = await client.PatchAsync($"{_baseUrl}/{goalId}", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Updating goal failed.");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<GoalDto>(responseString);

            return result;
        }

        public async Task<GoalsDto> GetAllAsync()
		{
			return await client.GetFromJsonAsync<GoalsDto>("api/goals");
		}

		public async Task<GoalDetail> GetGoalByIdAsync(long goalId)
		{
			return await client.GetFromJsonAsync<GoalDetail>($"api/goals/{goalId}");
		}
	}
}
