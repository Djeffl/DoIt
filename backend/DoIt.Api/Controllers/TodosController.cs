using DoIt.Api.Data;
using DoIt.Api.Domain;
using DoIt.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

using DoIt.Api.Services.Todo;
using DoIt.Api.Services.Todo.Dto;
using System.Collections.Generic;

namespace DoIt.Api.Controllers
{
	[Route("api/todos")]
	[ApiController]
	public class TodosController : ControllerBase
	{
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

		//[HttpPost]
		//[Route("")]
		//[ProducesResponseType(StatusCodes.Status201Created)]
		//[ProducesResponseType(StatusCodes.Status400BadRequest)]
		//public async Task<IActionResult> CreateTodo([FromBody] CreateTodo newTodo)
		//{
		//	var todo = new Todo()
		//	{
		//		Title = newTodo.Title,
		//		Description = newTodo.Description,
		//		CreatedAt = DateTime.UtcNow
		//	};

		//	context.Add(todo);
		//	await context.SaveChangesAsync();

		//	return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
		//}

		[HttpGet]
		[Route("{id:long}")]
		public async Task<ActionResult<GetTodoDto>> GetTodoById([FromRoute]long id)
        {
            var todo = await _todoService.GetTodoById(id);


			if (todo == null)
			{
				return NotFound();
			}


			return Ok(todo);
		}

		[HttpGet]
		[Route("")]
		public async Task<ActionResult<IEnumerable<GetTodoDto>>> GetTodos()
		{
			var todos = await _todoService.GetTodos();

			return Ok(todos);
		}

		//[HttpPatch]
		//[Route("{id}")]
		//public async Task<IActionResult> UpdateTodo(int id, [FromBody] UpdateTodo updateTodo)
		//{
		//	var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

		//	if (todo == null) return NotFound();

		//	if (updateTodo.IsFinished.HasValue)
		//	{
		//		todo.IsFinished = updateTodo.IsFinished.Value;
		//	}

		//	await context.SaveChangesAsync();

		//	return Ok(todo);
		//}

		//[HttpDelete]
		//[Route("{id}")]
		//public async Task<IActionResult> DeleteTodo(int id)
		//{
		//	var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

		//	if (todo == null) return NotFound();

		//	context.Remove(todo);

		//	await context.SaveChangesAsync();

		//	return Ok(todo);
		//}
	}
}
