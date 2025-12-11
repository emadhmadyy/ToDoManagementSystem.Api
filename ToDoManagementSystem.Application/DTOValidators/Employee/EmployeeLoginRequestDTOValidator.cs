using FluentValidation;
using ToDoManagementSystem.Application.DTOs.Employee;

namespace ToDoManagementSystem.Application.DTOValidators.Employee
{
    public class EmployeeLoginRequestDTOValidator : AbstractValidator<EmployeeLoginRequestDTO>
    {
        public EmployeeLoginRequestDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(8).WithMessage("Password must be at least 8 characters")
                .Matches(@"[A-Z]").WithMessage("Password must include at least on uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"\d").WithMessage("Password must contain at least one number")
                .Matches(@"[@$!%*?&]").WithMessage("Password must contain at least one special character");
        }
    }
}
