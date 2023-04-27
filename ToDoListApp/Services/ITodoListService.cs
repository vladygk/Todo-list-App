using ToDoListApp.Models;

namespace ToDoListApp.Services;

public interface ITodoListService
{
    List<ToDoTask> GetAllTasks();
    
    Task<bool> CreateTask(ToDoTask task);

    Task<ToDoTask> GetOne(int  id);

    Task<bool> UpdateOne(ToDoTask task);

    Task<bool> DeleteOne(ToDoTask task); 

}