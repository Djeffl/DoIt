using System.Linq;
using System.Threading.Tasks;
using DoIt.Api.Dto.Request.Idea;
using DoIt.Api.Dto.Response.Ideas;
using DoIt.Api.Services.Idea;
using DoIt.Api.Services.Idea.Dto;
using Microsoft.AspNetCore.Mvc;

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

			return Ok(new GetIdeasResponseDto()
			{
				Data = result.Ideas.Select(x => new GetIdeaResponseDto()
				{
					Id = x.Id,
					Description = x.Description,
					Title = x.Title,
					CreatedAt = x.CreatedAt,
				}).ToList()
			});
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<GetIdeaResponseDto>> GetIdea([FromRoute] long id)
		{
			var result = await _ideaService.GetIdeaAsync(id);

			if (result == null)
			{
				return NotFound();
			}

			return new GetIdeaResponseDto()
			{
				Id = result.Id,
				Title = result.Title,
				Description = result.Description,
                CreatedAt = result.CreatedAt
			};

		}

		[HttpPost]
		public async Task<ActionResult<GetIdeaResponseDto>> CreateIdea(CreateIdeaRequestDto request)
		{
            if (request.Title == null)
			{
				return BadRequest($"{nameof(request.Title)} cannot be empty.");
			}
			var result = await _ideaService.CreateGoalAsync(new CreateIdeaDto
			{
				Title = request.Title,
				Description = request.Description,
			});

			return CreatedAtAction(nameof(GetIdea), new { id = result.Id },
				new GetIdeaResponseDto
				{
					Id = result.Id,
					Title = result.Title,
					Description = result.Description,
					CreatedAt = result.CreatedAt
				}
			);

		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult<GetIdeaResponseDto>> DeleteIdea([FromRoute]long id)
		{

			await _ideaService.DeleteIdeaAsync(id);

			return Ok();
		}

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<GetIdeaResponseDto>> UpdateIdea([FromRoute]long id, UpdateIdeaRequestDto request)
        {
            if (request.Title == null)
            {
                return BadRequest($"{nameof(request.Title)} cannot be empty.");
            }
            var result = await _ideaService.UpdateIdeaAsync(id, new UpdateIdeaDto
            {
                Title = request.Title,
                Description = request.Description,
            });

            return CreatedAtAction(nameof(GetIdea), new { id = result.Id },
                                   new GetIdeaResponseDto
                                   {
                                       Id = result.Id,
                                       Title = result.Title,
                                       Description = result.Description,
                                       CreatedAt = result.CreatedAt
                                   }
            );

        }

	}
}
