using DoIt.Api.Services.Goal.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoIt.Api.Services
{
	public interface IGoalService
	{
		Task<IEnumerable<GoalDto>> GetGoalsAsync(GetGoalsDto _);
		Task<GoalDto> CreateGoalAsync(CreateGoalDto createGoalDto);
		Task<GoalDto> GetGoalAsync(long id);
		Task DeleteGoalAsync(long id);
	}
}