using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class DailyPlannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
