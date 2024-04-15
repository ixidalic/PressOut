using System;
using System.Collections.Generic;

namespace Assignment_2_test
{
    class Program
    {
        static List<Bike> BikeInventory = new List<Bike>();

        static void Main(string[] args)
        {
            getInventory(); // Call the method to load the inventory
            ShowMenu(); // Call the method to display the menu
        }

        static void ShowMenu()
        {
            string[] menuOptions = { "1.List Items", "2.Edit Items", "3.Stock Count", "4.Exit" }; // Menu option list array
            int selectedOptionIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedOptionIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green; // selected option in green
                        Console.ForegroundColor = ConsoleColor.Black; // other options color
                    }

                    Console.WriteLine(menuOptions[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(); // Menu functionality

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOptionIndex = Math.Max(0, selectedOptionIndex - 1);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOptionIndex = Math.Min(menuOptions.Length - 1, selectedOptionIndex + 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedOptionIndex == 0)
                    {
                        displayBikeList(); // go to display bike list
                    }
                    else if (selectedOptionIndex == 1)
                    {
                        itemEditMenu(); // go to edit menu
                    }
                    else if (selectedOptionIndex == 2)
                    {
                        stockCount(); // go to stock count
                    }
                    else if (selectedOptionIndex == 3)
                    {
                        break; // Exit program
                    }
                }
            }
        }

        static void getInventory()
        {
            // Your existing code for loading the inventory goes here
        }

        static void itemEditMenu()
        {
            // Your existing code for itemEditMenu goes here
        }

        static void displayBikeList()
        {
            // Your existing code for displayBikeList goes here
        }

        static void deleteItem()
        {
            // Your existing code for deleteItem goes here
        }

        static void editItem()
        {
            // Your existing code for editItem goes here
        }

        static void addItem()
        {
            // Your existing code for addItem goes here
        }

        static void stockCount()
        {
            // Your existing code for stockCount goes here
        }

        static void RearrangeBikeLabels()
        {
            // Your existing code for RearrangeBikeLabels goes here
        }
    }
}
