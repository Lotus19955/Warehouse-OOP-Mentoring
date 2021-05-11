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
        public Warehouse CreateWarehouse(ref Warehouse garage)
        {
            Console.WriteLine("First you need to add information about warehouse");
            Console.Write($"Enter '{nameof(Warehouse.Title)}' of warehouse: ");
            string title = TrySetValue(Console.ReadLine(), nameof(Warehouse.Title));

            Console.Write($"Enter '{nameof(Warehouse.Address)}' of warehouse: ");
            string address = TrySetValue(Console.ReadLine(), nameof(Warehouse.Address));

            Console.Write($"Enter  'Contact {nameof(Warehouse.Number)}' of warehouse: ");
            string number = TrySetValue(Console.ReadLine(), nameof(Warehouse.Number));

            Console.Write($"Enter  numbers of free '{nameof(Warehouse.Vacation)}' of warehouse: ");
            string  freevacation= TrySetValue(Console.ReadLine(), nameof(Warehouse.Vacation));
            int.TryParse(freevacation, out int vacation);
            garage = new Warehouse(title, address, number, vacation);
            return garage;
        }
        /// <summary>
        /// Create you employee object
        /// </summary>
        /// <returns>object</returns>
        public void CreateEmployee(Warehouse garage)
        {
            if (garage.Vacation != 0)
            {
                Console.Write($"Enter '{nameof(Employee.Name)}' of employee: ");
                string name = TrySetValue(Console.ReadLine(), nameof(Employee.Name));

                Console.Write($"Enter '{nameof(Employee.Surname)}' of employee: ");
                string surname = TrySetValue(Console.ReadLine(), nameof(Employee.Surname));

                Console.Write($"Enter 'Contact {nameof(Employee.Age)}' of employee: ");
                string intAge = TrySetValue(Console.ReadLine(), nameof(Employee.Age));
                int.TryParse(intAge, out int age);

                Console.Write($"Enter '{nameof(Employee.Job)}' of employee: ");
                string job = TrySetValue(Console.ReadLine(), nameof(Employee.Job));

                Console.Write($"Enter '{nameof(Employee.Address)}' of employee: ");
                string address = TrySetValue(Console.ReadLine(), nameof(Employee.Address));

                Console.Write($"Enter 'Contact {nameof(Employee.Number)}' of employee: ");
                string number = TrySetValue(Console.ReadLine(), nameof(Employee.Number));

                Console.Write($"Enter '{nameof(Employee.Education)}' of employee: ");
                string education = TrySetValue(Console.ReadLine(), nameof(Employee.Education));
                if (!ValidationEmployee(garage))
                {
                    garage.Employee = new Employee[1];
                    garage.Employee[0] = new Employee(name, surname, age, job, address, number, education);
                    garage.UpdateVatarion(garage.Vacation - 1);
                }
                else
                {
                    var arrayEmployee = garage.Employee;
                    Array.Resize(ref arrayEmployee, garage.Employee.Length + 1);
                    garage.Employee = arrayEmployee;
                    garage.Employee[garage.Employee.Length - 1] = new Employee(name, surname, age, job, address, number, education);
                    garage.UpdateVatarion(garage.Vacation - 1);
                }
            }
            else
            {
                Console.WriteLine("No free vacation");
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
            Console.WriteLine($"4 - Update number of free '{nameof(garage.Vacation)}'");
            Console.WriteLine("5 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            Console.WriteLine();
            switch (number)
            {
                case 1:
                    Console.Write("Enter new 'Title': ");
                    garage.Title = TrySetValue(Console.ReadLine(), nameof(garage.Title));
                    break;
                case 2:
                    Console.Write("Enter new 'Address': ");
                    garage.Address = TrySetValue(Console.ReadLine(), nameof(garage.Address));
                    break;
                case 3:
                    Console.Write("Enter new 'Contact number': ");
                    garage.Number = TrySetValue(Console.ReadLine(), nameof(garage.Number));
                    break;
                case 4:
                    Console.Write("Enter new number of free 'Vacation': ");
                    int.TryParse(TrySetValue(Console.ReadLine(), nameof(garage.Vacation)), out int vacation);
                    garage.UpdateVatarion(vacation);
                    break;
                case 5:
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
            Console.WriteLine($"6 - Display all information");
            Console.WriteLine("7 - Return to 'Menu'");
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
                    Display(garage);
                    break;
                case 7:
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Employee menu'
        /// </summary>
        /// <param name="garage">object</param>
        public void EmployeeMenu(Warehouse garage)
        {
            Console.WriteLine("\t Employee Menu");
            Console.WriteLine($"1 - Display number of free'{nameof(garage.Vacation)}'");
            Console.WriteLine($"2 - Display all '{nameof(garage.Employee)}'");
            Console.WriteLine($"3 - Create new employee");
            Console.WriteLine($"4 - Find {nameof(garage.Employee)} by name and surname'");
            Console.WriteLine($"5 - Remove '{nameof(garage.Employee)}'");
            Console.WriteLine($"6 - Display number of '{nameof(garage.Vacation)}'");
            Console.WriteLine("7 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    DisplayFreeVacations(garage);
                    break;
                case 2:
                    DisplayWarehouseEmployee(garage);
                    break;
                case 3:
                    CreateEmployee(garage);
                    break;
                case 4:
                    SearchEmployeesByNameAndSurname(garage);
                    break;
                case 6:
                    RemoveEmployee(garage);
                    break;
                case 7:
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
        public  void Display(string param, string paramName)
        {
            Console.WriteLine($"Warehouse {paramName}: {param} ");
        }
        public  void Display(Warehouse garage)
        {
            Console.Write($" Warehouse Title: {garage.Title}\t " +
                       $" Warehouse address: {garage.Address}\t " +
                       $" Warehouse number: {garage.Number}\t " +
                       $" Number of free vacations:{garage.Vacation}");
            Console.WriteLine("Information about empolees:");
            DisplayWarehouseEmployee(garage);
            Console.WriteLine();
        }
        /// <summary>
        /// Display to console informations about free vacations 
        /// </summary>
        /// <param name="garage">object</param>
        public void DisplayFreeVacations(Warehouse garage)
        {
            Console.WriteLine($"Number of free vacation: {garage.Vacation}");
        }
        /// <summary>
        /// Display to console information about employees
        /// </summary>
        /// <param name="employees">object</param>
        public void DisplayWarehouseEmployee(Warehouse garage)
        {
            int number = 1;
            if (ValidationEmployee(garage))
            {
                foreach (var employee in garage.Employee)
                {
                    Console.WriteLine($"{number}) Name:{employee.Name} " +
                        $" Surname:{employee.Surname} " +
                        $" Age:{employee.Age} " +
                        $" Position:{employee.Job} " +
                        $" Address:{employee.Address} " +
                        $" Number:{employee.Number} " +
                        $" Education:{employee.Education} ");
                    Console.WriteLine();
                    number++;
                }
            }
            else
            {
                Console.WriteLine("There are no employees. First, you need to hire it.");
            }
        }
        /// <summary>
        /// Clear all information sbout warehouse and employees
        /// </summary>
        /// <param name="garage">object</param>
        /// <param name="employees">object</param>
        public void ClearInfoAboutWarehouse(ref Warehouse garage)
        {
            garage = null;
            Console.WriteLine("Clear info success");
        }
        /// <summary>
        /// Find employee by 'Name' and 'Surname' in employee array
        /// </summary>
        /// <param name="employees">object</param>
        public void SearchEmployeesByNameAndSurname(Warehouse garage)
        {
            if (ValidationEmployee(garage))
            {
                Console.WriteLine($"Enter employee '{nameof(Employee.Name)}' and '{nameof(Employee.Surname)}' to find");
                Console.Write($"Enter '{nameof(Employee.Name)}': ");
                string name = TrySetValue(Console.ReadLine(), nameof(Employee.Name));
                Console.Write($"Enter '{nameof(Employee.Surname)}': ");
                string surname = TrySetValue(Console.ReadLine(), nameof(Employee.Surname));
                foreach (Employee employee in garage.Employee)
                {
                    if (employee.Name == name && employee.Surname == surname)
                    {
                        Console.WriteLine($"Name:{employee.Name} " +
                            $" Surname:{employee.Surname} " +
                            $" Age:{employee.Age} " +
                            $" Position:{employee.Job} " +
                            $" Address:{employee.Address} " +
                            $" Number:{employee.Number} " +
                            $" Education:{employee.Education} ");
                    }
                }
                Console.WriteLine($"There is no employee with a name: {name}, surname: {surname}");
            }
            else
            {
                Console.WriteLine("There are no employees. First, you need to hire it.");
            }
        }
        /// <summary>
        /// Remove employee from array
        /// </summary>
        /// <param name="employees">object</param>
        public void RemoveEmployee(Warehouse garage)
        {
            if (ValidationEmployee(garage))
            {
                DisplayWarehouseEmployee(garage);
                Console.Write("Enter number witch employes you need to fire: ");
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int intChoice))
                {
                    if (intChoice < garage.Employee.Length && intChoice >= 1)
                    {
                        int x;
                        int index = intChoice--;
                        garage.Employee[index] = null;
                        for (int i = 0; i < garage.Employee.Length; i++)
                        {
                            x = intChoice;
                            intChoice = index;
                            index = x;
                        }
                        var arrayEmployee = garage.Employee;
                        Array.Resize(ref arrayEmployee, garage.Employee.Length - 1);
                        garage.UpdateVatarion(garage.Vacation + 1);
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no employees. First, you need to hire it.");
            }
        }
        /// <summary>
        /// Check objects parameters for null or empty
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        /// <returns></returns>
        private string TrySetValue(string param, string paramName)
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
        private bool ValidationEmployee (Warehouse garage)
        {
            return garage.Employee != null && garage.Employee.Length > 0;
        }
    }
}
