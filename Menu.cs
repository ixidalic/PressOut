using System;

namespace Assignment_2_test
{
    internal class Menu
    {
        public static void ShowMenu()
        {
            Console.CursorVisible = false; // Hide the cursor

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
                        Program.displayBikeList(); // go to display bike list
                    }
                    else if (selectedOptionIndex == 1)
                    {
                        Program.itemEditMenu(); // go to edit menu
                    }
                    else if (selectedOptionIndex == 2)
                    {
                        Program.stockCount(); // go to stock count
                    }
                    else if (selectedOptionIndex == 3)
                    {
                        break; // Exit program
                    }
                }
            }
        }
    }
}
