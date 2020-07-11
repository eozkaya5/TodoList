using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Migrations;

namespace TodoList.Models.ListViewModel
{
    public class UserTodoList
    {
        [Key]
        public int ListID { get; set; }
        [Required(ErrorMessage = "Lütfen boş geçmeyiniz.")]
        public string Date { get; set; }
         

      

    }
}
