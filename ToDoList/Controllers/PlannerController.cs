using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

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
            var objWeekly = _plannerRepository.GetAll().ToList();
            if (objWeekly != null && objWeekly.Any())
            {
                return View(objWeekly);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var plannerItemFromDb = _plannerRepository.Get(u => u.Id == id);
            if (plannerItemFromDb == null)
            {
                return NotFound();
            }
            return View(plannerItemFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Planner obj = _plannerRepository.Get(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _plannerRepository.Delete(obj);
            _plannerRepository.Save();
            TempData["success"] = "Usunięto";
            return RedirectToAction("Index");
        }

        public IActionResult MonthlyPlanner()
        {
            return View();
        }

        public IActionResult Create()
        {
            var dayNameValues = Enum.GetValues(typeof(PlannerDayName))
                                 .Cast<PlannerDayName>()
                                 .Select(v => new SelectListItem
                                 {
                                     Text = v.ToString(),
                                     Value = ((int)v).ToString()
                                 });

            ViewBag.dayNameValues = new SelectList(dayNameValues, "Value", "Text");

            var monthValues = Enum.GetValues(typeof(PlannerMonthName))
                                 .Cast<PlannerMonthName>()
                                 .Select(v => new SelectListItem
                                 {
                                     Text = v.ToString(),
                                     Value = ((int)v).ToString()
                                 });

            ViewBag.monthValues = new SelectList(monthValues, "Value", "Text");

            var yearValues = Enum.GetValues(typeof(PlannerYearName))
                                 .Cast<PlannerYearName>()
                                 .Select(v => new SelectListItem
                                 {
                                     Text = v.ToString(),
                                     Value = ((int)v).ToString()
                                 });

            ViewBag.yearValues = new SelectList(yearValues, "Text", "Value");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Planner item)
        {
            if (ModelState.IsValid)
            {
                _plannerRepository.Add(item);
                _plannerRepository.Save();
                TempData["success"] = "Utworzono";
                return RedirectToAction("WeeklyPlanner", "Planner");
            }

            return NotFound();
        }
    }
}
