using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantMenu
{
    class Menu
    {
        private List<MenuItem> listMenuItems = new List<MenuItem>();
        public DateTime LastUpdated { get; set; }
        private static int menuId = 1;
        public List<MenuItem> GetMenuItems()
        {
            return this.listMenuItems;
        }
        public void SetMenuItems(List<MenuItem> lstMenuItems)
        {
            this.listMenuItems = lstMenuItems;
        }

        public MenuItem GetMenuItem()
        {

            return listMenuItems.FirstOrDefault();
        }

        public void addMenuItem(MenuItem menuItem)
        {
            listMenuItems.Add(menuItem);
            //Add the menuItem to menuItems;
        }

        public void removeMenuItem(int menuId)
        {
            foreach (MenuItem item in this.listMenuItems)
            {
                if(item.MenuId == menuId)
                {
                    listMenuItems.Remove(item);
                    break;
                }
            }
            
        }


        public Boolean isEqual(MenuItem menuItem1, MenuItem menuItem2)
        {
            if(menuItem1.MenuId == menuItem2.MenuId)
            {
                return true;
            }

            return false;
        }

        public static int getMenuId()
        {
            return menuId++;
        }

        public void printMenuItems()
        {
            Console.WriteLine("Description | Price | Category");
            Console.WriteLine("--------------------------------------");
            foreach (MenuItem item in this.listMenuItems)
            {
                bool isNew = item.IsNew();
                if (isNew)
                {
                    Console.WriteLine(item.Description + " | " + item.Price + " | " + item.Category +"-- Newly Added");
                } else
                {
                    Console.WriteLine(item.Description + " | " + item.Price + " | " + item.Category);
                }
                
            }
            
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Last Updated : " + LastUpdated +"\n");
        }

        public void printMenuItemsWithIds()
        {
            foreach (MenuItem item in this.listMenuItems)
            {
                Console.WriteLine(item.MenuId +":"+ item.Description);
            } 
        }

        public bool isItemPresentInList(string desc)
        {
            foreach (MenuItem item in this.listMenuItems)
            {
                if(item.Description == desc)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
