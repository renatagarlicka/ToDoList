using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository
{
    public class ShoppingListRepository : Repository<ShoppingList>, IShoppingListRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingListRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
     
    }
}
