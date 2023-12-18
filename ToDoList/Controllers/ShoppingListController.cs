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
    }
}
