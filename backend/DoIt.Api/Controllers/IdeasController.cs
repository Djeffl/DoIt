using System.Threading.Tasks;

using DoIt.Api.Services.Idea;
using DoIt.Interface.Ideas;

using Microsoft.AspNetCore.Mvc;

using CreateIdeaDto = DoIt.Interface.Ideas.CreateIdeaDto;

namespace DoIt.Api.Controllers
{
	[Route("api/ideas")]
	[ApiController]
	public class IdeasController : ControllerBase
	{
		private readonly IIdeaService _ideaService;

		public IdeasController(IIdeaService ideaService)
		{
			_ideaService = ideaService;
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetIdeas()
		{
			var result = await _ideaService.GetIdeasAsync();

            return Ok(result);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<IdeaDto>> GetIdea([FromRoute] long id)
		{
			var result = await _ideaService.GetIdeaAsync(id);

			if (result == null)
			{
				return NotFound();
			}

            return result;

        }

		[HttpPost]
		public async Task<ActionResult<IdeaDto>> CreateIdea(CreateIdeaDto idea)
		{
            var result = await _ideaService.CreateIdeaAsync(idea);

			return CreatedAtAction(nameof(GetIdea), new { id = result.Id }, result);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult> DeleteIdea([FromRoute]long id)
		{

			await _ideaService.DeleteIdeaAsync(id);

			return Ok();
		}

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<IdeaDto>> UpdateIdea([FromRoute]long id, UpdateIdeaDto idea)
        {
            var result = await _ideaService.UpdateIdeaAsync(id, idea);

            return CreatedAtAction(nameof(GetIdea), new { id = result.Id }, result);
        }

	}
}
