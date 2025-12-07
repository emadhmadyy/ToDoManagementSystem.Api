using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Application.DTOs.Employee;
using ToDoManagementSystem.Application.Interfaces.Services;

namespace ToDoManagementSystem.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Task<EmployeeLoginRequestDTO> LoginEmployeeAsync(EmployeeLoginRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeRegisterResponseDTO> RegisterEmployeeAsync(EmployeeRegisterRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
