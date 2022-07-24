using System;

using DoIt.Client.Models.Ideas;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Client.Services.Ideas
{
	public class IdeaService : IIdeaService
	{
		private readonly string baseUrl = "api/ideas";
		private readonly HttpClient client;

		public IdeaService(HttpClient client)
		{
			this.client = client;
		}

		public async Task<IdeaDto> CreateAsync(IdeaCreateDto newIdea)
		{
			var response = await client.PostAsJsonAsync<IdeaCreateDto>(baseUrl, newIdea);
			var responseString = await response.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<IdeaDto>(responseString);

			return result;
		}

		public async Task DeleteAsync(long id)
		{
			await client.DeleteAsync($"{baseUrl}/{id}");
		}

		public async Task<IdeasDto> GetAllAsync()
		{
			return await client.GetFromJsonAsync<IdeasDto>(baseUrl);
		}

		public async Task<IdeaDto> GetAsync(long id)
		{
			return await client.GetFromJsonAsync<IdeaDto>($"{baseUrl}/{id}");
		}

		public async Task PromoteAsync(long id)
		{
			var json = JsonConvert.SerializeObject(new { });

			var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

			var response = await client.PatchAsync($"{baseUrl}/{id}", stringContent);

			if (!response.IsSuccessStatusCode)
			{
				throw new System.Exception("Promoting idea failed.");
			}
		}

        public async Task<IdeaDto> UpdateIdeaAsync(long ideaId, UpdateIdeaDto idea)
        {
            var json = JsonConvert.SerializeObject(idea);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await client.PatchAsync($"{baseUrl}/{ideaId}", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Updating idea failed.");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IdeaDto>(responseString);

            return result;
        }
    }
}
