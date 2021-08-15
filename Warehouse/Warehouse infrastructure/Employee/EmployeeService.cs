using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Warehouse_infrastructure

{   [Serializable]
    public class EmployeeService : Employee, IService
    {
        private static ValidationService validationService = new ValidationService();
        private static Logger logger = new Logger();
        private FolderService folderService = new FolderService();
        /// <summary>
        /// Create you employee object
        /// </summary>
        /// <returns>object</returns>
        public void Create(Warehouse garage)
        {
            Console.WriteLine($"Number of free vacancy: {garage.Number_of_vacancy}");
            Console.Write("How many employees do you want to add: ");
            string intEmployeeNumber = validationService.TrySetValue(Console.ReadLine(), "Number of emplyoee");
            if (int.TryParse(intEmployeeNumber, out int employeeNumber))
            {
                if (employeeNumber <= garage.Number_of_vacancy)
                {
                    if (!validationService.ValidationEmployee(garage))
                    {
                        garage.Employee = new Employee[0];
                    }
                    for (int i = 0; i < employeeNumber; i++)
                    {
                        try
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

                            Console.Write($"Enter 'Contact {nameof(Employee.Contact_Number)}' of employee: ");
                            string number = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Contact_Number));

                            Console.Write($"Enter '{nameof(Employee.Education)}' of employee: ");
                            string education = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Education));

                            garage.Employee[garage.Employee.Length - 1] = new Employee(name, surname, age, job, address, number, education);
                            garage.UpdateVacancy(garage.Number_of_vacancy - 1);
                            folderService.SaveData(garage.Employee, FolderService.Folder.Employee);
                            logger.Log(AppConstants.Alert.ADDED_NEW_EMPLOYEE_WITH_ID + garage.Employee[garage.Employee.Length - 1].id,LogLevel.Information);
                        }
                        catch (Exception ex)
                        {
                            logger.Log(ex.Message,LogLevel.Error);
                        }
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
            folderService.SaveData(garage.Employee, FolderService.Folder.Employee);
            return employeeForUpdate;
        }
        /// <summary>
        /// Sort array of Employee by 'Age' from younger to older 
        /// </summary>
        /// <typeparam name="T">where T : Employee, IComparable</typeparam>
        /// <param name="array">Array tipe</param>
        public void SortEmployeeByAge<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int y = i + 1; y < array.Length; y++)
                {
                    if (y <= array.Length - 1)
                    {
                        if (array[i].CompareTo(array[y]) > 0)
                        {
                            T x = array[i];
                            array[i] = array[y];
                            array[y] = x;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Display to console information about employees
        /// </summary>
        /// <param name="garage">object</param>
        public void DisplayWarehouseEmployee(Warehouse garage)
        {
            if (validationService.ValidationEmployee(garage))
            {
                SortEmployeeByAge<Employee>(garage.Employee);
                int number = 1;
                foreach (Employee employee in garage.Employee)
                {
                    Console.WriteLine($"{number}) " + employee.ToString());
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
        /// <param name="garage">object</param>
        public Employee[] SearchEmployeesByNameAndSurname(Warehouse garage)
        {
            if (validationService.ValidationEmployee(garage))
            {
                int number = 0;
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
                        searchedEntities[number] = garage.Employee[i];
                        Console.WriteLine($"{number + 1}) {employee.ToString()}");
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
        /// <param name="garage">object</param>
        public void RemoveEmployee(Warehouse garage)
        {
            if (validationService.ValidationEmployee(garage))
            {
                DisplayWarehouseEmployee(garage);
                Console.Write("Enter number which employee you need to fire: ");
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int intChoice))
                {
                    if (intChoice < garage.Employee.Length && intChoice >= 1)
                    {
                        int x;
                        int index = intChoice-1;
                        garage.Employee[index] = null;
                        for (int i = 0; i < garage.Employee.Length; i++)
                        {
                            x = intChoice;
                            intChoice = index;
                            index = x;
                        }
                        validationService.CloneArray(garage.Employee);
                        var arrayEmployee = garage.Employee;
                        Array.Resize(ref arrayEmployee, garage.Employee.Length - 1);
                        garage.Employee = arrayEmployee;
                        SortEmployeeByAge<Employee>(garage.Employee);
                        garage.UpdateVacancy(garage.Number_of_vacancy + 1);
                    }
                }
            }
            else
            {
                Console.WriteLine(AppConstants.Alert.NO_OR_NULL_EMPLOYEE);
            }
            folderService.SaveData(garage.Employee, FolderService.Folder.Employee);
        }
        /// <summary>
        /// Add employee to array
        /// </summary>
        /// <param name="garage">object</param>
        public void AddEmployee(Warehouse garage, Employee addedEmployee)
        {
            if (validationService.ValidationEmployee(garage))
            {
                var arrayEmployee = garage.Employee;
                Array.Resize(ref arrayEmployee, garage.Employee.Length + 1);
                garage.Employee = arrayEmployee;
                garage.Employee[garage.Employee.Length - 1] = addedEmployee;
                garage.UpdateVacancy(garage.Number_of_vacancy - 1);
            }
            else
            {
                Console.WriteLine(AppConstants.Alert.NO_OR_NULL_EMPLOYEE);
            }
        }
    }
}