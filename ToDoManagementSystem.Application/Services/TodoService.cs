using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Application.DTOs.Todo;
using ToDoManagementSystem.Application.Interfaces.Repositories;
using ToDoManagementSystem.Application.Interfaces.Services;
using ToDoManagementSystem.Core.Entities;

namespace ToDoManagementSystem.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly IEmployeeRepository _repo;
        public TodoService(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<TodoResponseDTO> CreateTodoAsync(TodoCreateRequestDTO request, string employeeId)
        {
            var existingEmployee = await _repo.GetByIdAsync(employeeId);
            if (existingEmployee == null)
            {
                throw new Exception("Employee doesn't exist");
            }
            var todo = new Todo
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Priority = request.Priority,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt= DateTime.UtcNow,

            };
            await _repo.AddEmployeeTodoAsync(employeeId,todo);
            var response = new TodoResponseDTO
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                DueDate = todo.DueDate,
                Priority= todo.Priority,
                Status = todo.Status,
            };
            return response;
        }

        public async Task DeleteTodoAsync(string employeeId, string todoId)
        {
            var existingEmployee = await _repo.GetByIdAsync(employeeId);
            if (existingEmployee == null)
            {
                throw new Exception("Employee doesn't exist");
            }
            var todos = existingEmployee.Todos;
            var todo = todos.FirstOrDefault(t => t.Id == todoId);
            if (todo == null)
            {
                throw new Exception("Todo doesn't exist");
            }
            await _repo.DeleteEmployeeTodoAsync(employeeId, todoId);
        }

        public async Task<List<TodoResponseDTO>> GetAllTodosAsync(string employeeId)
        {
            var existingEmployee = await _repo.GetByIdAsync(employeeId);
            if (existingEmployee == null)
            {
                throw new Exception("employee doesn't exist");
            }
            var todos = existingEmployee.Todos;
            if(todos == null)
            {
                throw new Exception("No todo items to show");
            }
            var todoResponse = todos.Select(todo => new TodoResponseDTO
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                DueDate = todo.DueDate,
                Priority = todo.Priority,
                Status = todo.Status,
            }).ToList();

            return todoResponse;
        }

        public async Task<TodoResponseDTO> UpdateTodoAsync(TodoUpdateRequestDTO request, string employeeId, string todoId)
        {
            var existingEmployee = await _repo.GetByIdAsync(employeeId);
            if(existingEmployee == null)
            {
                throw new Exception("Employee doesn't exist");
            }
            var todos = existingEmployee.Todos;
            var todo = todos.FirstOrDefault(t => t.Id == todoId);
            if (todo == null)
            {
                throw new Exception("todo doesn't exist");
            }
            todo.Title = request.Title ?? todo.Title;
            todo.Description = request.Description ?? todo.Description;
            todo.DueDate = request.DueDate ?? todo.DueDate;
            todo.Priority = request.Priority ?? todo.Priority;
            todo.Status = request.Status ?? todo.Status;
            todo.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateEmployeeTodoAsync(employeeId, todo);
            var response = new TodoResponseDTO
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                DueDate = todo.DueDate,
                Priority = todo.Priority,
                Status = todo.Status,
            };
            return response;

        }
    }
}
