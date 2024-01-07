using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class PlannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
            
        public IActionResult DailyPlanner()
        {
            return View();
        }

        public IActionResult WeeklyPlanner()
        {
            return View();
        }

        public IActionResult MonthlyPlanner()
        {
            return View();
        }
    }
}
