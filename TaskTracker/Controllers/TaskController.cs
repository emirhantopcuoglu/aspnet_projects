using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TaskController : Controller
    {
        private readonly Repository _repository;

        public TaskController()
        {
            _repository = new Repository();
        }

        public IActionResult Index()
        {
            var tasks = _repository.GetTasks();
            return View(tasks);
        }

        public IActionResult Details(int id)
        {
            var task = _repository.GetTaskById(id);
            if(task == null)
            {
                return View("Error");
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult CreateTask(Models.Task task)
        {   
            _repository.AddTask(task);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditTask(Models.Task task)
        {
            _repository.UpdateTask(task);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            _repository.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}