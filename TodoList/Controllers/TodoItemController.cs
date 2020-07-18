using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Context;
using TodoList.Models.Entites;

namespace TodoList.Controllers
{
    public class TodoItemController : Controller
    {
        private readonly TodoDbContext _context;        
        public TodoItemController( TodoDbContext context)
        {          
            _context = context;
        }
        public IActionResult Index()
        {
            var item = _context.TodoItems.ToList();
            return View(item);
            
        }      
        [HttpGet]
        public IActionResult Create(int id)
        {
            return View(new TodoItem { TodoId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                todoItem.Id = 0;
                todoItem.StatusId = _context.Statuses.First().Id;
                todoItem.DateTime = DateTime.Now;
                _context.TodoItems.Add(todoItem);
                _context.SaveChanges();
                return RedirectToAction("CreateList");

            }
            return View(todoItem);
        }
    }
}
