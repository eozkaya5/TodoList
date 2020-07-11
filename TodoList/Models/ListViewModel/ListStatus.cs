using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models.ListViewModel
{
    public class ListStatus
    {
        [Key]
        public string StatusID { get; set; }
        [Required(ErrorMessage = "Lütfen boş geçmeyiniz.")]
        public string Explanation { get; set; }
    }
}
