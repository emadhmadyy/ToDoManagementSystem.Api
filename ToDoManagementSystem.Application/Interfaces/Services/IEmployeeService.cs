using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Application.DTOs.Employee;

namespace ToDoManagementSystem.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeRegisterResponseDTO> RegisterEmployee(EmployeeRegisterRequestDTO request);
        Task<EmployeeLoginRequestDTO> LoginEmployee(EmployeeLoginRequestDTO request);
    }
}
