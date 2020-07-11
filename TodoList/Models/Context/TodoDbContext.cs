using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models.Entites;
using TodoList.Models.ListViewModel;

namespace TodoList.Models.Context
{
    public class TodoDbContext :DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        { }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<ListStatus> ListStatuses { get; set; }
        public DbSet<Todo1> Todos { get; set; } 
    }
}
