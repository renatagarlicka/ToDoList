using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ToDoList.Models
{
    public class ShoppingList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Nazwa sklepu")]
        public string? Name { get; set; }
        [MaxLength(100)]
        [DisplayName("Lista zakupów")]
        public string? Description { get; set; }       
    }
}
