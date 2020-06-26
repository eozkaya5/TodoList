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
        public int ListID { get; set; }
        [Required(ErrorMessage = "Lütfen boş geçmeyiniz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen boş geçmeyiniz.")]
        public string ListName { get; set; }
        public int DateiID { get; set; }
        public int StatusID { get; set; }
     
        
    }
}
