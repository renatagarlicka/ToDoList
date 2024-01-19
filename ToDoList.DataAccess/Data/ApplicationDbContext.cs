using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ToDoListItem> toDoListItems { get; set; }
        public DbSet<ShoppingList> shoppingList { get; set; }
        public DbSet<Planner> planner { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }

    }
}
