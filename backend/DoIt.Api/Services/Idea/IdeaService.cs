using DoIt.Api.Data;
using DoIt.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

using DoIt.Interface.Ideas;

namespace DoIt.Api.Services.Idea
{
    public class IdeaService : IIdeaService
    {
        private readonly DoItContext _ctx;

        public IdeaService(DoItContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IdeaDto> CreateIdeaAsync(CreateIdeaDto createGoalDto)
        {
            var categories = await _ctx.Categories.Where(x => createGoalDto.CategoryIds.Contains(x.Id)).ToListAsync();
            var newIdea = createGoalDto.ToDomain(categories);

            await _ctx.AddAsync(newIdea);

            await _ctx.SaveChangesAsync();

            return newIdea.ToDto();
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

        public async Task<IdeaDto> UpdateIdeaAsync(long id, UpdateIdeaDto updateIdeaDto)
        {
            var idea = await _ctx.Ideas.FirstOrDefaultAsync(x => x.Id == id);

            if (idea is null)
            {
                throw new ObjectNotFoundException("Idea not found");
            }

            idea.Description = updateIdeaDto.Description;
            idea.Title = updateIdeaDto.Title;
            idea.Categories = updateIdeaDto.CategoryIds.Select(x => new Domain.Category()
            {
                Id = x
            }).ToList();

            await _ctx.SaveChangesAsync();

            return idea.ToDto();
        }

        public async Task<IdeaDto> GetIdeaAsync(long id)
        {
            var idea = await _ctx.Ideas
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == id);

            return idea.ToDto();
        }

        public async Task<IdeasDto> GetIdeasAsync()
        {
            return new IdeasDto()
            {
                Data = await _ctx.Ideas
                    .Select(idea => idea.ToDto())
                    .ToListAsync()
            };
        }
    }
}
