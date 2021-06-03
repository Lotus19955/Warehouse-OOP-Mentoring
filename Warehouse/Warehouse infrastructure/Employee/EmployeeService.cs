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
                        garage.UpdateVacancy(garage.Vacancy - 1);
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
                Console.WriteLine(AppConstants.Alert.UNKNOWN_COMMAND);
                return;
            }
        }
        /// <summary>
        /// Update information about employee
        /// </summary>
        /// <param name="garage">object</param>
        public Employee UpdateEmployeeInformation(Warehouse garage, Employee[] searchedEntities = null)
        {
            Console.Write("Enter number of employee: ");
            int selectEmployee = validationService.TrySetNumber(Console.ReadLine(), "Number");
            Employee employeeForUpdate = null;
            if (selectEmployee <= garage.Employee.Length && selectEmployee >= 1)
            {
                if (searchedEntities != null && searchedEntities.Length > 0)
                {
                    Guid id = searchedEntities[selectEmployee - 1].id;
                    for (int i = 0; i < garage.Employee.Length; i++)
                    {
                        if (garage.Employee[i].id == id)
                        {
                            employeeForUpdate = garage.Employee[i];
                            break;
                        }
                    }
                }
                else
                {
                    employeeForUpdate = garage.Employee[selectEmployee - 1];
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("'Number' is incorrect value");
                UpdateEmployeeInformation(garage, searchedEntities);
            }
            return employeeForUpdate;
        }
        /// <summary>
        /// Sort array of Employee by 'Name'
        /// </summary>
        /// <param name="garage">object</param>
        private void SortEmployeeByName (Warehouse garage)
        {
            int cmpVal;
            for (int i = 0; i < garage.Employee.Length; i++)
            {
                for (int y = i + 1; y < garage.Employee.Length; y++)
                {
                    if (y <= garage.Employee.Length - 1)
                    {
                        cmpVal = garage.Employee[i].Name.CompareTo(garage.Employee[y].Name);
                    if (cmpVal > 0)
                    {
                        Employee x = garage.Employee[i];
                        garage.Employee[i] = garage.Employee[y];
                        garage.Employee[y] = x;
                    }
                    }
                }
            }
                    }
        /// <summary>
        /// Display to console information about employees
        /// </summary>
        /// <param name="employees">object</param>
        public void DisplayWarehouseEmployee(Warehouse garage)
        {
            SortEmployeeByName(garage);
            int number = 1;
            if (validationService.ValidationEmployee(garage))
            {
                foreach (Employee employee in garage.Employee)
                {
                Console.WriteLine($"{number})" + 
                    $" Name:{employee.Name} " +
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
                Console.WriteLine(AppConstants.Alert.NO_OR_NULL_EMPLOYEE);
            }
        }
        /// <summary>
        /// Find employee by 'Name' and 'Surname' in employee array
        /// </summary>
        /// <param name="employees">object</param>
        public Employee[] SearchEmployeesByNameAndSurname(Warehouse garage)
        {
            if (validationService.ValidationEmployee(garage))
            {
                int number = 1;
                Console.WriteLine($"Enter employee '{nameof(Employee.Name)}' and '{nameof(Employee.Surname)}' to find");
                Console.Write($"Enter '{nameof(Employee.Name)}': ");
                string name = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Name));
                Console.Write($"Enter '{nameof(Employee.Surname)}': ");
                string surname = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Surname));
                Employee[] searchedEntities = new Employee[0];
                for (int i = 0; i < garage.Employee.Length; i++)
                {
                    Employee employee = garage.Employee[i];
                    if (employee.Name == name && employee.Surname == surname)
                    {
                        validationService.Resize(ref searchedEntities, 1);
                        searchedEntities[i] = garage.Employee[i];
                        Console.WriteLine($"{number})" + 
                            $" Name:{employee.Name} " +
                            $" Surname:{employee.Surname} " +
                            $" Age:{employee.Age} " +
                            $" Position:{employee.Job} " +
                            $" Address:{employee.Address} " +
                            $" Number:{employee.Number} " +
                            $" Education:{employee.Education} ");
                        number++;
                    }
                }
                if (searchedEntities.Length == 0)
                {
                Console.WriteLine($"There is no employee with a name: {name}, surname: {surname}");
                return null;
                }
                return searchedEntities;
            }
            else
            {
                Console.WriteLine(AppConstants.Alert.NO_OR_NULL_EMPLOYEE);
                return null;
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
                Console.Write("Enter number wich employes you need to fire: ");
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
                        garage.UpdateVacancy(garage.Vacancy + 1);
                    }
                }
            }
            else
            {
                Console.WriteLine(AppConstants.Alert.NO_OR_NULL_EMPLOYEE);
            }
        }
    }
 }

