using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Core.Entities;

namespace ToDoManagementSystem.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(string employeeId);
        Task<Employee> GetByEmailAsync(string employeeEmail);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(string employeeId, Employee employee);

        Task AddEmployeeTodoAsync(string employeeId, Todo todo);
        Task UpdateEmployeeTodoAsync(string employeeId, Todo todo);
        Task DeleteEmployeeTodoAsync(string employeeId, string todoId);

    }
}
