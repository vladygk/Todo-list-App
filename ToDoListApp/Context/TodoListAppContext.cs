using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Context;

public  class TodoListAppContext : DbContext
{
    public TodoListAppContext()
    {
    }

    public TodoListAppContext(DbContextOptions<TodoListAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; } 

    public virtual DbSet<ToDoTask> ToDoTasks { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assignme__3214EC076ECE8BEF");
        });

        modelBuilder.Entity<ToDoTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ToDoTask__3214EC0776A48158");

            entity.HasOne(d => d.Assignment).WithMany(p => p.ToDoTasks).HasConstraintName("FK__ToDoTask__Assign__3A81B327");
        });

       
    }

   
}
