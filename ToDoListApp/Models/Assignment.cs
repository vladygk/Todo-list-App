using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Models;

[Table("Assignment")]
public  class Assignment
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    [DisplayName("Created by")]
    public string CreatedBy { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    [DisplayName("Assigned to")]
    public string AssignedTo { get; set; } = null!;

    [InverseProperty("Assignment")] public virtual ICollection<ToDoTask> ToDoTasks { get; set; } = null!;
}
