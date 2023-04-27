using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Models;

[Table("ToDoTask")]
public  class ToDoTask
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
    [DisplayName("Created On")]
    public DateTime CreatedOn { get; set; }

    public bool Done { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    public int AssignmentId { get; set; }

    [ForeignKey("AssignmentId")]
    [InverseProperty("ToDoTasks")]
    public virtual Assignment Assignment { get; set; }


   
}
