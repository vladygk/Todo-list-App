using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoListApp.Context;
using ToDoListApp.Models;

namespace ToDoListApp.Services;

public class TodoListService : ITodoListService
{
    private readonly TodoListAppContext _db;
    public TodoListService(TodoListAppContext db)
    {
        _db = db;
    }

    [HttpGet]
    public List<ToDoTask> GetAllTasks()
    {
        
       return _db.ToDoTasks.ToList();
    }

    [HttpPost]
    public async Task<bool> CreateTask(ToDoTask task)
    {
        _db.ToDoTasks.Add(task);

        await _db.SaveChangesAsync();

        return true;
    }

    [HttpGet]
    public async Task<ToDoTask> GetOne(int id)
    {
        var taskToGet = await _db.ToDoTasks.FindAsync(id);

        return taskToGet;
    }

    [HttpPost]
    public async Task<bool> UpdateOne(ToDoTask task)
    {
        
        _db.ToDoTasks.Update(task);

         await _db.SaveChangesAsync();

         return true;
    }

    [HttpDelete]
    public async Task<bool> DeleteOne(ToDoTask task)
    {
        _db.Remove(task);

         await _db.SaveChangesAsync();

         return true;
    }
}

