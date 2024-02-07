using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.Repository.IRepository;

namespace ToDoList.Controllers
{
    public class PlannerController : Controller
    {
        private readonly IPlannerRepository _plannerRepository;

        public PlannerController(IPlannerRepository db)
        {
            _plannerRepository = db;
        }
        public IActionResult Index()
        {
            var objToDoList = _plannerRepository.GetAll().ToList();
            if (objToDoList != null && objToDoList.Any())
            {
                return View(objToDoList);
            }
            else
            {
                return View();
            }
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
