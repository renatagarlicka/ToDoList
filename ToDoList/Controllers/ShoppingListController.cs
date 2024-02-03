using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListRepository _shoppingRepository;
        

        public ShoppingListController(IShoppingListRepository db)
        {
            _shoppingRepository = db;
        }

        public IActionResult Index()
        {
            var objShoppingList = _shoppingRepository.GetAll().ToList();
            if (objShoppingList != null && objShoppingList.Any())
            {
                return View(objShoppingList);
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
        public IActionResult Create(ShoppingList obj)
        {
            if (obj.Name == "test")
            {
                ModelState.AddModelError("", "źle");
            }

            if (ModelState.IsValid)
            {
                _shoppingRepository.Add(obj);
                _shoppingRepository.Save();
                TempData["success"] = "Utworzono";
                return RedirectToAction("Index");
            }

            return View();
        }

        //public IActionResult Edit(ShoppingList item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _shoppingRepository.Update(item);
        //        _shoppingRepository.Save();
        //        TempData["success"] = "Uaktualniono listę rzeczy do zrobienia";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        public IActionResult Edit(int? id)
        {
            var shoppingListFromDb = _shoppingRepository.Get(c => c.Id == id);

            if (id == null || id == 0)
            {
                return NotFound();
            }

            if (shoppingListFromDb == null)
            {
                return NotFound();
            }

            return View(shoppingListFromDb);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPOST(ShoppingList obj)
        {

            if (ModelState.IsValid)
            {
                _shoppingRepository.Update(obj);
                _shoppingRepository.Save();                
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

            var shoppingListFromDb = _shoppingRepository.Get(u => u.Id == id);
            if (shoppingListFromDb == null)
            {
                return NotFound();
            }
            return View(shoppingListFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _shoppingRepository.Get(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _shoppingRepository.Delete(obj);
            _shoppingRepository.Save();
            TempData["success"] = "Usunięto";
            return RedirectToAction("Index");
        }
    }
}
