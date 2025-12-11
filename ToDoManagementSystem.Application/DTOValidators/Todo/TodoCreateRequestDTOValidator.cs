using FluentValidation;
using ToDoManagementSystem.Application.DTOs.Todo;

namespace ToDoManagementSystem.Application.DTOValidators.Todo
{
    public class TodoCreateRequestDTOValidator: AbstractValidator<TodoCreateRequestDTO>
    {
        public TodoCreateRequestDTOValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
            RuleFor(x => x.DueDate).NotEmpty().WithMessage("DueDate is required")
                .Must(x =>
                {
                    return DateTime.TryParse(x, out var dueDate) && dueDate > DateTime.Now;
                }).WithMessage("DueDate must be a valid future date");

            RuleFor(x => x.Priority).NotEmpty().WithMessage("Priority is required").InclusiveBetween(1, 3).WithMessage("Priority must be between 1 and 3");
        }
    }
}
