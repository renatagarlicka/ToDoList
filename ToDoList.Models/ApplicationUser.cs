﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surrname { get; set; }

        public ICollection<ToDoListItem> ToDoLists { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}