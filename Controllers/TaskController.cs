using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private static List<TaskItem> tasks = new List<TaskItem>();

        // Display the To-Do list
        public IActionResult Index()
        {
            return View(tasks);
        }

        // Add a new task
        [HttpPost]
        public IActionResult Add(string taskName, DateTime? taskDate)
        {
            if (string.IsNullOrEmpty(taskName))
            {
                TempData["ErrorMessage"] = "Task name cannot be empty!";
                return RedirectToAction("Index");
            }

            var task = new TaskItem
            {
                Id = tasks.Count + 1,
                TaskName = taskName,
                TaskDate = taskDate,
                IsCompleted = false,
                IsBeingEdited = false
            };

            tasks.Add(task);
            return RedirectToAction("Index");
        }

        // Mark a task as complete
        public IActionResult Complete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
            return RedirectToAction("Index");
        }

        // Edit a task (start editing)
        public IActionResult Edit(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsBeingEdited = true;
            }
            return RedirectToAction("Index");
        }

        // Save the edited task
        [HttpPost]
        public IActionResult SaveEdit(int id, string taskName)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null && !string.IsNullOrEmpty(taskName))
            {
                task.TaskName = taskName;
                task.IsBeingEdited = false;
            }
            return RedirectToAction("Index");
        }

        // Delete a task
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }
    }
}
