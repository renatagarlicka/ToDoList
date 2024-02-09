using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class DailyPlannerController : Controller
    {
        private readonly IPlannerRepository _plannerRepository;

        public DailyPlannerController(IPlannerRepository db)
        {
            _plannerRepository = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Planner item)
        {

            if (!Regex.IsMatch(item.Name, "^[a-zA-Z]+$"))
            {
                ModelState.AddModelError("Name", "Użyto złego formatu. Tylko litery");
            }

            if (ModelState.IsValid)
            {
                item.TypeOfPlanner = PlannerType.Daily;
                _plannerRepository.Add(item);
                _plannerRepository.Save();
                TempData["success"] = "Utworzono";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
