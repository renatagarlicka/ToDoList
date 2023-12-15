using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class ShoppingListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
