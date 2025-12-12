using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManagementSystem.Application.DTOs.Employee
{
    public class EmployeeLoginResponseDTO
    {
        public string Name { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
