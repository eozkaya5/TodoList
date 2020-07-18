using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoList.Models;
using TodoList.Models.Context;
using TodoList.Models.Entites;

namespace TodoList.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TodoDbContext context)
        {
            _logger = logger;
            _context = context;
        }
    
        public IActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;

           // start();

            return View();
        }
        public IActionResult UserPage()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public void start()
        //{
        //    Todo1 todo = new Todo1();
        //    todo.Name = "Elif";
        //    todo.DateTime = DateTime.Now;
        //    _context.Todos.Add(todo);
        //    _context.SaveChanges();


        //}
    }
}
