using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class Validation
    {
        /// <summary>
        /// Check objects parameters for null or empty
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        /// <returns></returns>
        public string TrySetValue(string param, string paramName)
        {
            while (string.IsNullOrEmpty(param))
            {
                Console.WriteLine($"{paramName} can not be empty");
                Console.Write($"Enter '{paramName}': ");
                param = Console.ReadLine();
            }
            return param;
        }
        /// <summary>
        /// Check objects parameters for 0 or empty
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        /// <returns></returns>
        public int TrySetNumber(string param, string paramName)
        {
            while (true) // Подумать над логикой цикла!
            {
                if (int.TryParse(param, out int number))
                {
                    return number;
                }
                Console.WriteLine($"{paramName} is incorrect value");
                Console.Write($"Enter '{paramName}': ");
                param = Console.ReadLine();
            }
        }
        /// <summary>
        /// Checking employees array for null
        /// </summary>
        /// <param name="garage">object</param>
        /// <returns></returns>
        public bool ValidationEmployee(Warehouse garage)
        {
            return garage.Employee != null && garage.Employee.Length > 0;
        }
        /// <summary>
        /// Resize Employee Array
        /// </summary>
        /// <param name="garage">Employee Array</param>
        /// <param name="size">number of elements you need to add </param>
        public void Resize(Warehouse garage, int size)
        {
            Employee[] temp = new Employee[garage.Employee.Length + size];
            for (int i = 0; i < garage.Employee.Length; i++)
            {
                temp[i] = garage.Employee[i];
            }
            garage.Employee = temp;
        }
    }
}
