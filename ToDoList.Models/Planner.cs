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
        public PlannerType TypeOfPlanner { get; set; }
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
        public int DayNumber { get; set; }
        public PlannerMonthName PlannerMonth { get; set; }
        public PlannerYearName PlannerYear { get; set; }
        public PlannerDayName DayName { get; set; }

    }
    public enum PlannerType
    {
        Daily,
        Weekly,
        Monthly
    }

    public enum PlannerDayName
    {
        Poniedziałek,
        Wtorek,
        Środa,
        Czwartek,
        Piątek,
        Sobota,
        Niedziela
    }

    public enum PlannerMonthName
    {
        Styczeń,
        Luty,
        Marzec,
        Kwiecień,
        Maj,
        Czerwiec,
        Lipiec,
        Sierpień,
        Wrzesień,
        Październik,
        Listopad,
        Grudzień
    }

    public enum PlannerYearName
    {
        Option1 = 2024,
        Option2 = 2025,
        Option3 = 2026,
    }
}
