using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1.entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Isim { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public string Aciklama { get; set; }
        public int KullaniciId { get; set; }
    }
}
