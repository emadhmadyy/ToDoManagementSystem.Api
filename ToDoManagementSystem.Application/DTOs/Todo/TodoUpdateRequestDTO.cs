using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Core.Enums;

namespace ToDoManagementSystem.Application.DTOs.Todo
{
    public class TodoUpdateRequestDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DueDate { get; set; }
        public int? Priority { get; set; }
        public TodoStatus? Status { get; set; } 
    }
}
