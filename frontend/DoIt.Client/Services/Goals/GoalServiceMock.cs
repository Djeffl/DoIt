using DoIt.Client.Models.Goals;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using DoIt.Client.Models.Todos;
using DoIt.Interface.Goals;


namespace DoIt.Client.Services.Goals
{
	public class GoalServiceMock : IGoalService
	{
        private readonly HttpClient client;

        public GoalServiceMock(HttpClient client)
        {
            this.client = client;
        }

		public Task<GoalDto> CreateGoalAsync(CreateGoalRequest goal)
		{
            return Task.Run(() => new GoalDto
            {
                CreatedAt = DateTime.Now,
                //DueAt = goal.DueAt,
                Description = goal.Description,
                Title = goal.Title,
                //Type = Enum.Parse<GoalType>(goal.Type)
            });
        }

		public Task DeleteGoalAsync(long goalId)
		{
            return Task.CompletedTask; 
		}

        public async Task<TodoDto> CreateGoalTodoAsync(long goalId, CreateTodoDto createTodoDto)
        {
            return new TodoDto();
        }

        public Task<GoalDto> UpdateGoalAsync(long goalId, UpdateGoalRequest updateGoalRequest)
        {
            return null;
        }

        public async Task<GoalsDto> GetAllAsync()
        {
            return await client.GetFromJsonAsync<GoalsDto>("sample-data/goals.json");
        }

		public async Task<GoalDetail> GetGoalByIdAsync(long goalId)
		{
            return await client.GetFromJsonAsync<GoalDetail>("sample-data/goal-detail.json");
        }
	}
}
