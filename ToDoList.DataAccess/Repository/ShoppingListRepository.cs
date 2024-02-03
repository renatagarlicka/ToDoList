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

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
