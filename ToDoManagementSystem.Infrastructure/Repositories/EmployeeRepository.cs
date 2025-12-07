using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Application.Interfaces.Repositories;
using ToDoManagementSystem.Core.Entities;

namespace ToDoManagementSystem.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task CreateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByEmailAsync(string employeeEmail)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
