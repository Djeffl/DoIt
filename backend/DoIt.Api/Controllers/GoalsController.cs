using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Api.Dto.Request;
using DoIt.Api.Dto.Response;
using DoIt.Api.Dto.Response.Goals;
using DoIt.Api.Services;
using DoIt.Api.Services.Goal.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoIt.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GoalsController : ControllerBase
	{
		private readonly IGoalService _goalService;

		/// <summary>
		/// C'tor
		/// </summary>
		public GoalsController(IGoalService goalService)
		{
			_goalService = goalService;
		}

		[HttpGet]
		[Route("")]
		[AllowAnonymous]
		public async Task<ActionResult<GoalsResponseDto>> GetGoals()
		{
			var result = await _goalService.GetGoalsAsync(new GetGoalsDto());

			if (result.Any())
			{
				var response = new GoalsResponseDto()
				{
					Data = result.Select(x => new GoalResponseDto
					{
						Title = x.Title,
						Description = x.Description,
					}).ToList()
				};

				return response;
			}

			return new GoalsResponseDto();
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<GoalResponseDto>> GetGoal([FromRoute] long id)
		{
			var result = await _goalService.GetGoalAsync(id);

			if (result != null)
			{
				return new GoalResponseDto
				{
					Title = result.Title,
					Description = result.Description,
				};
			}

			return NotFound();
		}

		[HttpPost]
		[Route("")]
		[AllowAnonymous]
		public async Task<ActionResult<GoalResponseDto>> CreateGoal(CreateGoalRequest request)
		{
			//var isParsed = Enum.TryParse<GoalType>(request.Type, ignoreCase: true, out var goalType);

			//if (!isParsed)
			//{
			//	return BadRequest();
			//}

			var result = await _goalService.CreateGoalAsync(
				new CreateGoalDto
				{
					Description = request.Description,
					DueAt = request.DueAt,
					Title = request.Title,
					//Type = goalType
				}
			);

			return CreatedAtAction(nameof(GetGoal), new { id = result.Id }, result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteGoal([FromRoute] long id)
		{
			Console.WriteLine("Removing data...");
			await _goalService.DeleteGoalAsync(id);

			return Ok();
		}

	}
}
