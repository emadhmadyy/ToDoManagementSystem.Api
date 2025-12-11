using FluentValidation;
using ToDoManagementSystem.Application.DTOs.Employee;

namespace ToDoManagementSystem.Application.DTOValidators.Employee
{
    public class EmployeeRegisterRequestDTOValidator: AbstractValidator<EmployeeRegisterRequestDTO>
    {
        public EmployeeRegisterRequestDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(8).WithMessage("Password must be at least 8 characters")
                    .Matches(@"[A-Z]").WithMessage("Password must include at least on uppercase letter")
                    .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                    .Matches(@"\d").WithMessage("Password must contain at least one number")
                    .Matches(@"[@$!%*?&]").WithMessage("Password must contain at least one special character");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required")
                .Equal(x => x.Password).WithMessage("Confirm Password must match Password");
        }
    }
}
