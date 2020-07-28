
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoList.Models.Context;
using TodoList.Models.Entites;

namespace TodoList.Controllers
{
    [Authorize]
    public class TodoItemController : Controller
    {
        public readonly TodoDbContext _context;
        public TodoItemController(TodoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var item = Tuple.Create<TodoItem,IEnumerable<TodoItem>>(new TodoItem(), _context.TodoItems.Include(x => x.Todo).Where(x => x.TodoId == id).ToList());
            return View(item);
        }
        [HttpGet]
        public IActionResult Create()
        {            
            //List<SelectListItem> model = (from x in _context.Todos.ToList()
            //                              select new SelectListItem
            //                              {
            //                                  Text = x.Name,
            //                                  Value = x.Id.ToString()
            //                              }).ToList();
            //ViewBag.value = model;
            //ViewData["model"] = "model";
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Route("/test/elif/itemekle/{abc?}")]
        //public ActionResult ItemEkle([FromForm]TodoItem todoItem, string abc)
        public IActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                todoItem.TodoId = _context.Todos.First().Id;
                //var item = _context.Todos.Where(x => x.Id == todoItem.Todo.Id).FirstOrDefault();
                //    todoItem.Todo = item;
                todoItem.Status = false; 
                return RedirectToAction("Index");
            }
            return View(todoItem);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _context.TodoItems.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(TodoItem todoItem)
        {
            _context.Entry(todoItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.TodoItems.Update(todoItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
      
        public IActionResult Delete(int id)
        {
            var item = _context.TodoItems.Where(x => x.Id == id).FirstOrDefault();
            _context.TodoItems.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}