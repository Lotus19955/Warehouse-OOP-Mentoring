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
        private static Warehouse garage = null;
        private static WarehouseService service = new WarehouseService();
        private static void Main(string[] args)
        {
            service.CreateWarehouse(ref garage);
            Menu(garage);
            Console.ReadLine();
        }
        /// <summary>
        /// Object menu
        /// </summary>
        /// <param name="garage">object</param>
        public static void Menu(Warehouse garage)
        {
            while (true)
            { 
            Console.WriteLine();
            Console.WriteLine("\t Menu");
            Console.WriteLine("1 - Update menu");
            Console.WriteLine("2 - Display menu");
            Console.WriteLine("3 - Employee menu");
            Console.WriteLine("4 - Clear information about warehouse");
            Console.WriteLine("5 - Exit");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            Console.WriteLine();
                switch (number)
                {
                    case 1:
                        service.UpdateMenu(garage);
                        break;
                    case 2:
                        service.DisplayMenu(garage);
                        break;
                    case 3:
                        service.EmployeeMenu(garage);
                        break;
                    case 4:
                        service.ClearInfoAboutWarehouse(ref garage);
                        garage = service.CreateWarehouse(ref garage);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}