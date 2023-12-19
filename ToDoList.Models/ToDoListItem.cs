using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
