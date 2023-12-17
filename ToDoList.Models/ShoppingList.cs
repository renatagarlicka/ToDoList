﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ShoppingList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Nazwa Listy")]
        public string Name { get; set; }
        [MaxLength(100)]
        [DisplayName("Lista zakupów")]
        public string Description { get; set; }
    }
}
