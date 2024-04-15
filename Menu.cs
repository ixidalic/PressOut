using System;

namespace Assignment_2_test
{
    internal class Menu
    {
        private static void Main() // Entry point of the application
        {
            Console.CursorVisible = false; // Hide the cursor
            DisplayMenu();
        }

        private static void DisplayMenu()
        {
            string[] menuOptions = { "1. List Items", "2. Edit Items", "3. Stock Count", "4. Exit" }; // Menu option list array
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
                    switch (selectedOptionIndex)
                    {
                        case 0:
                            DisplayBikeList();
                            break;
                        case 1:
                            ItemEditMenu();
                            break;
                        case 2:
                            StockCount();
                            break;
                        case 3:
                            return; // Exit program
                    }
                }
            }
        }

        private static void DisplayBikeList()
        {
            // Implement logic for displaying bike list
        }

        private static void ItemEditMenu()
        {
            // Implement logic for item edit menu
        }

        private static void StockCount()
        {
            // Implement logic for stock count
        }
    }
}
