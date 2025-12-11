using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManagementSystem.Application.DTOs.Todo
{
    public class TodoCreateRequestDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string DueDate { get; set; } = null!;
        public int Priority { get; set; }
    }
}
