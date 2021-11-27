using DoIt.Client.Models.Goals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoIt.Client.Services.Goals
{
	public interface IGoalService
	{
		Task<GoalsDto> GetAllAsync();

		Task<GoalDto> CreateGoalAsync(GoalCreate goal);

		Task<GoalDetail> GetGoalByIdAsync(long goalId);

		Task DeleteGoalAsync(long goalId);
	}
}