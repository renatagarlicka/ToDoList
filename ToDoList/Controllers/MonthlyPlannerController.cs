using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class MonthlyPlannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
