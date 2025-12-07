using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Application.DTOs.Employee;
using ToDoManagementSystem.Application.Interfaces.Repositories;
using ToDoManagementSystem.Application.Interfaces.Security;
using ToDoManagementSystem.Application.Interfaces.Services;
using ToDoManagementSystem.Core.Entities;

namespace ToDoManagementSystem.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IPasswordHasher _passwordHasher;

        public EmployeeService(IEmployeeRepository repo, IPasswordHasher passwordHasher)
        {
            _repo = repo;
            _passwordHasher = passwordHasher;
        }

        public async Task<EmployeeLoginResponseDTO> LoginEmployeeAsync(EmployeeLoginRequestDTO request)
        {
            var existingEmployee = await _repo.GetByEmailAsync(request.Email);
            if (existingEmployee == null)
            {
                throw new Exception("Employee with this email doesn't exist");
            }
            bool isPasswordVerified = _passwordHasher.VerifyPassword(request.Password, existingEmployee.Password);
            if (!isPasswordVerified)
            {
                throw new Exception("Invalid Credintials");
            }
            var response = new EmployeeLoginResponseDTO
            {
                Id = existingEmployee.Id,
                Name = existingEmployee.Name,
                Email = existingEmployee.Email,
                Token = "test token"
            };
            return response;
        }

        public async Task<EmployeeRegisterResponseDTO> RegisterEmployeeAsync(EmployeeRegisterRequestDTO request)
        {
            var existingEmployee = await _repo.GetByEmailAsync(request.Email);
            if (existingEmployee != null)
            {
                throw new Exception("Employee with this email already exists");
            }
            var hashedPassword = _passwordHasher.HashPassword(request.Password);
            var employee = new Employee
            {
                Name = request.Name,
                Email = request.Email,
                Password = hashedPassword,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            await _repo.CreateEmployeeAsync(employee);

            var response = new EmployeeRegisterResponseDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                CreatedAt = employee.CreatedAt,
            };
            return response;
        }
    }
}
