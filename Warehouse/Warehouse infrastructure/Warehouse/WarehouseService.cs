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
        private FolderService folderService = new FolderService();
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
        public Warehouse Create(Warehouse garage)
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
                Dictionary<string, List<Message>> mailBox = new Dictionary<string, List<Message>>();
                garage = new Warehouse(title, address, number, vacancy, mailBox);
                folderService.SaveData(garage, nameof(Warehouse));
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
        public void UpdateTitle(Warehouse garage)
        {
            Console.Write("Enter new 'Title': ");
            garage.Title = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Title));
            folderService.SaveData(garage, nameof(Warehouse));
        }
        /// <summary>
        /// Update address
        /// </summary>
        public void UpdateAddress(Warehouse garage)
        {
            Console.Write("Enter new 'Address': ");
            garage.Address = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Address));
            folderService.SaveData(garage, nameof(Warehouse));
        }
        /// <summary>
        /// Update number
        /// </summary>
        public void UpdateNumber(Warehouse garage)
        {
            Console.Write("Enter new 'Contact number': ");
            garage.Contact_Number = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Contact_Number));
            folderService.SaveData(garage, nameof(Warehouse));
        }
        /// <summary>
        /// Update vacancy
        /// </summary>
        public void UpdateVacancy(Warehouse garage)
        {
            Console.Write("Enter new number of free 'Vacancy': ");
            int vacancy = validationService.TrySetNumber(Console.ReadLine(), nameof(garage.Number_of_vacancy));
            garage.UpdateVacancy(vacancy);
            folderService.SaveData(garage, nameof(Warehouse));
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