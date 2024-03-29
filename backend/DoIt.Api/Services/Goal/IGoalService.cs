﻿using DoIt.Api.Services.Goal.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

using DoIt.Interface.Goals;

namespace DoIt.Api.Services.Goal
{
    public interface IGoalService
    {
        Task<GoalsDto> GetGoalsAsync(GetGoalsDto _);
        Task<GoalDto> CreateGoalAsync(Interface.Goals.CreateGoalDto createGoalDto);
        Task<GoalDto> GetGoalAsync(long id);
        Task DeleteGoalAsync(long id);
        Task<GoalDto> UpdateGoalAsync(long id, UpdateGoalRequest request);
    }
}