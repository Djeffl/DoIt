using System.Threading.Tasks;

using DoIt.Interface.Ideas;

namespace DoIt.Client.Services.Ideas
{
	public interface IIdeaService
	{
		Task<IdeasDto> GetAllAsync();

		Task<IdeaDto> CreateAsync(CreateIdeaDto newIdea);

		Task<IdeaDto> GetAsync(long id);

		Task DeleteAsync(long id);

		Task PromoteAsync(long id);

        Task<IdeaDto> UpdateIdeaAsync(long ideaId, UpdateIdeaDto idea);
    }
}