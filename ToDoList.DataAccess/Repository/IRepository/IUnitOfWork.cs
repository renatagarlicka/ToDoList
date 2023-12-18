using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IShoppingListRepository ShoppingLi { get; }

        void Save();
    }
}
