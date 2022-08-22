using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;

using Newtonsoft.Json;

namespace DoIt.Client.Services.IdeaCategories
{
    public class CategoryService : ICategoryService
    {
        private readonly string baseUrl = "api/categories";
        private readonly HttpClient client;

        public CategoryService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto newCategory)
        {
            var response = await client.PostAsJsonAsync<CreateCategoryDto>(baseUrl, newCategory);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CategoryDto>(responseString);

            return result;
        }

        public async Task<CategoriesDto> CreateBulkAsync(CreateCategoryBulkDto newCategoryBulk)
        {
            var response = await client.PostAsJsonAsync<CreateCategoryBulkDto>($"{baseUrl}/bulk", newCategoryBulk);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CategoriesDto>(responseString);

            return result;
        }

        public async Task DeleteAsync(long id)
        {
            await client.DeleteAsync($"{baseUrl}/{id}");
        }

        public async Task<CategoriesDto> GetListAsync()
        {
            return await client.GetFromJsonAsync<CategoriesDto>(baseUrl);
        }
	}
}
