﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class ToDoListItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Nazwa zadania")]
        public string Name { get; set; }
        [MaxLength(60)]
        [DisplayName("Opis zadania")]
        public string Description { get; set; }
        [DisplayName("Czy zadanie zostało wykonane")]
        public bool IsDone { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
