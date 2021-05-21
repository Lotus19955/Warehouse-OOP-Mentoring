using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class EmployeeService
    {
        private static ValidationService validationService = new ValidationService();
        /// <summary>
        /// Create you employee object
        /// </summary>
        /// <returns>object</returns>
        public void CreateEmployee(Warehouse garage)
        {
            Console.WriteLine($"Number of free vacancy: {garage.Vacancy}");
            Console.Write("Now many employees do you want to add: ");
            string intEmployeeNumber = validationService.TrySetValue(Console.ReadLine(), "Number of emplyoee");
            if (int.TryParse(intEmployeeNumber, out int employeeNumber))
            {
                if (employeeNumber <= garage.Vacancy)
                {
                    if (!validationService.ValidationEmployee(garage))
                    {
                        garage.Employee = new Employee[0];
                    }
                    for (int i = 0; i < employeeNumber; i++)
                    { 
                        validationService.Resize(garage, 1);

                        Console.Write($"Enter '{nameof(Employee.Name)}' of employee: ");
                        string name = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Name));

                        Console.Write($"Enter '{nameof(Employee.Surname)}' of employee: ");
                        string surname = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Surname));

                        Console.Write($"Enter '{nameof(Employee.Age)}' of employee: ");
                        int age = validationService.TrySetNumber(Console.ReadLine(), nameof(Employee.Age));

                        Console.Write($"Enter '{nameof(Employee.Job)}' of employee: ");
                        string job = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Job));

                        Console.Write($"Enter '{nameof(Employee.Address)}' of employee: ");
                        string address = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Address));

                        Console.Write($"Enter 'Contact {nameof(Employee.Number)}' of employee: ");
                        string number = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Number));

                        Console.Write($"Enter '{nameof(Employee.Education)}' of employee: ");
                        string education = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Education));
                        
                        garage.Employee[garage.Employee.Length - 1] = new Employee(name, surname, age, job, address, number, education);
                        garage.UptadeVacancy(garage.Vacancy - 1);
                        Console.WriteLine("Employee created!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No free vacancy");
                }
            }
            else
            {
                Console.WriteLine("Unknown command");
                return;
            }
        }
        /// <summary>
        /// Display to console 'Employee menu'
        /// </summary>
        /// <param name="garage">object</param>
        public void EmployeeMenu(Warehouse garage)
        {
            Console.WriteLine("\t Employee Menu");
            Console.WriteLine($"1 - Create new 'Employee'");
            Console.WriteLine($"2 - Find {nameof(garage.Employee)} by name and surname'");
            Console.WriteLine($"3 - Remove '{nameof(garage.Employee)}'");
            Console.WriteLine("4 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    CreateEmployee(garage);
                    break;
                case 2:
                    SearchEmployeesByNameAndSurname(garage);
                    break;
                case 3:
                    RemoveEmployee(garage);
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
        
        /// <summary>
        /// Display to console information about employees
        /// </summary>
        /// <param name="employees">object</param>
        public void DisplayWarehouseEmployee(Warehouse garage)
        {
            int number = 1;
            if (validationService.ValidationEmployee(garage))
            {
                foreach (var employee in garage.Employee)
                {
                    Console.WriteLine($"{number})");
                    Console.WriteLine($" Name:{employee.Name} " +
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
        /// Find employee by 'Name' and 'Surname' in employee array
        /// </summary>
        /// <param name="employees">object</param>
        public void SearchEmployeesByNameAndSurname(Warehouse garage)
        {
            if (validationService.ValidationEmployee(garage))
            {
                Console.WriteLine($"Enter employee '{nameof(Employee.Name)}' and '{nameof(Employee.Surname)}' to find");
                Console.Write($"Enter '{nameof(Employee.Name)}': ");
                string name = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Name));
                Console.Write($"Enter '{nameof(Employee.Surname)}': ");
                string surname = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Surname));
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
            if (validationService.ValidationEmployee(garage))
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
                        garage.UptadeVacancy(garage.Vacancy + 1);
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no employees. First, you need to hire it.");
            }
        }
    }
 }

