using Microsoft.AspNetCore.Mvc;
using ToDoManagementSystem.Application.DTOs.Employee;
using ToDoManagementSystem.Application.Interfaces.Services;

namespace ToDoManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController: ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(EmployeeRegisterRequestDTO request)
        {
            var response = await _employeeService.RegisterEmployeeAsync(request);
            return CreatedAtAction(nameof(Register), new { id = response.Id }, response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(EmployeeLoginRequestDTO request)
        {
            var response = await _employeeService.LoginEmployeeAsync(request);
            return Ok(response);
        }
    }
}
