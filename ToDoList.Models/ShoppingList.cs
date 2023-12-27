using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class ShoppingList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Nazwa sklepu")]
        public string Name { get; set; }
        [MaxLength(100)]
        [DisplayName("Lista zakupów")]
        public string Description { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
