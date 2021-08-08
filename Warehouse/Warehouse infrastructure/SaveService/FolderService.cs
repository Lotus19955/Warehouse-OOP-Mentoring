using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace Warehouse_infrastructure
{
    public static class FolderService
    {
        private static ValidationService validationService = new ValidationService();
        private static BinaryFormatter Formatter = new BinaryFormatter();
        public static void SaveData(Warehouse objectForSave, string folderForSave)
        {
            using (FileStream fs = new FileStream(folderForSave, FileMode.OpenOrCreate))
            {
                Formatter.Serialize(fs, @objectForSave);
            }
        }
        public static void SaveData(Employee[] arrObjectForSave, string folderForSave)
        {
            using (FileStream fs = new FileStream(folderForSave, FileMode.OpenOrCreate))
            {
                Formatter.Serialize(fs, arrObjectForSave);
            }
        }
        public static void UploadWarehouseData(ref Warehouse objectForSave, string folderForSave)
        {
            using (FileStream fs = new FileStream(folderForSave, FileMode.OpenOrCreate))
            {
                objectForSave = (Warehouse)Formatter.Deserialize(fs);
                objectForSave = new Warehouse(objectForSave.Title, objectForSave.Address, objectForSave.Contact_Number, objectForSave.Number_of_vacancy);
            }
        }
        public static void UploadEmployeeData(Warehouse objectForSave, string folderForSave)
        {
            try
            {
                if (!validationService.ValidationEmployee(objectForSave))
                {
                    objectForSave.Employee = new Employee[0];
                }
                using (FileStream fs = new FileStream(folderForSave,FileMode.OpenOrCreate))
                if (fs != null)
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
            catch (Exception)
            {

            }
        }
    }
}