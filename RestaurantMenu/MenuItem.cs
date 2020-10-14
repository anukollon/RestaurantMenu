using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantMenu
{
    class MenuItem
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime DateCreated { get; set; }
        public int MenuId { get; }

        public MenuItem(double price, string description, string category, DateTime dateCreated)
        {
            Price = price;
            Description = description;
            Category = category;
            DateCreated =dateCreated;
            MenuId = Menu.getMenuId();
        }
      public bool IsNew()
        {
            //Check for DateCreated and return true/false based on a condition
            if(DateCreated == DateTime.Today)
            {
                return true;
            }
            return false;
        }
    }
}
