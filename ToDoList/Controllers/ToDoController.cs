using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoListRepository _toDoListRepository;
        public ToDoController(IToDoListRepository db)
        {
            _toDoListRepository = db;
        }

        public IActionResult Index()
        {
            var objToDoList = _toDoListRepository.GetAll().ToList();
            if (objToDoList != null && objToDoList.Any())
            {
                return View(objToDoList);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Create()
        {
            var taskProgressValues = Enum.GetValues(typeof(TaskProgress))
                                 .Cast<TaskProgress>()
                                 .Select(v => new SelectListItem
                                 {
                                     Text = v.ToString(),
                                     Value = ((int)v).ToString()
                                 });

            ViewBag.TaskProgressValues = new SelectList(taskProgressValues, "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoListItem item)
        {

            if (!Regex.IsMatch(item.Name, "^[a-zA-Z]+$"))
            {
                ModelState.AddModelError("Name", "Użyto złego formatu. Tylko litery");
            }

            if (ModelState.IsValid)
            {

                _toDoListRepository.Add(item);
                _toDoListRepository.Save();
                TempData["success"] = "Utworzono";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {

            var taskProgressValues = Enum.GetValues(typeof(TaskProgress))
                                  .Cast<TaskProgress>()
                                  .Select(v => new SelectListItem
                                  {
                                      Text = v.ToString(),
                                      Value = ((int)v).ToString()
                                  });

            ViewBag.TaskProgressValues = new SelectList(taskProgressValues, "Value", "Text");


            var obj = _toDoListRepository.Get(c => c.Id == id);

            if (id == null || id == 0)
            {
                return NotFound();
            }

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPOST(ToDoListItem obj)
        {

            if (ModelState.IsValid)
            {
                _toDoListRepository.Update(obj);
                _toDoListRepository.Save();
                TempData["success"] = "Uaktualniono";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var toDoListItemFromDb = _toDoListRepository.Get(u => u.Id == id);
            if (toDoListItemFromDb == null)
            {
                return NotFound();
            }
            return View(toDoListItemFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            ToDoListItem obj = _toDoListRepository.Get(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _toDoListRepository.Delete(obj);
            _toDoListRepository.Save();
            TempData["success"] = "Usunięto";
            return RedirectToAction("Index");
        }

        public IActionResult Done(int? id)
        {

            var obj = _toDoListRepository.Get(c => c.Id == id);

            if (id == null || id == 0)
            {
                return NotFound();
            }

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Done")]
        public IActionResult DonePOST(int? id)
        {
            ToDoListItem obj = _toDoListRepository.Get(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.IsDone = true;
            obj.Progress = TaskProgress.Done;
            _toDoListRepository.Update(obj);
            _toDoListRepository.Save();
            TempData["success"] = "Przeniesiono do zakładki Zrobione";
            return RedirectToAction("Index");
        }

        public IActionResult ToDoDone()
        {

            var objToDoList = _toDoListRepository.GetAll().Where(obj => obj.IsDone).ToList();


            if (objToDoList != null && objToDoList.Any())
            {
                return View(objToDoList);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Back(int? id)
        {
            ToDoListItem obj = _toDoListRepository.Get(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.IsDone = false;
            _toDoListRepository.Update(obj);
            _toDoListRepository.Save();
            TempData["success"] = "Przeniesiono do zakładki Zrobione";
            return RedirectToAction("Index");
        }
    }
}

