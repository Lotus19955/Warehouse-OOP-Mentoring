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
        static void Main(string[] args)
        {
            Warehouse garage = new Warehouse(null, null, null);
            Menu(garage);
            Console.ReadLine();
        }
        /// <summary>
        /// Object menu
        /// </summary>
        /// <param name="sklad">object</param>
        public static void Menu(Warehouse garage)
        {
            Console.WriteLine();
            Console.WriteLine("\t Menu");
            Console.WriteLine("1 - Add information");
            Console.WriteLine("2 - Update menu");
            Console.WriteLine("3 - Display menu");
            Console.WriteLine("4 - Exit");
            Console.Write("Enter your choise: ");
            string  choise = Console.ReadLine();
            int.TryParse(choise,out int number);
            Console.WriteLine();
            switch (number)
            {
                case 1:
                    AddInformation(garage);
                    break;
                case 2:
                    UpdateInformation(garage);
                    break;
                case 3:
                    DisplayMenu(garage);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu(garage);
                    break;
            }
        }
        /// <summary>
        /// Create you own objects
        /// </summary>
        /// <returns>object</returns>
        public static Warehouse AddInformation(Warehouse garage)
        {
            string title = null;
            string address = null;
            string contactNumber = null;
            while (string.IsNullOrEmpty(title))
            {
                Console.Write("Enter 'Title' of warehouse: ");
                title = Console.ReadLine();
                if(string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("'Title' can not be empty");
                }
            }
            while (string.IsNullOrEmpty(address))
            {
                Console.Write("Enter 'Address' of warehouse: ");
                address = Console.ReadLine();
                if (string.IsNullOrEmpty(address))
                {
                    Console.WriteLine("'Address' can not be empty");
                }
            }
            while (string.IsNullOrEmpty(contactNumber))
            {
                Console.Write("Enter 'Contact number' of warehouse: ");
                contactNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(contactNumber))
                {
                    Console.WriteLine("'Contact number' can not be empty");
                }
            }
            garage = new Warehouse(title, address, contactNumber);
            Menu(garage);
            return garage;
        }
        /// <summary>
        /// Update information in object
        /// </summary>
        /// <param name="sklad">object</param>
        public static void UpdateInformation(Warehouse garage)
        {
            Console.WriteLine("\t Update Menu");
            Console.WriteLine("1 - Update 'Title'");
            Console.WriteLine("2 - Update 'Address'");
            Console.WriteLine("3 - Update 'Contact number'");
            Console.WriteLine("4 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    Console.Write("Enter new 'Title': ");
                    garage.Title = Console.ReadLine();
                    while (string.IsNullOrEmpty(garage.Title))
                    {
                        if (string.IsNullOrEmpty(garage.Title))
                        {
                            Console.WriteLine("New 'Title' can not be empty");
                            garage.Title = Console.ReadLine();
                        }
                    }
                    Menu(garage);
                    break;
                case 2:
                    Console.Write("Enter new 'Address': ");
                    garage.Address = Console.ReadLine();
                    while (string.IsNullOrEmpty(garage.Address))
                    {
                        if (string.IsNullOrEmpty(garage.Address))
                        {
                            Console.WriteLine("New 'Address' can not be empty");
                        }
                    }
                    Menu(garage);
                    break;
                case 3:
                    Console.Write("Enter new 'Contact number': ");
                    garage.ContactNumber = Console.ReadLine();
                    while (string.IsNullOrEmpty(garage.ContactNumber))
                    {
                        if (string.IsNullOrEmpty(garage.ContactNumber))
                        {
                            Console.WriteLine("New 'Address' can not be empty");
                        }
                    }
                    Menu(garage);
                    break;
                case 4:
                    Menu(garage);
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu(garage);
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Display menu'
        /// </summary>
        /// <param name="garage">object</param>
        public static void DisplayMenu(Warehouse garage)
        {
            Console.WriteLine("\t Display Menu");
            Console.WriteLine("1 - Display 'Title'");
            Console.WriteLine("2 - Display 'Address'");
            Console.WriteLine("3 - Display 'Contact number'");
            Console.WriteLine("4 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    DisplayTitle(garage);
                    Menu(garage);
                    break;
                case 2:
                    DisplayAddress(garage);
                    Menu(garage);
                    break;
                case 3:
                    DisplayContuctNumber(garage);
                    Menu(garage);
                    break;
                case 4:
                    Menu(garage);
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu(garage);
                    break;
            }
        }
    
        /// <summary>
        /// Display to console warehouse 'title'
        /// </summary>
        public static void DisplayTitle(Warehouse garage)
        {
            Console.WriteLine($"Warehouse title: '{garage.Title}'");
            Menu(garage);
        }
        /// <summary>
        /// Display to console warehouse 'adress'
        /// </summary>
        public static void DisplayAddress(Warehouse garage)
        {
            Console.WriteLine($"Warehouse address: {garage.Address}");
            Menu(garage);
        }
        /// <summary>
        /// Display to console warehouse 'contuct number'
        /// </summary>
        public static void DisplayContuctNumber(Warehouse garage)
        {
            Console.WriteLine($"Warehouse contuct number: {garage.ContactNumber}");
            Menu(garage);
        }
    }
}