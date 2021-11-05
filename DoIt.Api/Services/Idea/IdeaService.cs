using DoIt.Api.Data;
using DoIt.Api.Exceptions;
using DoIt.Api.Services.Idea.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Services.Idea
{
	public class IdeaService : IIdeaService
	{
		private readonly DoItContext _ctx;

		public IdeaService(DoItContext ctx)
		{
			_ctx = ctx;
		}

		public async Task<GetIdeaDto> CreateGoalAsync(CreateIdeaDto createGoalDto)
		{
			var newIdea = new Domain.Idea()
			{
				Title = createGoalDto.Title,
				Description = createGoalDto.Description,
				CreatedAt = DateTime.UtcNow
			};

			await _ctx.AddAsync<Domain.Idea>(newIdea);

			await _ctx.SaveChangesAsync();

			Console.WriteLine("Created idea!");

			return new GetIdeaDto()
			{
				Id = newIdea.Id,
				Title = newIdea.Title,
				Description = newIdea.Description
			};
		}

		public async Task DeleteIdeaAsync(long id)
		{
			var idea = await _ctx.Ideas.SingleOrDefaultAsync(x => x.Id == id);
			if (idea == null)
			{
				throw new ObjectNotFoundException();
			}
			_ctx.Ideas.Remove(idea);

			await _ctx.SaveChangesAsync();
		}

		public async Task<GetIdeaDto> GetIdeaAsync(long id)
		{
			return await _ctx.Ideas
				.Select(x => new GetIdeaDto()
				{
					Id = x.Id,
					Description = x.Description,
					Title = x.Title
				}).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<GetIdeasDto> GetGoalsAsync()
		{
			return new GetIdeasDto()
			{
				Ideas = await _ctx.Ideas
				.Select(x => new GetIdeaDto()
				{
					Id = x.Id,
					Description = x.Description,
					Title = x.Title
				}).ToListAsync()
			};
		}
	}
}
