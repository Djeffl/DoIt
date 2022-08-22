using System.Threading.Tasks;

using DoIt.Interface.Ideas;

namespace DoIt.Api.Services.Idea
{
	public interface IIdeaService
	{
		Task<IdeasDto> GetIdeasAsync();
		Task<IdeaDto> CreateIdeaAsync(CreateIdeaDto createGoalDto);
		Task<IdeaDto> GetIdeaAsync(long id);
		Task DeleteIdeaAsync(long id);
        Task<IdeaDto> UpdateIdeaAsync(long id, UpdateIdeaDto updateIdeaDto);

	}
}
