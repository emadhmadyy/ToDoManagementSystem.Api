using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManagementSystem.Application.DTOs.Employee
{
    public class EmployeeLoginRequestDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
