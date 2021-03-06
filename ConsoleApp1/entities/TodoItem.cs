﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1.entities
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Isim { get; set; }
        public DateTime Oluşturmatarihi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public int TodoId { get; set; }
    }
}
