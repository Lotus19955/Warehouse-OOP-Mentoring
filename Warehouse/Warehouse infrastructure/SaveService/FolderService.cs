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
        public void SaveData<T>(T objectForSave, string folderForSave, string folder = null)
        {
            try
            {
                if (folder != null)
                {
                validationService.ValidationSavingPath(savePath + folder);
                    using (FileStream fs = new FileStream(savePath + $@"{folder}\" + $"{folderForSave}.txt", FileMode.OpenOrCreate))
                    {
                        Formatter.Serialize(fs, @objectForSave);
                    }
                    logger.Log(AppConstants.Alert.OBJECT_SAVED, LogLevel.Information);
                }
                else 
                {
                    validationService.ValidationSavingPath(savePath);
                    using (FileStream fs = new FileStream(savePath + $"{folderForSave}.txt", FileMode.OpenOrCreate))
                    {
                        Formatter.Serialize(fs, @objectForSave);
                    }
                    logger.Log(AppConstants.Alert.OBJECT_SAVED, LogLevel.Information);
                }
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
        public void SaveData<T>(T[] objectForSave, string folderForSave, string folder = null)
        {
            validationService.ValidationSavingPath(savePath);
            try
            {
                if (folder != null)
                {
                    validationService.ValidationSavingPath(savePath + folder);
                    using (FileStream fs = new FileStream(savePath + $@"{folder}\" + $"{folderForSave}.txt", FileMode.OpenOrCreate))
                    {
                        Formatter.Serialize(fs, @objectForSave);
                    }
                    logger.Log(AppConstants.Alert.OBJECT_SAVED, LogLevel.Information);
                }
                else
                {
                    validationService.ValidationSavingPath(savePath);
                    using (FileStream fs = new FileStream(savePath + $"{folderForSave}.txt", FileMode.OpenOrCreate))
                    {
                        Formatter.Serialize(fs, @objectForSave);
                    }
                    logger.Log(AppConstants.Alert.OBJECT_SAVED, LogLevel.Information);
                }
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
        public void DownloadWarehouseData(ref Warehouse objectForSave, string downloadFolder)
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
                DownloadWarehouseData(ref objectForSave, downloadFolder);
            }
        }
        /// <summary>
        /// Download data from folder
        /// </summary>
        /// <param name="objectForSave">Witch object you need to download</param>
        /// <param name="downloadFolder">Choose from what folder you need to download</param>
        public void DownloadMailData(Warehouse objectForSave, string downloadFolder, string folder = null)
        {
            string[] files = Directory.GetFiles(savePath + folder);
            for (int i = 0; i < files.Length; i++)
            {
                if (File.Exists(files[i]))
                {
                    using (FileStream fs = new FileStream(files[i], FileMode.OpenOrCreate))
                    {
                        Message savedMessage = (Message)Formatter.Deserialize(fs);
                        List<Message> listSavedMessage = new List<Message>();
                        listSavedMessage.Add(savedMessage);
                        objectForSave.MailBox.Add($"{savedMessage.id}", listSavedMessage);
                    }
                }
            }
        }
        /// <summary>
        /// Download data from folder
        /// </summary>
        /// <param name="objectForSave">Witch object you need to download</param>
        /// <param name="downloadFolder">Choose from what folder you need to download</param>
        public void DownloadEmployeeData(Warehouse objectForSave, string downloadFolder)
        {
            if (!validationService.ValidationEmployee(objectForSave.Employee))
            {
                objectForSave.Employee = new List<Employee>();
            }
            using (FileStream fs = new FileStream(savePath + $"{downloadFolder}.txt", FileMode.OpenOrCreate))
            if (File.Exists(savePath + $"{downloadFolder}.txt") && fs.Length > 0)
            {
                List<Employee> savedEmployee = (List<Employee>)Formatter.Deserialize(fs);
                foreach (Employee p in savedEmployee)
                {
                    objectForSave.Employee.Add(p);
                    objectForSave.UpdateVacancy(objectForSave.Number_of_vacancy - 1);
                }
            }
        }
    }
}