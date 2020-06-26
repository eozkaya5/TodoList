using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models.ListViewModel
{
    public class Date
    {
        [Key]
        public string DateID { get; set; }
        [Required(ErrorMessage = "Lütfen boş geçmeyiniz.")]
        public DateTime StarTime { get; set; }
        [Required(ErrorMessage = "Lütfen boş geçmeyiniz.")]
        public DateTime EndTime { get; set; }
    }
}
