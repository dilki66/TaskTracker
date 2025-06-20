using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private static List<TaskItem> tasks = new();

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateTaskRequest request)
        {
            var newTask = new TaskItem
            {
                Id = tasks.Count + 1,
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false
            };

            tasks.Add(newTask);
            return Ok(newTask);
        }

        [HttpPut("complete/{id}")]
        public IActionResult Complete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            task.IsCompleted = true;
            return Ok(task);
        }

    [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            tasks.Remove(task);
            return Ok(new { message = "Deleted successfully" });
        }


    }
}