using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ToDoList.Models
{
    public class Planner
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Tytuł plannera")]
        public string Name { get; set; }
        [DisplayName("Typ plannera")]
        public PlannerType Type { get; set; }
        [DisplayName("Chces opcję poziom nastroju?")]
        public bool MoodOption { get; set; }
        [DisplayName("Chces opcję poziom produktywności?")]
        public bool ProductiveOption { get; set; }
        [DisplayName("Chces opcję Self-care?")]
        public bool SelfCareOption { get; set; }
        [DisplayName("Chces opcję lista do zrobienia?")]
        public bool ToDoOption { get; set; }
        [DisplayName("Chces opcję notatki?")]
        public bool NotesOption { get; set; }
        [DisplayName("Chces opcję motywacyjne cytaty?")]
        public bool QuotesOption { get; set; }

    }

    public enum PlannerType
    {
        Daily,
        Weekly,
        Monthly
    }
}
