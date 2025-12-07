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
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
    }
}
