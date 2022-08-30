using DoIt.Api.Data;
using DoIt.Api.Exceptions;
using DoIt.Api.Services.Goal.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

using DoIt.Interface.Goals;

namespace DoIt.Api.Services.Goal
{
    public class GoalService : IGoalService
    {
        private readonly DoItContext _ctx;

        public GoalService(DoItContext context)
        {
            _ctx = context;
        }

        public async Task<GoalDto> CreateGoalAsync(Interface.Goals.CreateGoalDto createGoalDto)
        {
            var newGoal = new Domain.Goal()
            {
                Title = createGoalDto.Title,
                Description = createGoalDto.Description,
                CreatedAt = DateTime.UtcNow,
                Location = createGoalDto.Location,
                Reason = createGoalDto.Reason,
                DueAt = createGoalDto.DueAt,
            };

            _ctx.Goals.Add(newGoal);

            await _ctx.SaveChangesAsync();

            return new GoalDto
            {
                Id = newGoal.Id,
                Title = newGoal.Title,
                Description = newGoal.Description,
                Location = newGoal.Location,
                Reason = newGoal.Reason,
                CreatedAt = newGoal.CreatedAt,
                DueAt = newGoal.DueAt,
                FinishedAt = newGoal.FinishedAt,
                IsFinished = newGoal.IsFinished
            };
        }

        public async Task DeleteGoalAsync(long id)
        {
            var goal = await _ctx.Goals.SingleOrDefaultAsync(x => x.Id == id);
            if (goal == null)
            {
                throw new ObjectNotFoundException();
            }
            _ctx.Goals.Remove(goal);

            await _ctx.SaveChangesAsync();
        }

        public async Task<GoalDto> UpdateGoalAsync(long id, UpdateGoalRequest request)
        {
            // todo: Validation

            var goal = await _ctx.Goals.FindAsync(id);

            if (goal is null)
            {
                throw new ObjectNotFoundException($"Goal with id '{id}' not found.");
            }

            goal.Title = request.Title;
            goal.Description = request.Description;
            goal.Location = request.Location;
            goal.Reason = request.Reason;
            goal.DueAt = request.DueAt;
            goal.Todos = request.ActionPlan.Select(x => new Domain.Todo
            {
                Title = x.Title,
                IsFinished = x.IsFinished,
                DueAt = x.DueAt
            }).ToList();

            await _ctx.SaveChangesAsync();

            return new GoalDto
            {
                Id = goal.Id,
                Title = goal.Title,
                Description = goal.Description,
                Location = goal.Location,
                Reason = goal.Reason,
                CreatedAt = goal.CreatedAt,
                DueAt = goal.DueAt,
                FinishedAt = goal.FinishedAt,
                IsFinished = goal.IsFinished,

            };
        }

        public async Task<GoalDto> GetGoalAsync(long id)
        {
            var goal = await _ctx.Goals.Include(x => x.Todos).FirstOrDefaultAsync(x => x.Id == id);

            return new GoalDto
            {
                Id = goal.Id,
                Title = goal.Title,
                Description = goal.Description,
                Location = goal.Location,
                Reason = goal.Reason,
                CreatedAt = goal.CreatedAt,
                DueAt = goal.DueAt,
                FinishedAt = goal.FinishedAt,
                IsFinished = goal.IsFinished,
                ActionPlan = goal.Todos.Select(x => new GoalTodoDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsFinished = x.IsFinished,
                    DueAt = x.DueAt
                }),
            };
        }

        public async Task<GoalsDto> GetGoalsAsync(GetGoalsDto _)
        {
            var response = await _ctx.Goals.Include(x => x.Todos).ToListAsync();

            return new GoalsDto()
            {
                Data = response.Select(goal => new GoalDto
                {
                    Id = goal.Id,
                    Title = goal.Title,
                    Description = goal.Description,
                    Location = goal.Location,
                    Reason = goal.Reason,
                    CreatedAt = goal.CreatedAt,
                    DueAt = goal.DueAt,
                    FinishedAt = goal.FinishedAt,
                    IsFinished = goal.IsFinished,
                    ActionPlan = goal.Todos.Select(x => new GoalTodoDto()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        DueAt = x.DueAt,
                        IsFinished = x.IsFinished,
                    })
                }).ToList()
            };
        }
    }
}
