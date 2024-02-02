using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToDoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objToDoList = _unitOfWork.ToDoList.GetAll().Where(obj=>!obj.IsDone).ToList();
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoListItem item)
        {
            if (item.Name == "test")
            {
                ModelState.AddModelError("", "źle");
            }

            if (ModelState.IsValid)
            {
                
                _unitOfWork.ToDoList.Add(item);
                _unitOfWork.Save();
                TempData["success"] = "Utworzono";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(ToDoListItem item)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ToDoList.Update(item);
                _unitOfWork.Save();
                TempData["success"] = "Uaktualniono listę rzeczy do zrobienia";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var toDoListItemFromDb = _unitOfWork.ToDoList.Get(u => u.Id == id);
            if (toDoListItemFromDb == null)
            {
                return NotFound();
            }
            return View(toDoListItemFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            ToDoListItem obj = _unitOfWork.ToDoList.Get(c => c.Id == id);
            if(obj==null)
            {
                return NotFound();
            }
            _unitOfWork.ToDoList.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Usunięto";
            return RedirectToAction("Index");
        }

        public IActionResult Done(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            List<ToDoListItem> completedItems = _unitOfWork.ToDoList.GetAll().Where(item => item.IsDone).ToList();
            if (completedItems == null)
            {
                return NotFound();
            }
            return View(completedItems);
        }

        [HttpPost, ActionName("Done")]
        public IActionResult DonePOST(int? id)
        {
            ToDoListItem obj = _unitOfWork.ToDoList.Get(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.IsDone = true;
            _unitOfWork.ToDoList.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Przeniesiono do zakładki Zrobione";
            return RedirectToAction("Index");
        }

        public IActionResult ToDoDone()
        {
            List<ToDoListItem> completedItems = _unitOfWork.ToDoList.GetAll().Where(item => item.IsDone).ToList();
            return View(completedItems);
        }
        public IActionResult Back(int? id)
        {
            ToDoListItem obj = _unitOfWork.ToDoList.Get(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.IsDone = false;
            _unitOfWork.ToDoList.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Przeniesiono do zakładki Zrobione";
            return RedirectToAction("Index");
        }
    }
}
