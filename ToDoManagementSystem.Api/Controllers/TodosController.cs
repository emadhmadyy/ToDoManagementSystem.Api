using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoManagementSystem.Application.DTOs.Todo;
using ToDoManagementSystem.Application.Interfaces.Services;

namespace ToDoManagementSystem.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/todos")]
    public class TodosController: ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var employeeId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(employeeId))
            {
                return Unauthorized();
            }
            var response = await _todoService.GetAllTodosAsync(employeeId);
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTodo(TodoCreateRequestDTO request)
        {
            var employeeId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(employeeId))
            {
                return Unauthorized();
            }
            var createdTodo = await _todoService.CreateTodoAsync(request, employeeId);
            if (createdTodo == null)
            {
                return BadRequest(new { message = "Todo could not be created." });
            }
            return Ok(createdTodo);

        }

        [HttpPut("update/{todoId}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] string todoId, [FromBody] TodoUpdateRequestDTO request)
        {
            var employeeId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (employeeId == null)
            {
                return Unauthorized();
            }
            var updatedTodo = await _todoService.UpdateTodoAsync(request, employeeId, todoId);
            if (updatedTodo == null)
                return NotFound();

            return Ok(updatedTodo);
        }

        [HttpDelete("delete/{todoId}")]
        public Task<IActionResult> DeleteTodo([FromRoute] string todoId)
        {
            var employeeId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (employeeId == null)
            {
                return Unauthorized();
            }
            var deleted = await _todoService.DeleteTodoAsync(employeeId, todoId);
            if (!deleted)
                return NotFound();

            return NoContent(); // 204, deletion succeeded
        }
    }
}
