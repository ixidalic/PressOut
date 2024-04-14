using Assignment_2_test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Assignment_2_test
{
    class Program
    {
        static List<Bike> BikeInventory = new List<Bike>();
        static void Main(string[] args)
        {
            getInventory(); //call the method to get the bikes from the inventory file and store it in a list
            Menu(); // open th menu loop
        }
        static void getInventory() //method to get the bikes from the inventory file
        {
            Random random = new Random();
            //read the file into a text string
            string[] lines = System.IO.File.ReadAllLines(@"inventory.txt");

            int invCounter = 0;

            int invLength = lines.Length / 9; //works out the number of bikes in the inventory.txt file

            int bikeLabel = 0;

            for (int i = 0; i <= invLength; i++) //for each bike // USE THIS FOR ADDING with readline 
            {
                bikeLabel++;
                string make = lines[i + invCounter++]; //store the make
                string type = lines[i + invCounter++]; //store the type
                string model = lines[i + invCounter++]; //store the model
                int year = int.Parse(lines[i + invCounter++]); //store the year
                string wheelSize = lines[i + invCounter++]; //store the wheel size
                string frameType = lines[i + invCounter++]; //store the frame type
                int securityCode = int.Parse(lines[i + invCounter++]); //store the security code
                int inStock = random.Next(0, 2);

                Bike bk = new Bike(bikeLabel, make, type, model, year, wheelSize, frameType, securityCode, inStock); //create a new bike object with the details stored above
                
                BikeInventory.Add(bk); //add the bike to Bikes list
            }
        }
        static void itemEditMenu()
        {
            string[] listOptions = { "1.Add Item", "2.Edit Item", "3.Delete Item", "4.Back" }; // edit list array
            int selectedOptionIndex = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                for (int i = 0; i < listOptions.Length; i++)
                {
                    if (i == selectedOptionIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green; // selected option in green
                        Console.ForegroundColor = ConsoleColor.Black; // other options color
                    }

                    Console.WriteLine(listOptions[i]);
                    Console.ResetColor();
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOptionIndex = Math.Max(0, selectedOptionIndex - 1);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOptionIndex = Math.Min(listOptions.Length - 1, selectedOptionIndex + 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedOptionIndex == 0)
                    {
                        addItem();
                    }
                    else if (selectedOptionIndex == 1)
                    {
                        editItem();
                    }
                    else if (selectedOptionIndex == 2)
                    {
                        deleteItem();
                    }
                    else if (selectedOptionIndex == 3)
                    {
                        return;
                    }
                    //BikeInventory[2].Type = "Jeff"; prompt
                }
            }
        } // Edit Item Menu
        static void displayBikeList() //display the inventory (BikeInventory list) to the screen
        {
            Console.Clear();
            Console.WriteLine("{0,-5}\t {1,-10}\t {2,-10}\t {3,-10}\t {4,-10}\t {5,-10}\t {6}\t {7,-30}\t {8}", "Num", "Type", "Sec.Code", "Make", "Model", "Year", "Wheel Size", "Frame Type", "In Stock");
            foreach (Bike bk in BikeInventory)
            {
                string availability = (bk.InStock == 1) ? "Yes" : "Sold/Rented";
                Console.WriteLine("{0,-5}\t {1,-10}\t {2,-10}\t {3,-10}\t {4,-10}\t {5,-10}\t {6,-10}\t {7,-30}\t {8}\t ", bk.BikeLabel, bk.Type, bk.SecurityCode, bk.Make, bk.Model, bk.Year, bk.WheelSize, bk.FrameType, availability);
            }
            Console.ReadKey();
        }
        static void deleteItem() // delete a specific item 
        {
            Console.Write("Select the item number of the item to delete (or type 'C' to cancel): ");
            string delete = Console.ReadLine(); // read user input

            if (delete.ToLower() == "c") // cancel the delete operation
            {
                Console.WriteLine("Delete operation canceled.");
                Console.ReadKey(); // pause
                return; 
            }

            bool deleteB = true;
            int i;

            while (deleteB)
            {
                if (int.TryParse(delete, out i) && i > 0 && i <= BikeInventory.Count) // validates if the input is in the desired range
                {
                    i = int.Parse(delete);
                    Console.WriteLine($"Are you sure you want to delete item {i}? (Y/N)");
                    string delConfirmation = Console.ReadLine().ToLower();
                    if (delConfirmation == "y")
                    {
                        BikeInventory.RemoveAt(i - 1);
                        Console.WriteLine($"Item {i} deleted");
                        deleteB = false;
                        Console.ReadKey(); // pause
                        RearrangeBikeLabels();// Re-arranges the bike labels
                    }
                    else if (delConfirmation == "n")
                    {
                        Console.WriteLine("Delete operation canceled.");
                        deleteB = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter Y or N.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    delete = Console.ReadLine(); // if input not correct asks for a new one
                }
            }
        }
        static void editItem() // edit items
        {
        
                Console.WriteLine("Select the position of the bike to edit or type 'C' to cancel:");
                string userInput = Console.ReadLine().Trim();

                if (userInput.ToLower() == "c")
                {
                    Console.WriteLine("Edit operation canceled.");
                    return; // Cancel the edit operation and return to the main menu
                }

                if (int.TryParse(userInput, out int editChoice) && editChoice >= 1 && editChoice <= BikeInventory.Count) // validate input to be more than 1 and less than bike count
                {
                    Console.WriteLine($"Editing bike at position {editChoice}:");
                    Console.WriteLine("1. Edit Make");
                    Console.WriteLine("2. Edit Type");
                    Console.WriteLine("3. Edit Model");
                    Console.WriteLine("4. Edit Year");
                    Console.WriteLine("5. Edit Wheel Size");
                    Console.WriteLine("6. Edit Frame Type");
                    Console.WriteLine("7. Edit Security Code");
                    Console.WriteLine("8. Edit In Stock Status");
                    Console.WriteLine("9. Go Back");

                    Console.Write("Select an option: ");
                    int option;
                    if (int.TryParse(Console.ReadLine(), out option)) // edit options and select by number
                    {
                        switch (option)
                        {
                            case 1:
                                Console.Write("Enter the new make: "); // edit make
                                BikeInventory[editChoice - 1].Make = Console.ReadLine();
                                Console.WriteLine("Make updated successfully!");
                                break;
                            case 2:
                                Console.Write("Enter the new type: "); // edit type
                                BikeInventory[editChoice - 1].Type = Console.ReadLine();
                                Console.WriteLine("Type updated successfully!");
                                break;
                            case 3:
                                Console.Write("Enter the new model: "); // edit model
                                BikeInventory[editChoice - 1].Model = Console.ReadLine();
                                Console.WriteLine("Model updated successfully!");
                                break;
                            case 4:
                                Console.Write("Enter the new year: "); // edit year & validate
                                int year;
                                if (int.TryParse(Console.ReadLine(), out year) && year >= 1789 && year <= 2025)
                                {
                                    BikeInventory[editChoice - 1].Year = year;
                                    Console.WriteLine("Year updated successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid year. Please enter a valid year.");
                                }
                                break;
                            case 5:
                                Console.Write("Enter the new wheel size: "); // edit wheel size
                                BikeInventory[editChoice - 1].WheelSize = Console.ReadLine();
                                Console.WriteLine("Wheel size updated successfully!");
                                break;
                            case 6:
                                Console.Write("Enter the new frame type: "); // edit frame type
                                BikeInventory[editChoice - 1].FrameType = Console.ReadLine();
                                Console.WriteLine("Frame type updated successfully!");
                                break;
                            case 7:
                                Console.Write("Enter the new security code: "); // edit sec code and validate
                                int securityCode;
                                if (int.TryParse(Console.ReadLine(), out securityCode))
                                {
                                    BikeInventory[editChoice - 1].SecurityCode = securityCode;
                                    Console.WriteLine("Security code updated successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid security code. Please enter a valid security code.");
                                }
                                break;
                            case 8:
                                Console.Write("Enter the new in stock status (0 or 1): "); // edit in stock status
                                int inStock;
                                if (int.TryParse(Console.ReadLine(), out inStock) && (inStock == 0 || inStock == 1))
                                {
                                    BikeInventory[editChoice - 1].InStock = inStock;
                                    Console.WriteLine("In stock status updated successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid in stock status. Please enter either 0 or 1.");
                                }
                                break;
                            case 9: 
                                return; // Go back to the main menu
                            default:
                                Console.WriteLine("Invalid option. Please select a valid option."); // validate
                                break;

                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please select a valid option."); // validate
                    }
                }
                else
                {
                    Console.WriteLine("Invalid bike position. Please enter a valid position."); // validate
                }
            
        }
        static void addItem() // add new items
        {

            int bikeLabel = BikeInventory.Count + 1; // Incerases the bike label by 1
            string make; // Store the make
            string type; // Store the type
            string model; // Store the model
            int year = 0; // Store the year
            string wheelSize; // Store the wheel size
            string frameType; // Store the frame type
            int securityCode = 0; // Store the security code
            int inStock = 0; // Store the amount in stock

            Console.Write("Bike Make: "); // add make
            make = Console.ReadLine();

            Console.Write("Bike Type: "); // add type
            type = Console.ReadLine();

            Console.Write("Bike Model: "); // add model
            model = Console.ReadLine();

            Console.Write("Bike Year: ");// Input and validation for year
            string yearInput = Console.ReadLine();
            bool yearInputB = true;
            while (yearInputB)
            {
                if (int.TryParse(yearInput, out year) && year >= 1789 && year <= 2025)
                {
                    year = int.Parse(yearInput);
                    yearInputB = false;
                }
                else
                {
                    Console.WriteLine("Select a Valid Year:");
                    yearInput = Console.ReadLine();
                }
            }

            Console.Write("Bike Wheel Size: "); // add wheel size
            wheelSize = Console.ReadLine();

            Console.Write("Bike Frame Type: "); // add frame type
            frameType = Console.ReadLine();
 
            Console.Write("Bike Security Code: "); // input and validation for security code
            string codeInput = Console.ReadLine();
            bool codeInputB = true;
            while (codeInputB)
            {
                if (int.TryParse(codeInput, out securityCode)) 
                {
                    securityCode = int.Parse(codeInput);
                    codeInputB = false;
                }
                else
                {
                    Console.WriteLine("Select a valid Security Code:");
                    codeInput = Console.ReadLine();
                }
            }
            
            Console.Write("Bike Number in Stock, select 1 or 0: ");// Input and validation for inStock
            string stockInput = Console.ReadLine();
            bool stockInputB = true;
            while (stockInputB)
            {
                if (int.TryParse(stockInput, out inStock) && (inStock == 0 || inStock == 1))
                {
                    inStock = int.Parse(stockInput);
                    stockInputB = false;
                }
                else
                {
                    Console.WriteLine("Bike Number in Stock, select 1 or 0:");
                    stockInput = Console.ReadLine();
                }
            }

            Bike bk = new Bike(bikeLabel, make, type, model, year, wheelSize, frameType, securityCode, inStock); // add the new bike into inventory
            BikeInventory.Add(bk);

            Console.WriteLine("Bike added successfully!"); // confirm
            Console.ReadKey();
        }
        static void stockCount() // counts bikes in stock
        {
            int inStockCount = 0;
            foreach (Bike bk in BikeInventory)
            {
                if (bk.InStock == 1)
                {
                    inStockCount++;
                }
            }
            Console.WriteLine($"Number of bikes in stock: {inStockCount}");
            Console.ReadKey(); // pause and back to menu
        }
        static void RearrangeBikeLabels() // rearrange bikelabel when bike is deleted
        {
            for (int i = 0; i < BikeInventory.Count; i++)
            {
                BikeInventory[i].BikeLabel = i + 1;
            }
        }
    }
}