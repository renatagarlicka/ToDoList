using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository
{
    public class PlannerRepository : Repository<Planner>, IPlannerRepository
    {
        private ApplicationDbContext _db;
        public PlannerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
              
    }
}
