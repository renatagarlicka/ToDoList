using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ToDoDone()
        {
            return View();
        }
    }
}
