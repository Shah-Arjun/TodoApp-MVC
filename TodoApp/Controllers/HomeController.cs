using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.Models;

namespace todobimal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ////ViewData approch
            //ViewData["Task"] = "Learn dot net";
            //ViewData["Description"] = "Geeting started in web development";
            //ViewData["Status"] = "Done";

            ////ViewBag approch
            //ViewBag.Task1 = "start project";
            //ViewBag.Description1 = "Start TODO list project";
            //ViewBag.Status1 = "In progress";

            ////ViewModel approch
            //var taskslist = new List<TasksList>
            //{
            //    new TasksList{ task = "learn dot net",
            //    Description = "starting my journey on web development",
            //    Status = "Done"},
            //    new TasksList{ task = "build a project",
            //    Description = "start a new todo list project",
            //    Status = "inprogress"},
            //    new TasksList{ task = "push to github",
            //    Description = "push to github",
            //    Status = "ToDo"},

            //};
            return View(new TasksList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
};