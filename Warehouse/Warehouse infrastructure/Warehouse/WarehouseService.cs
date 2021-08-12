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
        private static ValidationService<object> validationService = new ValidationService<object>();
        private static Logger logger = new Logger();
        private FolderService<object> folderService = new FolderService<object>();
        public enum NameToChange
        {
            Title = 1,
            Address,
            Number,
            Vacancy
        }
        /// <summary>
        /// Create you warehouse objects
        /// </summary>
        /// <returns>object</returns>
        public Warehouse Create(ref Warehouse garage)
        {
            try
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
                folderService.SaveData(garage,FolderService<object>.Folder.Warehouse);
                logger.Log(AppConstants.Alert.NEW_OBJECT_WAREHOUSE_CREATED, LogLevel.Information);
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message,LogLevel.Error);
            }
            return garage;
        }
        /// <summary>
        /// Update title
        /// </summary>
        public Warehouse UpdateTitle(ref Warehouse garage)
        {
            Console.Write("Enter new 'Title': ");
            garage.Title = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Title));
            folderService.SaveData(garage, FolderService<object>.Folder.Warehouse);
            return garage;
        }
        /// <summary>
        /// Update address
        /// </summary>
        public Warehouse UpdateAddress(ref Warehouse garage)
        {
            Console.Write("Enter new 'Address': ");
            garage.Address = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Address));
            folderService.SaveData(garage, FolderService<object>.Folder.Warehouse);
            return garage;
        }
        /// <summary>
        /// Update number
        /// </summary>
        public Warehouse UpdateNumber(ref Warehouse garage)
        {
            Console.Write("Enter new 'Contact number': ");
            garage.Contact_Number = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Contact_Number));
            folderService.SaveData(garage, FolderService<object>.Folder.Warehouse);
            return garage;
        }
        /// <summary>
        /// Update vacancy
        /// </summary>
        public Warehouse UpdateVacancy(ref Warehouse garage)
        {
            Console.Write("Enter new number of free 'Vacancy': ");
            int vacancy = validationService.TrySetNumber(Console.ReadLine(), nameof(garage.Number_of_vacancy));
            garage.UpdateVacancy(vacancy);
            folderService.SaveData(garage, FolderService<object>.Folder.Warehouse);
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