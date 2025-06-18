using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TaskController : Controller
    {
        private static List<Task> tasks = new();

        public IActionResult index()
        {
            return Json(tasks);
        }
    }
}