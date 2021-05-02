using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_infrastructure;

namespace WarehouseOOPMentoring
{
    class Program
    {
        private static  Warehouse garage = null;
        private static void Main(string[] args)
        {
            CreateObject();
            Menu();
            Console.ReadLine();
        }
        /// <summary>
        /// Create you own objects
        /// </summary>
        /// <returns>object</returns>
        private static void CreateObject()
        {
            Console.WriteLine("First you need to add information about warehouse");
            Console.Write($"Enter '{nameof(garage.Title)}' of warehouse: "); 
            string title = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Title));

            Console.Write($"Enter '{nameof(garage.Address)}' of warehouse: ");
            string address = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Address));

            Console.Write($"Enter  'Contact {nameof(garage.Number)}' of warehouse: ");
            string number = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Number));

            garage = new Warehouse(title, address, number);
        }
        /// <summary>
        /// Object menu
        /// </summary>
        /// <param name="garage">object</param>
        private static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("\t Menu");
            Console.WriteLine("1 - Update menu");
            Console.WriteLine("2 - Display menu");
            Console.WriteLine("3 - Exit");
            Console.Write("Enter your choise: ");
            string  choise = Console.ReadLine();
            int.TryParse(choise,out int number);
            Console.WriteLine();
            switch (number)
            {
                case 1:
                    UpdateInformation(garage);
                    break;
                case 2:
                    DisplayMenu(garage);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu();
                    break;
            }
        }
        /// <summary>
        /// Update information in object
        /// </summary>
        /// <param name="garage">object</param>
        private static void UpdateInformation(Warehouse garage)
        {
            Console.WriteLine("\t Update Menu");
            Console.WriteLine($"1 - Update '{nameof(garage.Title)}'");
            Console.WriteLine($"2 - Update '{nameof(garage.Address)}'");
            Console.WriteLine($"3 - Update 'Contact {nameof(garage.Number)}'");
            Console.WriteLine("4 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    Console.Write("Enter new 'Title': ");
                    garage.Title = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Title));
                    Menu();
                    break;
                case 2:
                    Console.Write("Enter new 'Address': ");
                    garage.Address = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Address)); 
                    Menu();
                    break;
                case 3:
                    Console.Write("Enter new 'Contact number': ");
                    garage.Number = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Number));
                    Menu();
                    break;
                case 4:
                    Menu();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu();
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Display menu'
        /// </summary>
        /// <param name="garage">object</param>
        private static void DisplayMenu(Warehouse garage)
        {
            Console.WriteLine("\t Display Menu");
            Console.WriteLine($"1 - Display '{nameof(garage.Title)}'");
            Console.WriteLine($"2 - Display '{nameof(garage.Address)}'");
            Console.WriteLine($"3 - Display 'Contact {nameof(garage.Number)}'");
            Console.WriteLine("4 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    Display(garage.Title, nameof(garage.Title));
                    Menu();
                    break;
                case 2:
                    Display(garage.Address, nameof(garage.Address));
                    Menu();
                    break;
                case 3:
                    Display(garage.Number,nameof(garage.Number));
                    Menu();
                    break;
                case 4:
                    Menu();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu();
                    break;
            }
        }
        /// <summary>
        /// Display to console information about object
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        private static void Display(string param, string paramName)
        {
            Console.WriteLine($"Warehouse {paramName}: {param} ");
        }
        /// <summary>
        /// Check objects parameters for null or empty
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        /// <returns></returns>
        private static string ValidationForNullOrEmpty(string param, string paramName)
        {
            while (string.IsNullOrEmpty(param))
            {
                Console.WriteLine($"{paramName} can not be empty");
                Console.Write($"Enter '{paramName}' of warehouse: ");
                param = Console.ReadLine();
            }
            return param;
        }
    }
}