using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManagementSystem.Application.Interfaces.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(string employeeId, string employeeEmail, string employeeName);
    }
}
