using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantMenu
{
    class Restaurant
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AK's Restaurants!");
            bool alwaysShow = true;
            Menu menu = new Menu(); // Create an instance of Menu class
            populateMenuItems(menu); //Populate Menu items

            do
            {
                int choiceIndex = displayChoices(); //Display Choices to the user

                if (choiceIndex == 1)
                {
                    menu.printMenuItems(); //Print all the Menu Items
                }
                else if (choiceIndex == 2)
                {
                    addMenuItem(menu); //Method to add Menu Item
                }
                else if (choiceIndex == 3)
                {
                    Console.WriteLine("Select the Menu from the list you want to remove:");
                    menu.printMenuItemsWithIds();
                    string inputId = Console.ReadLine();
                    int id = int.Parse(inputId);
                    menu.removeMenuItem(id);
                    menu.LastUpdated = DateTime.Now;

                    Console.WriteLine("Updated Menu: ");
                    menu.printMenuItems(); //Print all the Menu Items
                }
                else{
                    break;
                }
            } while (alwaysShow);
            
        }

        private static int displayChoices()
        {
            bool isValidChoice = false;
            int choiceIdx;
            do
            {
                Console.WriteLine("1 - View Menu");
                Console.WriteLine("2 - Add Menu");
                Console.WriteLine("3 - Remove Menu");
                Console.WriteLine("4 - Exit");

                string input = Console.ReadLine();

                choiceIdx = int.Parse(input);

                if (choiceIdx < 0 || choiceIdx > 4)
                {
                    Console.WriteLine("Invalid choices. Try again.");
                }
                else
                {
                    isValidChoice = true;
                }

            } while (!isValidChoice);

            return choiceIdx;

        }

        private static void populateMenuItems(Menu menu)
        {
            List<MenuItem> listMenuItems = new List<MenuItem>();
            MenuItem menuItem1 = new MenuItem(10.99, "Calamari", "Appetizer", DateTime.Now);
            MenuItem menuItem2 = new MenuItem(6.99, "Breadsticks", "Appetizer", DateTime.Now);
            MenuItem menuItem3 = new MenuItem(15.99, "Chicken Alfredo", "Main Course", DateTime.Now);
            MenuItem menuItem4 = new MenuItem(7.99, "Tiramisu", "Dessert", DateTime.Now);

            listMenuItems.Add(menuItem1);
            listMenuItems.Add(menuItem2);
            listMenuItems.Add(menuItem3);
            listMenuItems.Add(menuItem4);
            menu.LastUpdated = DateTime.Now;
            menu.SetMenuItems(listMenuItems);
        }

        private static void addMenuItem(Menu menu)
        {
            Console.WriteLine("Enter the following details:");
            Console.WriteLine("Description: ");
            string desc = Console.ReadLine();

            Console.WriteLine("Price: ");
            string strPrice = Console.ReadLine();
            double price = double.Parse(strPrice);

            Console.WriteLine("Choose the category: ");
            Console.WriteLine("1: Appetizer");
            Console.WriteLine("2: Main Course");
            Console.WriteLine("3: Dessert");
            string strCat = Console.ReadLine();
            int intCat = int.Parse(strCat);
            string category = "";
            if (intCat == 1)
            {
                category = "Appetizer";
            }
            else if (intCat == 2)
            {
                category = "Main Course";
            }
            else if (intCat == 3)
            {
                category = "Dessert";
            }

            MenuItem newItem = new MenuItem(price, desc, category, DateTime.Today);
            menu.addMenuItem(newItem);
            menu.LastUpdated = DateTime.Now;

            Console.WriteLine("Updated Menu: ");
            menu.printMenuItems(); //Print all the Menu Items
        }
    }
}
