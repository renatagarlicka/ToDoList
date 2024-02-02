using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;

namespace ToDoList.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IShoppingListRepository ShoppingLi { get; private set; }
        public IToDoListRepository ToDoList { get; private set; }
        public IPlannerRepository Planner { get; private set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ShoppingLi = new ShoppingListRepository(_db);
            ToDoList = new ToDoRepository(_db);
            Planner = new PlannerRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
