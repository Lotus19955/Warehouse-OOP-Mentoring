using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Warehouse_infrastructure
{ 
    public class WarehouseService : EmployeeService, IService
    {
        private static ValidationService validationService = new ValidationService();
        private static Logger logger = new Logger();
        /// <summary>
        /// Create you warehouse objects
        /// </summary>
        /// <returns>object</returns>
        public Warehouse Create(ref Warehouse garage)
        {
            {
                Console.WriteLine("First you need to add information about warehouse");
                Console.Write($"Enter '{nameof(Warehouse.Title)}': ");
                string title = validationService.TrySetValue(Console.ReadLine(), nameof(Warehouse.Title));

                Console.Write($"Enter '{nameof(Warehouse.Address)}': ");
                string address = validationService.TrySetValue(Console.ReadLine(), nameof(Warehouse.Address));

                Console.Write($"Enter  'Contact {nameof(Warehouse.Contact_Number)}': ");
                string number = validationService.TrySetValue(Console.ReadLine(), nameof(Warehouse.Contact_Number));

                Console.Write($"Enter  '{nameof(Warehouse.Number_of_vacancy)}': ");
                int vacancy = validationService.TrySetNumber(Console.ReadLine(), nameof(Warehouse.Number_of_vacancy));
                garage = new Warehouse(title, address, number, vacancy);
                FolderService.SaveData(garage, @"D:\VS\Проекты\Warehouse-OOP-Mentoring\WarehouseData.dat");
                try
                {
                    logger.Log("New object 'garage' created");
                }
                catch (Exception ex)
                {
                    logger.Log(ex.Message);
                }
            }
            return garage;
        }
        /// <summary>
        /// Display to console information about object
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        public void Display(string param, string paramName)
        {
            Console.WriteLine($"Warehouse {paramName}: {param} ");
        }
        /// <summary>
        /// Display to console information about object
        /// </summary>
        /// <param name="param">gets object parameters</param>
        public void Display(Warehouse garage)
        {
            Console.WriteLine(garage.ToString());
        }
    }
}