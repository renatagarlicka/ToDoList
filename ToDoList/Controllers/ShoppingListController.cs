using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ShoppingListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<ShoppingList> objShoppingList = _unitOfWork.ShoppingLi.GetAll().ToList();
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
                _unitOfWork.ShoppingLi.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Utworzono";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(ShoppingList obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.ShoppingLi.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uaktualniono listę zakupów";
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

            ShoppingList? shoppingListFromDb = _unitOfWork.ShoppingLi.Get(u => u.Id == id);
            if(shoppingListFromDb == null)
            {
                return NotFound();
            }
            return View(shoppingListFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            ShoppingList obj = _unitOfWork.ShoppingLi.Get(c => c.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ShoppingLi.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Usunięto";
            return RedirectToAction("Index");
        }
    }
}
