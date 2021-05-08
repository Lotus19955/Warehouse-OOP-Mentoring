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
            Console.WriteLine();
            Console.WriteLine("\t Menu");
            Console.WriteLine("1 - Update menu");
            Console.WriteLine("2 - Display menu");
            Console.WriteLine("3 - Clear information about warehouse");
            Console.WriteLine("4 - Add information about employee");
            Console.WriteLine("5 - Search employee");
            Console.WriteLine("6 - Remove employee");
            Console.WriteLine("7 - Exit");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            Console.WriteLine();
            switch (number)
            {
                case 1:
                    service.UpdateMenu(garage);
                    Menu(garage);
                    break;
                case 2:
                    service.DisplayMenu(garage);
                    Menu(garage);
                    break;
                case 3:
                    service.ClearInfoAboutWarehouse(ref garage);
                    Menu(garage);
                    break;
                case 4:
                    service.CreateEmployees(garage);
                    Menu(garage);
                    break;
                case 5:
                    service.SearchEmployeesByNameAndSurname(garage);
                    Menu(garage);
                    break;
                case 6:
                    service.RemoveEmployee(garage);
                    Menu(garage);
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu(garage);
                    break;
            }
        }
    }
}