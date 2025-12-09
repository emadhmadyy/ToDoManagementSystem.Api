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
        Task<TodoResponseDTO> CreateTodoAsync(TodoCreateRequestDTO request, string employeeId);
        Task<TodoResponseDTO> UpdateTodoAsync(TodoUpdateRequestDTO request, string employeeId, string todoId);
        Task<List<TodoResponseDTO>> GetAllTodosAsync(string employeeId);
        Task DeleteTodoAsync(string employeeId, string todoId);
    }
}
