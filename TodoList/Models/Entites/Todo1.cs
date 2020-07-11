using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models.Entites
{
    public class Todo1
    {
        [Key]
        public int TodoId { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }



    }
}

