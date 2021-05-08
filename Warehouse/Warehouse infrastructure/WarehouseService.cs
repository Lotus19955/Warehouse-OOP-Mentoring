using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class WarehouseService 
    {
        /// <summary>
        /// Create you warehouse objects
        /// </summary>
        /// <returns>object</returns>
        /// <returns>object</returns>
        public void CreateWarehouse(ref Warehouse garage)
        {
            Console.WriteLine("First you need to add information about warehouse");
            Console.Write($"Enter '{nameof(garage.Title)}' of warehouse: ");
            string title = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Title));

            Console.Write($"Enter '{nameof(garage.Address)}' of warehouse: ");
            string address = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Address));

            Console.Write($"Enter  'Contact {nameof(garage.Number)}' of warehouse: ");
            string number = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Number));

            garage = new Warehouse(title, address, number);
            garage.Employee = new Employees[10];
        }
        /// <summary>
        /// Create you employee object
        /// </summary>
        /// <returns>object</returns>
        public void CreateEmployees(Warehouse garage)
        {
            garage.Employee[0] = new Employees("Andrei", "Yermalovich", 26, "Director", "Minsk", "1234567", "Higher");  // for TEST
            garage.Employee[6] = new Employees("Fred", "Yog", 21, "Cleaner", "Minsk", "9876543", "Middle");             // for TEST
            garage.Employee[7] = new Employees("Greg", "Gog", 27, "Storekeeper", "Minsk", "4563782", "Higher");         // for TEST
            garage.Employee[8] = new Employees("Alis", "Vangog", 30, "Accountant", "Minsk", "1598673", "Higher");       // for TEST
            for (int i = 0; i < garage.Employee.Length; i++)
            {
                if (garage.Employee[i] == null)
                {
                    Console.Write($"Enter '{nameof(Employees.Name)}' of employee: ");
                    string name = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Name));

                    Console.Write($"Enter '{nameof(Employees.Surname)}' of employee: ");
                    string surname = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Surname));

                    Console.Write($"Enter 'Contact {nameof(Employees.Age)}' of employee: ");
                    string intAge = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Age));
                    int.TryParse(intAge, out int age);

                    Console.Write($"Enter '{nameof(Employees.Job)}' of employee: ");
                    string job = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Job));

                    Console.Write($"Enter '{nameof(Employees.Address)}' of employee: ");
                    string homeAddress = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Address));

                    Console.Write($"Enter 'Contact {nameof(Employees.Number)}' of employee: ");
                    string contactNumber = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Number));

                    Console.Write($"Enter '{nameof(Employees.Education)}' of employee: ");
                    string education = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Education));

                    garage.Employee[i] = new Employees(name, surname, age, job, homeAddress, contactNumber, education);
                    break;
                }
            }
        }
        /// <summary>
        /// Update information in object
        /// </summary>
        /// <param name="garage">object</param>
        public void UpdateMenu(Warehouse garage)
        {
            Console.WriteLine("\t Update Menu");
            Console.WriteLine($"1 - Update '{nameof(garage.Title)}'");
            Console.WriteLine($"2 - Update '{nameof(garage.Address)}'");
            Console.WriteLine($"3 - Update 'Contact {nameof(garage.Number)}'");
            Console.WriteLine("4 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            Console.WriteLine();
            switch (number)
            {
                case 1:
                    Console.Write("Enter new 'Title': ");
                    garage.Title = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Title));
                    break;
                case 2:
                    Console.Write("Enter new 'Address': ");
                    garage.Address = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Address));
                    break;
                case 3:
                    Console.Write("Enter new 'Contact number': ");
                    garage.Number = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Number));
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Display menu'
        /// </summary>
        /// <param name="garage">object</param>
        public void DisplayMenu(Warehouse garage)
        {
            Console.WriteLine("\t Display Menu");
            Console.WriteLine($"1 - Display '{nameof(garage.Title)}'");
            Console.WriteLine($"2 - Display '{nameof(garage.Address)}'");
            Console.WriteLine($"3 - Display 'Contact {nameof(garage.Number)}'");
            Console.WriteLine($"4 - Display 'Employees information'");
            Console.WriteLine($"5 - Display number of '{nameof(garage.Vacation)}'");
            Console.WriteLine("6 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    Display(garage.Title, nameof(garage.Title));
                    break;
                case 2:
                    Display(garage.Address, nameof(garage.Address));
                    break;
                case 3:
                    Display(garage.Number, nameof(garage.Number));
                    break;
                case 4:
                    DisplayWarehouseEmployee(garage);
                    break;
                case 5:
                    DisplayFreeVacations(garage);
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
        /// <summary>
        /// Display to console information about object
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        public static void Display(string param, string paramName)
        {
            Console.WriteLine($"Warehouse {paramName}: {param} ");
        }
        /// <summary>
        /// Display to console informations about free vacations 
        /// </summary>
        /// <param name="garage">object</param>
        public void DisplayFreeVacations(Warehouse garage)
        {
            int counter = garage.Vacation;
            if (garage.Employee !=null)
            {
                for (int i = 0; i < garage.Employee.Length; i++)
                {
                    if (garage.Employee[i] != null)
                    {
                        counter--;
                    }
                }
            }
            Console.WriteLine($"Number of free vacation: {counter}");
        }
        /// <summary>
        /// Display to console information about employees
        /// </summary>
        /// <param name="employees">object</param>
        public void DisplayWarehouseEmployee(Warehouse garage)
        {
            if (ValidationEmployees(garage))
            {
                Console.WriteLine("There are no employees. First, you need to hire it.");
            }
            else
            {
                for (int i = 0; i < garage.Employee.Length; i++)
                {
                    if (garage.Employee[i] != null)
                    {
                        Console.WriteLine($"{i}) Name:{garage.Employee[i].Name} " +
                            $" Surname:{garage.Employee[i].Surname} " +
                            $" Age:{garage.Employee[i].Age} " +
                            $" Position:{garage.Employee[i].Job} " +
                            $" Address:{garage.Employee[i].Address} " +
                            $" Number:{garage.Employee[i].Number} " +
                            $" Education:{garage.Employee[i].Education} ");
                        Console.WriteLine();
                    }
                }
            }
        }
        /// <summary>
        /// Clear all information sbout warehouse and employees
        /// </summary>
        /// <param name="garage">object</param>
        /// <param name="employees">object</param>
        public void ClearInfoAboutWarehouse(ref Warehouse garage)
        {
            garage = new Warehouse(null,null,null);
            garage.Employee = new Employees[10];
        }
        /// <summary>
        /// Find employee by 'Name' and 'Surname' in employee array
        /// </summary>
        /// <param name="employees">object</param>
        public void SearchEmployeesByNameAndSurname(Warehouse garage)
        {
            if (ValidationEmployees(garage))
            {
                Console.WriteLine("There are no employees. First, you need to hire it.");
            }
            else
            {
                Console.WriteLine($"Enter employee '{nameof(Employees.Name)}' and '{nameof(Employees.Surname)}' to find");
                Console.Write($"Enter '{nameof(Employees.Name)}': ");
                string findName = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Name));
                Console.Write($"Enter '{nameof(Employees.Surname)}': ");
                string findSurname = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Surname));
                bool validation;
                for (int i = 0; i < garage.Employee.Length; i++)
                {
                    validation = (garage.Employee[i] != null) && (findName == garage.Employee[i].Name) && (findSurname == garage.Employee[i].Surname);
                    if (validation)
                    {
                        Console.WriteLine($"Name:{garage.Employee[i].Name} " +
                        $" Surname:{garage.Employee[i].Surname} " +
                        $" Age:{garage.Employee[i].Age} " +
                        $" Position:{garage.Employee[i].Job} " +
                        $" Address:{garage.Employee[i].Address} " +
                        $" Number:{garage.Employee[i].Number} " +
                        $" Education:{garage.Employee[i].Education} ");
                    }
                }
            }
        }
        /// <summary>
        /// Remove employee from array
        /// </summary>
        /// <param name="employees">object</param>
        public void RemoveEmployee(Warehouse garage)
        {
            if (ValidationEmployees(garage))
            {
                Console.WriteLine("There are no employees. First, you need to hire it.");
            }
            else
            {
                DisplayWarehouseEmployee(garage);
                Console.Write("Enter number witch employes you need to fire: ");
                string choice = Console.ReadLine();
                int.TryParse(choice, out int intChoice);
                bool validation = (intChoice > garage.Employee.Length - 1) | (intChoice < -1); // need fixes, I don't know how to do correct validation
                if (validation)
                {
                    Console.WriteLine("Enter correct number");
                    Console.WriteLine();
                    RemoveEmployee(garage);
                }
                if (garage.Employee[intChoice] == null)
                {
                    Console.WriteLine("Enter correct number");
                    Console.WriteLine();
                    RemoveEmployee(garage);
                }
                else 
                {
                    garage.Employee[intChoice] = null;
                    Console.WriteLine("Remove success");
                }
            }
        }
        /// <summary>
        /// Check objects parameters for null or empty
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        /// <returns></returns>
        private string ValidationForNullOrEmpty(string param, string paramName)
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
        /// Checking employees array for null
        /// </summary>
        /// <param name="garage">object</param>
        /// <returns></returns>
        private bool ValidationEmployees (Warehouse garage)
        {
            bool nullChecking = true;
            for (int i = 0; i < garage.Employee.Length; i++)
            {
                if(garage.Employee[i] != null)
                {
                    nullChecking = false;
                }
            }
            return nullChecking;
        }
    }
}
