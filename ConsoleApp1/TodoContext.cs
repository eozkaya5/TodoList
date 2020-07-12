using ConsoleApp1.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class TodoContext : DbContext
    {



        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ELIF_OZKAYA\\SQLEXPRESS;Initial Catalog=TestTodoDb;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
