using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagementSystem.Core.Enums;

namespace ToDoManagementSystem.Core.Entities
{
    public class Todo
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public TodoStatus Status { get; set; } = TodoStatus.Pending;

    }
}
