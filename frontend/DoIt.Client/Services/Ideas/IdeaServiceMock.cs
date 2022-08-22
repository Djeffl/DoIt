using System.Threading.Tasks;

using DoIt.Interface.Ideas;

namespace DoIt.Client.Services.Ideas
{
	public class IdeaServiceMock : IIdeaService
	{
		public Task<IdeaDto> CreateAsync(CreateIdeaDto newIdea)
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

        public Task<IdeaDto> UpdateIdeaAsync(long ideaId, UpdateIdeaDto idea)
        {
            return Task.Run(() => new IdeaDto());
		}
    }
}
