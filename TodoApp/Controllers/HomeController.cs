using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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
            //return View(new TasksList());
            if (Request.Method == "POST")
            {
                var tlist = new TasksList
                {
                    Task = Request.Form["task"],
                    Description = Request.Form["description"],
                    Status = Request.Form["status"]
                };
                
Console.WriteLine(tlist);
                _context.TaskList.Add(tlist);
                _context.SaveChanges();
                Console.WriteLine("Form Submitted");
            }
            var tasklist = _context.TaskList.ToList();
            return View(tasklist);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
};