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
            Warehouse sklad = new Warehouse(null, null, 0);
            Menu(sklad);
            Console.ReadLine();
        }
        /// <summary>
        /// Object menu
        /// </summary>
        /// <param name="sklad">object</param>
        public static void Menu(Warehouse sklad)
        {
            Console.WriteLine();
            Console.WriteLine("\t Menu");
            Console.WriteLine("1 - Add information");
            Console.WriteLine("2 - Update information ");
            Console.WriteLine("3 - Display your 'Title'");
            Console.WriteLine("4 - Display your 'Address'");
            Console.WriteLine("5 - Display your 'Contact number'");
            Console.WriteLine("6 - Exit");
            Console.Write("Enter your choise: ");
            int choise = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (choise)
            {
                case 1:
                    AddInformation(sklad);
                    break;
                case 2:
                    UpdateInformation(sklad);
                    break;
                case 3:
                    DisplayTitle(sklad);
                    break;
                case 4:
                    DisplayAddress(sklad);
                    break;
                case 5:
                    DisplayContuctNumber(sklad);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
        /// <summary>
        /// Create you own objects
        /// </summary>
        /// <returns>object</returns>
        public static Warehouse AddInformation(Warehouse sklad)
        {
            Console.Write("Enter title of warehouse: ");
            string title = Console.ReadLine();

            Console.Write("Enter address of warehouse: ");
            string address = Console.ReadLine();

            Console.Write("Enter contact number of warehouse: ");
            int contactNumber = int.Parse(Console.ReadLine());

            sklad = new Warehouse(title, address, contactNumber);
            Menu(sklad);
            return sklad;
        }
        /// <summary>
        /// Update information in object
        /// </summary>
        /// <param name="sklad">object</param>
        public static void UpdateInformation(Warehouse sklad)
        {
            Console.WriteLine("\t Update Menu");
            Console.WriteLine("1 - Update 'Title'");
            Console.WriteLine("2 - Update 'Address'");
            Console.WriteLine("3 - Update 'Contact number'");
            Console.WriteLine("4 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    Console.Write("Enter new 'Title': ");
                    string title = Console.ReadLine();
                    sklad.Title = title;
                    Menu(sklad);
                    break;
                case 2:
                    Console.Write("Enter new 'Address': ");
                    string address = Console.ReadLine();
                    sklad.Address = address;
                    Menu(sklad);
                    break;
                case 3:
                    Console.Write("Enter new 'Contact number': ");
                    int contactNumber = int.Parse(Console.ReadLine());
                    sklad.ContactNumber = contactNumber;
                    Menu(sklad);
                    break;
                default:
                    Menu(sklad);
                    break;
            }
        }
        /// <summary>
        /// Display to console warehouse 'title'
        /// </summary>
        public static void DisplayTitle(Warehouse sklad)
        {
            Console.WriteLine($"Warehouse title: '{sklad.Title}'");
            Menu(sklad);
        }
        /// <summary>
        /// Display to console warehouse 'adress'
        /// </summary>
        public static void DisplayAddress(Warehouse sklad)
        {
            Console.WriteLine($"Warehouse address: {sklad.Address}");
            Menu(sklad);
        }
        /// <summary>
        /// Display to console warehouse 'contuct number'
        /// </summary>
        public static void DisplayContuctNumber(Warehouse sklad)
        {
            Console.WriteLine($"Warehouse contuct number: {sklad.ContactNumber}");
            Menu(sklad);
        }
    }
}