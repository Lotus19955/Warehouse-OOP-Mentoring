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
            Employee
        }
        private static ValidationService validationService = new ValidationService();
        private static BinaryFormatter Formatter = new BinaryFormatter();
        private static Logger logger = new Logger();
        string  savePath = @"D:\VS\Проекты\Warehouse-OOP-Mentoring\Store\";
        /// <summary>
        /// Save data to folder
        /// </summary>
        /// <param name="objectForSave">Witch object you need to save</param>
        /// <param name="folderForSave">Choose to what folder you need to save</param>
        public void SaveData<T>(T objectForSave, Folder folderForSave)
        {
            validationService.ValidationSavingPath(savePath);
            try
            {
                using (FileStream fs = new FileStream(savePath + $"{folderForSave}.txt", FileMode.OpenOrCreate))
                {
                    Formatter.Serialize(fs, @objectForSave);
                }
                logger.Log(AppConstants.Alert.OBJECT_SAVED,LogLevel.Information);
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message,LogLevel.Error);
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
                logger.Log(ex.Message,LogLevel.Error);
            }
        }
        /// <summary>
        /// Download data from folder
        /// </summary>
        /// <param name="objectForSave">Witch object you need to download</param>
        /// <param name="downloadFolder">Choose from what folder you need to download</param>
        public void DownloadWarehouseData(ref Warehouse objectForSave, Folder downloadFolder)
        {
            validationService.ValidationSavingPath(savePath);
            using (FileStream fs = new FileStream(savePath + $"{downloadFolder}.txt", FileMode.OpenOrCreate))
            {
                if (File.Exists(savePath + $"{downloadFolder}.txt") && fs.Length > 0)
                {
                    objectForSave = (Warehouse)Formatter.Deserialize(fs);
                    objectForSave = new Warehouse(objectForSave.Title, objectForSave.Address, objectForSave.Contact_Number, objectForSave.Number_of_vacancy);
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
                objectForSave.Employee = new Employee[0];
            }
            using (FileStream fs = new FileStream(savePath + $"{downloadFolder}.txt", FileMode.OpenOrCreate))
            if (File.Exists(savePath + $"{downloadFolder}.txt") && fs.Length > 0)
            {
                Employee[] savedEmployee = (Employee[])Formatter.Deserialize(fs);
                foreach (Employee p in savedEmployee)
                {
                    validationService.Resize(objectForSave, 1);
                    objectForSave.Employee[objectForSave.Employee.Length - 1] = new Employee(p.Name, p.Surname, p.Age, p.Job, p.Address, p.Contact_Number, p.Education);
                    objectForSave.UpdateVacancy(objectForSave.Number_of_vacancy - 1);
                }
            }
        }
    }
}