using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Migrations;

namespace TodoList.Models.ListViewModel
{
    public class Todo
    {
        [Key]
        public int ID { get; set; }      
        public string Hood { get; set; }
        public DateTime DateFormation { get; set; }
        public int ListID { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public int StatusID { get; set; }
        public string ShowHomePage { get; set; }


    }
}
