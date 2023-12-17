using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListRepository _shoppingRepo;
        public ShoppingListController(IShoppingListRepository db)
        {
            _shoppingRepo = db;
        }

        public IActionResult Index()
        {
            List<ShoppingList> objShoppingList = _shoppingRepo.GetAll().ToList();
            return View();
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
                _shoppingRepo.Add(obj);
                _shoppingRepo.Save();
                TempData["success"] = "Utworzono";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
