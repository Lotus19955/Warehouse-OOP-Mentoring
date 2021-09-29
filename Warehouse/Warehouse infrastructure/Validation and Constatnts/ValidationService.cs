using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Warehouse_infrastructure
{
    public class ValidationService
    {
        /// <summary>
        /// Check objects parameters for null or empty
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        /// <returns></returns>
        public string TrySetValue(string param, string paramName)
        {
            if (!string.IsNullOrEmpty(param))
            {
                return param;
            }
            Console.WriteLine($"{paramName} can not be empty");
            Console.Write($"Enter '{paramName}': ");
            param = Console.ReadLine();
            return TrySetValue(param, paramName);
        }
        /// <summary>
        /// Check objects parameters for 0 or empty
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        /// <returns></returns>
        public int TrySetNumber(string param, string paramName)
        {
            if (int.TryParse(param, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine($"{paramName} is incorrect value");
                Console.Write($"Enter '{paramName}': ");
                param = Console.ReadLine();
                return TrySetNumber(param, paramName);
            }
        }
        /// <summary>
        /// Checking employees array for null
        /// </summary>
        /// <param name="garage">object</param>
        /// <returns></returns>
        public bool ValidationEmployee(List<Employee> employee)
        {
            return employee != null && employee.Count > 0;
        }
        public void ValidationSavingPath(string savePath)
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
        }
        /// <summary>
        /// Clone Array, put null element to last slot
        /// </summary>
        /// <param name="array">Take any array</param>
        public void CloneArray<T>(T[] array)
        {
            T[] tempArray = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    tempArray[i] = array[i];
                }
                else
                {
                    T x = array[i];
                    array[i] = array[array.Length - 1];
                    array[array.Length - 1] = x;
                    tempArray[i] = array[i];
                }
            }
            array = tempArray;
        }
    }
}