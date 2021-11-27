using DoIt.Client.Models.Ideas;
using System.Threading.Tasks;

namespace DoIt.Client.Services.Ideas
{
	public class IdeaServiceMock : IIdeaService
	{
		public Task<IdeaDto> CreateAsync(IdeaCreateDto newIdea)
		{
			return Task.Run(() => new IdeaDto());
		}

		public Task DeleteAsync(long id)
		{
			return Task.CompletedTask;
		}

		public Task<IdeasDto> GetAllAsync()
		{
			return Task.Run(() => new IdeasDto());
		}

		public Task<IdeaDto> GetAsync(long id)
		{
			return Task.Run(() => new IdeaDto());
		}

		public Task PromoteAsync(long id)
		{
			return Task.CompletedTask;
		}
	}
}
