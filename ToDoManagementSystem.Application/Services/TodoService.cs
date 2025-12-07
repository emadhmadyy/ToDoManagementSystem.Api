using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Application.DTOs.Todo;
using ToDoManagementSystem.Application.Interfaces.Services;

namespace ToDoManagementSystem.Application.Services
{
    public class TodoService : ITodoService
    {
        public Task<TodoResponseDTO> CreateTodoAsync(TodoCreateRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTodoAsync(string EmployeeId, string TodoId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoResponseDTO>> GetAllTodosAsync(string EmployeeId)
        {
            throw new NotImplementedException();
        }

        public Task<TodoResponseDTO> UpdateTodoAsync(TodoUpdateRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
