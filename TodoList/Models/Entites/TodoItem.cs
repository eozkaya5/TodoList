﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models.Entites
{
    public class TodoItem
    {
        [Key]
        public int ItemId { get; set; }
        public int ListId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DataTime { get; set; }
        public int StatusId { get; set; }
        public DateTime Date { get; set; }
      
       
    }
}