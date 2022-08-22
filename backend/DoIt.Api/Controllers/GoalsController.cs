using System;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Api.Dto.Request;
using DoIt.Api.Dto.Response.Goals;
using DoIt.Api.Extensions;
using DoIt.Api.Services.Goal;
using DoIt.Api.Services.Goal.Dto;
using DoIt.Api.Services.Todo;
using DoIt.Api.Services.Todo.Dto;
using DoIt.Interface.Goals;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoIt.Api.Controllers
{
    [Route("api/goals")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;
        private readonly ITodoService _todoService;

        /// <summary>
        /// C'tor
        /// </summary>
        public GoalsController(IGoalService goalService, ITodoService todoService)
        {
            _goalService = goalService;
            _todoService = todoService;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<GoalsDto>> GetGoalsAsync()
        {
            var result = await _goalService.GetGoalsAsync(new GetGoalsDto());

            return result;
        }

        [HttpGet]
        [Route("{id}")]
        [ActionName(nameof(GetGoalAsync))]
        public async Task<ActionResult<GoalDto>> GetGoalAsync([FromRoute] long id)
        {
            var result = await _goalService.GetGoalAsync(id);

            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<GoalDto>> CreateGoalAsync(CreateGoalRequest request)
        {
            //var isParsed = Enum.TryParse<GoalType>(request.Name, ignoreCase: true, out var goalType);

            //if (!isParsed)
            //{
            //	return BadRequest();
            //}

            var result = await _goalService.CreateGoalAsync(
                new CreateGoalDto
                {
                    Title = request.Title,
                    Description = request.Description,
                    Location = request.Location,
                    Reason = request.Reason,
                    DueAt = request.DueAt,
                    //Name = goalType
                }
            );

            return CreatedAtAction(nameof(GetGoalAsync), new { id = result.Id }, result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGoalAsync([FromRoute] long id)
        {
            await _goalService.DeleteGoalAsync(id);

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<GoalDto>> UpdateGoalAsync([FromRoute] long id, UpdateGoalRequest request)
        {
            var result = await _goalService.UpdateGoalAsync(id, request);

            return Ok(result);
        }


        [HttpPost]
        [Route("{goalId:long}/todos")]
        [AllowAnonymous]
        public async Task<ActionResult<GoalResponseDto>> CreateGoalTodoAsync(long goalId, CreateTodoRequest request)
        {
            var result = await _todoService.CreateTodoAsync(new CreateTodoDto()
            {
                Title = request.Title,
                GoalId = goalId
            });

            var actionName = nameof(TodosController.GetTodoById);
            var controllerName = nameof(TodosController).ToControllerName();

            return CreatedAtAction(actionName, controllerName, new { id = result.Id }, result);
        }
    }
}
