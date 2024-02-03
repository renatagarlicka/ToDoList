using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository
{
    public class ToDoRepository:Repository<ToDoListItem>, IToDoListRepository
    {
        private readonly ApplicationDbContext _db;

        public ToDoRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
