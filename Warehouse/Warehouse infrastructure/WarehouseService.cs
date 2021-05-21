using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class WarehouseService : EmployeeService
    {
        private static ValidationService validationService = new ValidationService();
        /// <summary>
        /// Create you warehouse objects
        /// </summary>
        /// <returns>object</returns>
        /// <returns>object</returns>
        public Warehouse CreateWarehouse(ref Warehouse garage)
        {
            Console.WriteLine("First you need to add information about warehouse");
            Console.Write($"Enter '{nameof(Warehouse.Title)}' of warehouse: ");
            string title = validationService.TrySetValue(Console.ReadLine(), nameof(Warehouse.Title));

            Console.Write($"Enter '{nameof(Warehouse.Address)}' of warehouse: ");
            string address = validationService.TrySetValue(Console.ReadLine(), nameof(Warehouse.Address));

            Console.Write($"Enter  'Contact {nameof(Warehouse.Number)}' of warehouse: ");
            string number = validationService.TrySetValue(Console.ReadLine(), nameof(Warehouse.Number));

            Console.Write($"Enter  numbers of free '{nameof(Warehouse.Vacancy)}' of warehouse: ");
            string freevacancy = validationService.TrySetValue(Console.ReadLine(), nameof(Warehouse.Vacancy));
            int.TryParse(freevacancy, out int vacancy);
            garage = new Warehouse(title, address, number, vacancy);
            return garage;
        }
        /// <summary>
        /// Update information in object
        /// </summary>
        /// <param name="garage">object</param>
        public void UpdateMenu(Warehouse garage)
        {
            Console.WriteLine("\t Update Menu");
            Console.WriteLine($"1 - Update '{nameof(garage.Title)}'");
            Console.WriteLine($"2 - Update '{nameof(garage.Address)}'");
            Console.WriteLine($"3 - Update 'Contact {nameof(garage.Number)}'");
            Console.WriteLine($"4 - Update number of free '{nameof(garage.Vacancy)}'");
            Console.WriteLine("5 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            Console.WriteLine();
            switch (number)
            {
                case 1:
                    Console.Write("Enter new 'Title': ");
                    garage.Title = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Title));
                    break;
                case 2:
                    Console.Write("Enter new 'Address': ");
                    garage.Address = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Address));
                    break;
                case 3:
                    Console.Write("Enter new 'Contact number': ");
                    garage.Number = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Number));
                    break;
                case 4:
                    Console.Write("Enter new number of free 'Vacancy': ");
                    int.TryParse(validationService.TrySetValue(Console.ReadLine(), nameof(garage.Vacancy)), out int vacancy);
                    garage.UptadeVacancy(vacancy);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Display menu'
        /// </summary>
        /// <param name="garage">object</param>
        public void DisplayMenu(Warehouse garage)
        {
            Console.WriteLine("\t Display Menu");
            Console.WriteLine($"1 - Display '{nameof(garage.Title)}'");
            Console.WriteLine($"2 - Display '{nameof(garage.Address)}'");
            Console.WriteLine($"3 - Display 'Contact {nameof(garage.Number)}'");
            Console.WriteLine($"4 - Display number of '{nameof(garage.Vacancy)}'");
            Console.WriteLine($"5 - Display all information");
            Console.WriteLine("6 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    Display(garage.Title, nameof(garage.Title));
                    break;
                case 2:
                    Display(garage.Address, nameof(garage.Address));
                    break;
                case 3:
                    Display(garage.Number, nameof(garage.Number));
                    break;
                case 4:
                    DisplayFreeVacancy(garage);
                    break;
                case 5:
                    Display(garage);
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
        /// <summary>
        /// Display to console information about object
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        public  void Display(string param, string paramName)
        {
            Console.WriteLine($"Warehouse {paramName}: {param} ");
        }
        public  void Display(Warehouse garage)
        {
            Console.Write($" Warehouse Title: {garage.Title}\t " +
                       $" Warehouse address: {garage.Address}\t " +
                       $" Warehouse number: {garage.Number}\t " +
                       $" Number of free vacancy:{garage.Vacancy}");
            Console.WriteLine("Information about empolees:");
            DisplayWarehouseEmployee(garage);
            Console.WriteLine();
        }
        /// <summary>
        /// Display to console informations about free vacancy 
        /// </summary>
        /// <param name="garage">object</param>
        public void DisplayFreeVacancy(Warehouse garage)
        {
            Console.WriteLine($"Number of free vacancy: {garage.Vacancy}");
        }
        /// <summary>
        /// Clear all information sbout warehouse and employees
        /// </summary>
        /// <param name="garage">object</param>
        /// <param name="employees">object</param>
        public void ClearInfoAboutWarehouse(ref Warehouse garage)
        {
            garage = null;
            Console.WriteLine("Clear info success");
        }
    }
}
