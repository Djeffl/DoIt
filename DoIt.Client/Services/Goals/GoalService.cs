using DoIt.Client.Models;
using DoIt.Client.Models.Goals;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

		public async Task<GoalDto> CreateGoalAsync(GoalCreate goal)
		{
			System.Console.WriteLine("Trying to create a goal...");
			var response = await client.PostAsJsonAsync(_baseUrl, goal);
			System.Console.WriteLine("Create goal..");
			var jsonContent = await response.Content.ReadAsStringAsync();
			System.Console.WriteLine("response", jsonContent);

			return JsonConvert.DeserializeObject<GoalDto>(jsonContent);
		}

		public async Task DeleteGoalAsync(long goalId)
		{
			System.Console.WriteLine("Deleting goal... API CALL...");
			await client.DeleteAsync($"api/goals/{goalId}");
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
