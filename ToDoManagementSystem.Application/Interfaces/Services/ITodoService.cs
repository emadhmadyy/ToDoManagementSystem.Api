using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Application.DTOs.Todo;

namespace ToDoManagementSystem.Application.Interfaces.Services
{
    public interface ITodoService
    {
        Task<TodoResponseDTO> CreateTodoAsync(TodoCreateRequestDTO request);
        Task<TodoResponseDTO> UpdateTodoAsync(TodoUpdateRequestDTO request);
        Task<List<TodoResponseDTO>> GetAllTodosAsync(string EmployeeId);
        Task DeleteTodoAsync(string EmployeeId, string TodoId);
    }
}
