using DoIt.Api.Data;
using DoIt.Api.Exceptions;
using DoIt.Api.Services.Goal.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

using DoIt.Interface.Goals;
using DoIt.Api.Services.Todo;

namespace DoIt.Api.Services.Goal
{
    public class GoalService : IGoalService
    {
        private readonly DoItContext _ctx;

        public GoalService(DoItContext context)
        {
            _ctx = context;
        }

        public async Task<GoalDto> CreateGoalAsync(CreateGoalDto createGoalDto)
        {
            var idea = createGoalDto.IdeaId.HasValue ? await _ctx.Ideas.FirstOrDefaultAsync(x => x.Id == createGoalDto.IdeaId) : null;
            var categories = await _ctx.Categories.Where(x => createGoalDto.CategoryIds.Contains(x.Id)).ToListAsync();
            var newGoal = createGoalDto.ToDomain(idea, categories);

            _ctx.Goals.Add(newGoal);

            await _ctx.SaveChangesAsync();

            return newGoal.ToDto();
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

            var goal = await _ctx.Goals.Include(x => x.Todos).FirstOrDefaultAsync(x => x.Id == id);

            if (goal is null)
            {
                throw new ObjectNotFoundException($"Goal with id '{id}' not found.");
            }

            goal.Title = request.Title;
            goal.Description = request.Description;
            goal.Location = request.Location;
            goal.Reason = request.Reason;
            goal.DueAt = request.DueAt;
            goal.State = request.State.ToDomain();

            // Delete children
            foreach (var existingChild in goal.Todos.ToList())
            {
                if (!request.ActionPlan.Any(c => c.Id == existingChild.Id))
                    _ctx.Todos.Remove(existingChild);
            }

            // Update and Insert children
            foreach (var childModel in request.ActionPlan)
            {
                var existingChild = goal.Todos
                    .Where(c => c.Id == childModel.Id && c.Id != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                {
                    // Update child
                    //_ctx.Entry(existingChild).CurrentValues.SetValues(childModel);
                    existingChild.IsFinished = childModel.IsFinished;
                    existingChild.Description = childModel.Description;
                    existingChild.Title = childModel.Title;
                }
                else
                {
                    // Insert child
                    var newChild = childModel.ToDomain(null);
                    goal.Todos.Add(newChild);
                }
            }

            await _ctx.SaveChangesAsync();

            return goal.ToDto();
        }

        public async Task<GoalDto> GetGoalAsync(long id)
        {
            var goal = await _ctx.Goals.Include(x => x.Todos).FirstOrDefaultAsync(x => x.Id == id);

            return goal.ToDto();
        }

        public async Task<GoalsDto> GetGoalsAsync(GetGoalsDto _)
        {
            var response = await _ctx.Goals.Include(x => x.Todos).ToListAsync();

            response.ForEach(goal =>
            {
                goal.CompletionPercentage = goal.Todos.Any() ? (Double?)Math.Round(Decimal.Divide(goal.Todos.Count(x => x.IsFinished), goal.Todos.Count()), 2) : null;
            });

            return new GoalsDto()
            {
                Data = response.Select(x => x.ToDto()).ToList()
            };
        }
    }
}
