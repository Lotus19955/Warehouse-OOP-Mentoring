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
            int vacancy = validationService.TrySetNumber(Console.ReadLine(), nameof(Warehouse.Vacancy)); 
            garage = new Warehouse(title, address, number, vacancy);
            return garage;
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
        /// <summary>
        /// Display to console information about object
        /// </summary>
        /// <param name="param">gets object parameters</param>
        public void Display(Warehouse garage)
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
