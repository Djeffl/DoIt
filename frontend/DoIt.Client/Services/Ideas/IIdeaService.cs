using DoIt.Client.Models.Ideas;
using System.Threading.Tasks;

namespace DoIt.Client.Services.Ideas
{
	public interface IIdeaService
	{
		Task<IdeasDto> GetAllAsync();

		Task<IdeaDto> CreateAsync(IdeaCreateDto newIdea);

		Task<IdeaDto> GetAsync(long id);

		Task DeleteAsync(long id);

		Task PromoteAsync(long id);

        Task<IdeaDto> UpdateIdeaAsync(long ideaId, UpdateIdeaDto idea);
    }
}