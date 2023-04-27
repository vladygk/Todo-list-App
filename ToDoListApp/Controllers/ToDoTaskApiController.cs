using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoListApp.Dtos;
using ToDoListApp.Models;
using ToDoListApp.Services;

namespace ToDoListApp.Controllers
{



    [Route("api/")]
    [ApiController]
    public class ToDoTaskApiController : ControllerBase
    {
        private readonly ITodoListService _todoListService;


        private async Task<string> GetBody()
        {
            Request.EnableBuffering();

            Request.Body.Position = 0;

            var jsonBody = await new StreamReader(Request.Body).ReadToEndAsync();

            return jsonBody;
        }
        public ToDoTaskApiController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }


        [HttpGet("get")]
        public IActionResult Get()
        {
            var tasks = _todoListService.GetAllTasks();


            var tasksDtos = tasks.Select(t => new ExportTodoTaskDto(t));

            return Ok(tasksDtos);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var task = await _todoListService.GetOne(id);

            if (task == null)
            {
                return NotFound();
            }

            var taskDto = new ExportTodoTaskDto(task);

            return Ok(taskDto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {

            var jsonBody = await GetBody();

            ImportTodoTaskDto taskDto = JsonConvert.DeserializeObject<ImportTodoTaskDto>(jsonBody)!;

            ToDoTask task = new ToDoTask()
            {
                Name = taskDto.Name,
                Description = taskDto.Description,
                Done = taskDto.Done,
                CreatedOn = DateTime.Parse(taskDto.CreatedOn),
                Assignment = new Assignment()
                {
                    CreatedBy = taskDto.CreatedBy,
                    AssignedTo = taskDto.AssignedTo,
                }
            };

            await _todoListService.CreateTask(task);

            return Ok();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            string jsonBody = await GetBody();

            var toEdit = await _todoListService.GetOne(id);

            if (toEdit == null)
            {
                return NotFound();
            }

            ImportTodoTaskDto taskDto = JsonConvert.DeserializeObject<ImportTodoTaskDto>(jsonBody)!;

            toEdit.Name = taskDto.Name == toEdit.Name ? toEdit.Name : taskDto.Name;
            toEdit.Description = taskDto.Description == toEdit.Description ? toEdit.Description : taskDto.Description;
            toEdit.Done = taskDto.Done == toEdit.Done ? toEdit.Done : taskDto.Done;

            toEdit.CreatedOn = DateTime.Parse(taskDto.CreatedOn) == toEdit.CreatedOn ? toEdit.CreatedOn : DateTime.Parse(taskDto.CreatedOn);

            toEdit.Assignment.AssignedTo = taskDto.AssignedTo == toEdit.Assignment.AssignedTo ? toEdit.Assignment.AssignedTo : taskDto.AssignedTo;

            toEdit.Assignment.CreatedBy = taskDto.CreatedBy == toEdit.Assignment.CreatedBy ? toEdit.Assignment.CreatedBy : taskDto.CreatedBy;


            await _todoListService.UpdateOne(toEdit);

            return Ok();
        }

        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var toDelete = await _todoListService.GetOne(id);

            

            if (toDelete == null)
            {
                return NotFound();
            }

            await _todoListService.DeleteOne(toDelete);



            return NoContent();
        }
    }
}
