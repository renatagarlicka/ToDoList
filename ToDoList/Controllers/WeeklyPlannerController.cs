using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class WeeklyPlannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WeeklyPlanner()
        {
            return View();
        }
    }
}
