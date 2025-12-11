using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ToDoManagementSystem.Application.DTOs.Todo;

namespace ToDoManagementSystem.Application.DTOValidators.Todo
{
    public class TodoUpdateRequestTDOValidator : AbstractValidator<TodoUpdateRequestDTO>
    {
        public TodoUpdateRequestTDOValidator()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("Title cannot be empty if provided")
                 .When(x => x.Title != null);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty if provided")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
                .When(x => x.Description != null);
            RuleFor(x => x.DueDate)
                 .Must(x => DateTime.TryParse(x, out var dueDate) && dueDate > DateTime.Now)
                 .WithMessage("DueDate must be a valid future date")
                 .When(x => !string.IsNullOrWhiteSpace(x.DueDate));

            RuleFor(x => x.Priority)
                .InclusiveBetween(1, 3).WithMessage("Priority must be between 1 and 3")
                .When(x => x.Priority.HasValue);
            RuleFor(x => x.Status)
               .IsInEnum()
               .WithMessage("Status must be Pending, InProgress, or Done")
               .When(x => x.Status.HasValue);
        }
    }
}
