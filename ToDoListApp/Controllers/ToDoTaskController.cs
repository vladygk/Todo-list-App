using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;
using ToDoListApp.Services;

namespace ToDoListApp.Controllers
{
    public class ToDoTaskController : Controller
    {

        private readonly ITodoListService _todoListService;

        public ToDoTaskController(ITodoListService todoListService)
        {

            _todoListService = todoListService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = _todoListService.GetAllTasks();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ToDoTask task)
        {
            if (task == null )
            {
                return BadRequest();
            }
            await _todoListService.CreateTask(task);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var taskToEdit = await _todoListService.GetOne(Id);

            if (taskToEdit == null)
            {
                return NotFound();
            }

            return View(taskToEdit);
        }

        [HttpPost]
      
        public async Task<IActionResult> Edit(ToDoTask task)
        {

            if (task == null )
            {
                return BadRequest();
            }

            await _todoListService.UpdateOne(task);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = await _todoListService.GetOne(id);

            if (taskToDelete == null )
            {
                return BadRequest();
            }

            await _todoListService.DeleteOne(taskToDelete);

            return RedirectToAction("Index");
        }


    }
}
