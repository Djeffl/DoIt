using DoIt.Api.Data;
using DoIt.Api.Domain;
using DoIt.Api.Exceptions;
using DoIt.Api.Services.Goal.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Services
{
	public class GoalService : IGoalService
	{
		private readonly DoItContext _ctx;

		public GoalService(DoItContext context)
		{
			this._ctx = context;
		}

		public async Task<GoalDto> CreateGoalAsync(CreateGoalDto createGoalDto)
		{
			try
			{
				var newGoal = new Domain.Goal()
				{
					Title = createGoalDto.Title,
					Description = createGoalDto.Description,
					DueAt = createGoalDto.DueAt,
					CreatedAt = DateTime.UtcNow
				};

				_ctx.Goals.Add(newGoal);

				await _ctx.SaveChangesAsync();

				return new GoalDto
				{
					Title = newGoal.Title,
					Description = newGoal.Description
				};
			}
			catch (Exception ex)
			{
				throw ex;
			}
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

		public async Task<GoalDto> GetGoalAsync(long id)
		{
			var result = await _ctx.Goals.FirstOrDefaultAsync();

			return new GoalDto
			{
				Title = result.Title,
				Description = result.Description
			};
		}

		public async Task<IEnumerable<GoalDto>> GetGoalsAsync(GetGoalsDto _)
		{
			var response = await _ctx.Goals.ToListAsync();

			return response.Select(x => new GoalDto
			{
				Title = x.Title,
				Description = x.Description
			});
		}
	}
}
