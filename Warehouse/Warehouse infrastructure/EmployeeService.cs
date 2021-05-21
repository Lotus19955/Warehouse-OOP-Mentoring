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

                        Guid id = Guid.NewGuid();

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
                        
                        garage.Employee[garage.Employee.Length - 1] = new Employee(id, name, surname, age, job, address, number, education);
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
        public void UpdateEmployeeMenu(Warehouse garage)
        {
            Console.WriteLine("\t Update Employee Menu");
            Console.WriteLine($"1 - View employee list");
            Console.WriteLine($"2 - Search employee by 'Name' and 'Surname'");
            Console.WriteLine("3 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    DisplayWarehouseEmployee(garage);
                    UpdateEmployeeInformation(garage);
                    break;
                case 2:
                    SearchEmployeesByNameAndSurname(garage);
                    UpdateEmployeeInformation(garage);
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
        public void UpdateEmployeeInformation(Warehouse garage)
        {
            int number = 0;
            Console.Write("Enter number of employee: ");
            int selectEmployee = validationService.TrySetNumber(Console.ReadLine(), "Number");
            while (number != 8)
            {
                Console.Clear();
                Console.WriteLine("\t Update Employee Information");
                Console.WriteLine($"1 - Update '{nameof(Employee.Name)}'");
                Console.WriteLine($"2 - Update '{nameof(Employee.Surname)}'");
                Console.WriteLine($"3 - Update '{nameof(Employee.Age)}'");
                Console.WriteLine($"4 - Update '{nameof(Employee.Job)}'");
                Console.WriteLine($"5 - Update '{nameof(Employee.Address)}'");
                Console.WriteLine($"6 - Update 'Contact {nameof(Employee.Number)}'");
                Console.WriteLine($"7 - Update '{nameof(Employee.Education)}'");
                Console.WriteLine("8 - Return to 'Menu'");
                Console.Write("Enter your choise: ");
                int.TryParse(Console.ReadLine(), out number);
                Console.WriteLine();
                switch (number)
                {
                    case 1:
                        Console.Write("Enter new 'Name': ");
                        garage.Employee[selectEmployee - 1].Name = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Name));
                        break;
                    case 2:
                        Console.Write("Enter new 'Surname': ");
                        garage.Employee[selectEmployee - 1].Surname = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Surname));
                        break;
                    case 3:
                        Console.Write("Enter new 'Age': ");
                        garage.Employee[selectEmployee - 1].Age = validationService.TrySetNumber(Console.ReadLine(), nameof(Employee.Age));
                        break;
                    case 4:
                        Console.Write("Enter new 'Job': ");
                        garage.Employee[selectEmployee - 1].Job = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Job));
                        break;
                    case 5:
                        Console.Write("Enter new 'Address': ");
                        garage.Employee[selectEmployee - 1].Address = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Address));
                        break;
                    case 6:
                        Console.Write("Enter new 'Contact Number': ");
                        garage.Employee[selectEmployee - 1].Number = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Number));
                        break;
                    case 7:
                        Console.Write("Enter new 'Education': ");
                        garage.Employee[selectEmployee - 1].Education = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Education));
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
        /// <summary>
        /// Display to console 'Employee menu'
        /// </summary>
        /// <param name="garage">object</param>
        public void EmployeeMenu(Warehouse garage)
        {
            Console.WriteLine("\t Employee Menu");
            Console.WriteLine($"1 - Display 'Warehouse employee'");
            Console.WriteLine($"2 - Create new 'Employee'");
            Console.WriteLine($"3 - Update 'Employee Information'");
            Console.WriteLine($"4 - Find {nameof(garage.Employee)} by name and surname'");
            Console.WriteLine($"5 - Remove '{nameof(garage.Employee)}'");
            Console.WriteLine("6 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            Console.Clear();
            switch (number)
            {
                case 1:
                    DisplayWarehouseEmployee(garage);
                    break;
                case 2:
                    CreateEmployee(garage);
                    break;
                case 3:
                    UpdateEmployeeMenu(garage);
                    break;
                case 4:
                    SearchEmployeesByNameAndSurname(garage);
                    break;
                case 5:
                    RemoveEmployee(garage);
                    break;
                case 6:
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
                foreach (Employee employee in garage.Employee)
                {
                Console.WriteLine($"{number})" +
                    $" ID: {employee.ID}");
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
                        Console.WriteLine($"{employee})" +  //НАЙТИ СПОСОБ ВЫВОДИТЬ ИНДЕКСЫ МАССИВА ДЛЯ НУМЕРАЦИИ
                            $" ID: {employee.ID}");
                        Console.WriteLine($" Name:{employee.Name} " +
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

