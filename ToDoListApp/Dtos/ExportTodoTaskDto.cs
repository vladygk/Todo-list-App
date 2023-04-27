using ToDoListApp.Models;

namespace ToDoListApp.Dtos
{
    public class ExportTodoTaskDto
    {

        public ExportTodoTaskDto(ToDoTask task)
        {
            
            Name = task.Name;
            Description = task.Description;
            CreatedOn = task.CreatedOn.ToString("d");
            Done = task.Done;
            CreatedBy = task.Assignment.CreatedBy;
            AssignedTo = task.Assignment.AssignedTo;
        }

        
        public string Name { get; set; } = null!;

        public string CreatedOn { get; set; }

        public bool Done { get; set; }

        public string Description { get; set; } = null!;

        public string CreatedBy { get; set; }

        public string AssignedTo { get; set; }
    }
}
