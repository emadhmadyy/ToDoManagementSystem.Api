using FluentValidation;
using ToDoManagementSystem.Application.DTOs.Employee;

namespace ToDoManagementSystem.Application.DTOValidators.Employee
{
    public class EmployeeLoginRequestDTOValidator : AbstractValidator<EmployeeLoginRequestDTO>
    {
        public EmployeeLoginRequestDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
