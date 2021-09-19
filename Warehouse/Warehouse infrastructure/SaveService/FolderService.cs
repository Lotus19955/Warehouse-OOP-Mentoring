using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Configuration;

namespace Warehouse_infrastructure
{
    public class FolderService
    {/// <summary>
     /// Choose name of file to save data
     /// </summary>
        public enum Folder
        {
            Warehouse = 1,
            Employee,
            MailBox, 
        }
        private static ValidationService validationService = new ValidationService();
        private static BinaryFormatter Formatter = new BinaryFormatter();
        private static Logger logger = new Logger();
        private static WarehouseService warehouseService = new WarehouseService();
        string savePath = @"D:\VS\Проекты\Warehouse-OOP-Mentoring\Store\";
        /// <summary>
        /// Save data to folder
        /// </summary>
        /// <param name="objectForSave">Witch object you need to save</param>
        /// <param name="folderForSave">Choose to what folder you need to save</param>
        public void SaveData<T>(T objectForSave, Folder folderForSave , string folder = null)
        {
            if (folder != null)
            {
                savePath = savePath + $@"{folder}\";
            }
            validationService.ValidationSavingPath(savePath);
            try
            {
                using (FileStream fs = new FileStream(savePath + $"{folderForSave}.txt", FileMode.OpenOrCreate))
                {
                    Formatter.Serialize(fs, @objectForSave);
                }
                logger.Log(AppConstants.Alert.OBJECT_SAVED, LogLevel.Information);
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message, LogLevel.Error);
            }
        }
        /// <summary>
        /// Save data to folder
        /// </summary>
        /// <param name="objectForSave">Witch object you need to save</param>
        /// <param name="folderForSave">Choose to what folder you need to save</param>
        public void SaveData<T>(T[] objectForSave, Folder folderForSave)
        {
            validationService.ValidationSavingPath(savePath);
            try
            {
                using (FileStream fs = new FileStream(savePath + $"{folderForSave}.txt", FileMode.OpenOrCreate))
                {
                    Formatter.Serialize(fs, objectForSave);
                }
                logger.Log(AppConstants.Alert.OBJECT_SAVED, LogLevel.Information);
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message, LogLevel.Error);
            }
        }
        /// <summary>
        /// Download data from folder
        /// </summary>
        /// <param name="objectForSave">Witch object you need to download</param>
        /// <param name="downloadFolder">Choose from what folder you need to download</param>
        public void DownloadWarehouseData(ref Warehouse objectForSave, Folder downloadFolder)
        {
            try
            {
                validationService.ValidationSavingPath(savePath);
                using (FileStream fs = new FileStream(savePath + $"{downloadFolder}.txt", FileMode.OpenOrCreate))
                {
                    if (File.Exists(savePath + $"{downloadFolder}.txt") && fs.Length > 0)
                    {
                        objectForSave = (Warehouse)Formatter.Deserialize(fs);
                        objectForSave = new Warehouse(objectForSave.Title, objectForSave.Address, objectForSave.Contact_Number, objectForSave.Number_of_vacancy, objectForSave.MailBox);
                    }
                }
            }
            catch(Exception)
            {
                if (objectForSave == null)
                {
                    warehouseService.Create(ref objectForSave);
                }
                DownloadWarehouseData(ref objectForSave, downloadFolder);
            }
        }
        /// <summary>
        /// Download data from folder
        /// </summary>
        /// <param name="objectForSave">Witch object you need to download</param>
        /// <param name="downloadFolder">Choose from what folder you need to download</param>
        public void DownloadMailData(Dictionary<Guid,Message> objectForSave, Folder downloadFolder)
        {
            validationService.ValidationSavingPath(savePath);
            using (FileStream fs = new FileStream(savePath + $"{downloadFolder}.txt", FileMode.OpenOrCreate))
            {
                if (File.Exists(savePath + $"{downloadFolder}.txt") && fs.Length > 0)
                {
                    objectForSave = (Dictionary<Guid,Message>)Formatter.Deserialize(fs);
                }
            }
        }
        /// <summary>
        /// Download data from folder
        /// </summary>
        /// <param name="objectForSave">Witch object you need to download</param>
        /// <param name="downloadFolder">Choose from what folder you need to download</param>
        public void DownloadEmployeeData(Warehouse objectForSave, Folder downloadFolder)
        {
            validationService.ValidationSavingPath(savePath);
            if (!validationService.ValidationEmployee(objectForSave))
            {
                objectForSave.Employee = new List<Employee>();
            }
            using (FileStream fs = new FileStream(savePath + $"{downloadFolder}.txt", FileMode.OpenOrCreate))
            if (File.Exists(savePath + $"{downloadFolder}.txt") && fs.Length > 0)
            {
                List<Employee> savedEmployee = (List<Employee>)Formatter.Deserialize(fs);
                foreach (Employee p in savedEmployee)
                {
                    objectForSave.Employee.Add(new Employee(p.Name, p.Surname, p.Age, p.Job, p.Address, p.Contact_Number, p.Education));
                    objectForSave.UpdateVacancy(objectForSave.Number_of_vacancy - 1);
                }
            }
        }
    }
}