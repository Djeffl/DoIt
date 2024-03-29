﻿using DoIt.Client.Models.Goals;

using System.Threading.Tasks;

using DoIt.Client.Models.Todos;
using DoIt.Interface.Goals;
using DoIt.Interface.Todos;

namespace DoIt.Client.Services.Goals
{
	public interface IGoalService
	{
		Task<GoalsDto> GetAllAsync();

		Task<GoalDto> CreateGoalAsync(Interface.Goals.CreateGoalDto goal);

		Task<GoalDetail> GetGoalByIdAsync(long goalId);

		Task DeleteGoalAsync(long goalId);

        Task<TodoDto> CreateGoalTodoAsync(long goalId, CreateTodoDto createTodoDto);
        
        Task<GoalDto> UpdateGoalAsync(long goalId, UpdateGoalRequest updateGoalRequest);
    }
}