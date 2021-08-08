using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_infrastructure;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WarehouseOOPMentoring
{
    class Program
    {
        private static Warehouse garage = null;
        private static WarehouseService warehouseService = new WarehouseService();
        private static EmployeeService employeeService = new EmployeeService();
        private static ValidationService validationService = new ValidationService();
        private static Stopwatch clock = new Stopwatch();
        private static BinaryFormatter Formatter = new BinaryFormatter();

        private static void Main(string[] args)
        {
            FolderService.UploadWarehouseData(ref garage, @"D:\VS\Проекты\Warehouse-OOP-Mentoring\WarehouseData.dat");
            FolderService.UploadEmployeeData(garage, @"D:\VS\Проекты\Warehouse-OOP-Mentoring\EmployeeData.dat");
            if (garage == null)
            {
                warehouseService.Create(ref garage);
            }
                Menu(garage);
                Console.ReadLine();
        }
        /// <summary>
        /// Object menu
        /// </summary>
        /// <param name="garage">object</param>
        public static void Menu(Warehouse garage)
        {
            clock.Start();
            while (true)
            {
                Console.WriteLine("\n\t Main Menu");
                Console.WriteLine("1 - Update menu");
                Console.WriteLine("2 - Display menu");
                Console.WriteLine("3 - Employee menu");
                Console.WriteLine("4 - Clear information about warehouse");
                Console.WriteLine("5 - Time Menu");
                Console.WriteLine("6 - Exit");
                Console.Write(AppConstants.Command.ENTER_YOUR_CHOICE);
                string choise = Console.ReadLine();
                int.TryParse(choise, out int number);
                Console.WriteLine();
                Console.Clear();
                switch (number)
                {
                    case 1:
                        UpdateMenu(garage);
                        break;
                    case 2:
                        DisplayMenu(garage);
                        break;
                    case 3:
                        EmployeeMenu(garage);
                        break;
                    case 4:
                        ClearInfoAboutWarehouse(ref garage);
                        garage = warehouseService.Create(ref garage);
                        break;
                    case 5:
                        TimeMenu();
                        break;
                    case 6:
                        clock.Stop();
                        DisplayRunTime();
                        Console.WriteLine("Press 'Enter'");
                        Console.Read();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(AppConstants.Alert.UNKNOWN_COMMAND);
                        break;
                }
            }
        }
        /// <summary>
        /// Display to console 'Update menu'
        /// </summary>
        /// <param name="garage">object</param>
        public static void UpdateMenu(Warehouse garage)
        {
            Console.WriteLine("\n\t Update Menu");
            Console.WriteLine($"1 - Update '{nameof(garage.Title)}'");
            Console.WriteLine($"2 - Update '{nameof(garage.Address)}'");
            Console.WriteLine($"3 - Update '{nameof(garage.Contact_Number)}'");
            Console.WriteLine($"4 - Update '{nameof(garage.Number_of_vacancy)}'");
            Console.WriteLine($"5 - {AppConstants.Command.RETURN_TO_MAIN_MENU}");
            Console.Write(AppConstants.Command.ENTER_YOUR_CHOICE);
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            Console.WriteLine();
            Console.Clear();
            switch (number)
            {
                case 1:
                    Console.Write("Enter new 'Title': ");
                    garage.Title = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Title));
                    FolderService.SaveData(garage, @"D:\VS\Проекты\Warehouse-OOP-Mentoring\WarehouseData.dat");
                    UpdateMenu(garage);
                    break;
                case 2:
                    Console.Write("Enter new 'Address': ");
                    garage.Address = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Address));
                    FolderService.SaveData(garage, @"D:\VS\Проекты\Warehouse-OOP-Mentoring\WarehouseData.dat");
                    UpdateMenu(garage);
                    break;
                case 3:
                    Console.Write("Enter new 'Contact number': ");
                    garage.Contact_Number = validationService.TrySetValue(Console.ReadLine(), nameof(garage.Contact_Number));
                    FolderService.SaveData(garage, @"D:\VS\Проекты\Warehouse-OOP-Mentoring\WarehouseData.dat");
                    UpdateMenu(garage);
                    break;
                case 4:
                    Console.Write("Enter new number of free 'Vacancy': ");
                    int vacancy = validationService.TrySetNumber(Console.ReadLine(), nameof(garage.Number_of_vacancy));
                    garage.UpdateVacancy(vacancy);
                    FolderService.SaveData(garage, @"D:\VS\Проекты\Warehouse-OOP-Mentoring\WarehouseData.dat");
                    UpdateMenu(garage);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine(AppConstants.Alert.UNKNOWN_COMMAND);
                    UpdateMenu(garage);
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Display menu'
        /// </summary>
        /// <param name="garage">object</param>
        public static void DisplayMenu(Warehouse garage)
        {
            Console.WriteLine("\n\t Display Menu");
            Console.WriteLine($"1 - Display '{nameof(garage.Title)}'");
            Console.WriteLine($"2 - Display '{nameof(garage.Address)}'");
            Console.WriteLine($"3 - Display 'Contact {nameof(garage.Contact_Number)}'");
            Console.WriteLine($"4 - Display '{nameof(garage.Number_of_vacancy)}'");
            Console.WriteLine($"5 - Display all information");
            Console.WriteLine($"6 - {AppConstants.Command.RETURN_TO_MAIN_MENU}");
            Console.Write(AppConstants.Command.ENTER_YOUR_CHOICE);
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            Console.Clear();
            switch (number)
            {
                case 1:
                    warehouseService.Display(garage.Title, nameof(garage.Title));
                    DisplayMenu(garage);
                    break;
                case 2:
                    warehouseService.Display(garage.Address, nameof(garage.Address));
                    DisplayMenu(garage);
                    break;
                case 3:
                    warehouseService.Display(garage.Contact_Number, nameof(garage.Contact_Number));
                    DisplayMenu(garage);
                    break;
                case 4:
                    DisplayFreeVacancy(garage);
                    DisplayMenu(garage);
                    break;
                case 5:
                    warehouseService.Display(garage);
                    DisplayMenu(garage);
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine(AppConstants.Alert.UNKNOWN_COMMAND);
                    DisplayMenu(garage);
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Update employee  menu'
        /// </summary>
        /// <param name="garage">object</param>
        public static void UpdateEmployeeMenu(Warehouse garage)
        {
            Console.WriteLine("\n\t Update Employee Menu");
            Console.WriteLine($"1 - View '{nameof(Employee)}' list");
            Console.WriteLine($"2 - Search employee by '{nameof(Employee.Name)}' and '{nameof(Employee.Surname)}'");
            Console.WriteLine($"3 - Return to '{nameof(Employee)} Menu'");
            Console.Write(AppConstants.Command.ENTER_YOUR_CHOICE);
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            Console.Clear();
            switch (number)
            {
                case 1:
                    employeeService.DisplayWarehouseEmployee(garage);
                    if (garage.Employee != null)
                    {
                        UpdateEmployeeInformationMenu(garage);
                    }
                    UpdateEmployeeMenu(garage);
                    break;
                case 2:
                    Employee[] searchedEntities = employeeService.SearchEmployeesByNameAndSurname(garage);
                    if (searchedEntities != null)
                    {
                        UpdateEmployeeInformationMenu(garage, searchedEntities);
                    }
                    UpdateEmployeeMenu(garage);
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine(AppConstants.Alert.UNKNOWN_COMMAND);
                    UpdateEmployeeMenu(garage);
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Employee menu'
        /// </summary>
        /// <param name="garage">object</param>
        public static void EmployeeMenu(Warehouse garage)
        {
            FolderService.SaveData(garage.Employee, @"D:\VS\Проекты\Warehouse-OOP-Mentoring\EmployeeData.dat");
            Console.WriteLine("\n\t Employee Menu");
            Console.WriteLine($"1 - Display '{nameof(Employee)}'");
            Console.WriteLine($"2 - Create new '{nameof(Employee)}'");
            Console.WriteLine($"3 - Update '{nameof(Employee)} information'");
            Console.WriteLine($"4 - Find {nameof(garage.Employee)} by '{nameof(Employee.Name)}' and '{nameof(Employee.Surname)}'");
            Console.WriteLine($"5 - Remove '{nameof(garage.Employee)}'");
            Console.WriteLine($"6 - Create new '{nameof(Employee)}' based on the created");
            Console.WriteLine($"7 - {AppConstants.Command.RETURN_TO_MAIN_MENU}");
            Console.Write(AppConstants.Command.ENTER_YOUR_CHOICE);
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            Console.Clear();
            switch (number)
            {
                case 1:
                    employeeService.DisplayWarehouseEmployee(garage);
                    EmployeeMenu(garage);
                    break;
                case 2:
                    employeeService.Create(garage);
                    EmployeeMenu(garage);
                    break;
                case 3:
                    UpdateEmployeeMenu(garage);
                    EmployeeMenu(garage);
                    break;
                case 4:
                    employeeService.SearchEmployeesByNameAndSurname(garage);
                    EmployeeMenu(garage);
                    break;
                case 5:
                    employeeService.RemoveEmployee(garage);
                    EmployeeMenu(garage);
                    break;
                case 6:
                    employeeService.DisplayWarehouseEmployee(garage);
                    Employee selectedEmployeeToClone = employeeService.UpdateEmployeeInformation(garage);
                    Employee clonedEmployee = (Employee)selectedEmployeeToClone.Clone();
                    employeeService.AddEmployee(garage, clonedEmployee);
                    UpdateEmployeeInformationMenu(garage, new[] { clonedEmployee }, true);
                    break;
                case 7:
                    Menu(garage);
                    break;
                default:
                    Console.WriteLine(AppConstants.Alert.UNKNOWN_COMMAND);
                    EmployeeMenu(garage);
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Update employee information menu'
        /// </summary>
        /// <param name="garage">object</param>
        public static void UpdateEmployeeInformationMenu(Warehouse garage, Employee[] searchedEntities = null, bool? isCloned = false)
        {
            Employee employeeForUpdate = isCloned == true ?
                searchedEntities[0] : employeeService.UpdateEmployeeInformation(garage, searchedEntities);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\t Update Employee Information");
                Console.WriteLine($"1 - Update '{nameof(Employee.Name)}'");
                Console.WriteLine($"2 - Update '{nameof(Employee.Surname)}'");
                Console.WriteLine($"3 - Update '{nameof(Employee.Age)}'");
                Console.WriteLine($"4 - Update '{nameof(Employee.Job)}'");
                Console.WriteLine($"5 - Update '{nameof(Employee.Address)}'");
                Console.WriteLine($"6 - Update '{nameof(Employee.Contact_Number)}'");
                Console.WriteLine($"7 - Update '{nameof(Employee.Education)}'");
                Console.WriteLine($"8 - return to '{nameof(Employee)} Menu'");
                Console.Write(AppConstants.Command.ENTER_YOUR_CHOICE);
                int.TryParse(Console.ReadLine(), out int number);
                Console.WriteLine();
                switch (number)
                {
                    case 1:
                        Console.Write($"Enter new '{nameof(Employee.Name)}': ");
                        employeeForUpdate.Name = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Name));
                        break;
                    case 2:
                        Console.Write($"Enter new '{nameof(Employee.Surname)}': ");
                        employeeForUpdate.Surname = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Surname));
                        break;
                    case 3:
                        Console.Write($"Enter new '{nameof(Employee.Age)}': ");
                        employeeForUpdate.Age = validationService.TrySetNumber(Console.ReadLine(), nameof(Employee.Age));
                        break;
                    case 4:
                        Console.Write($"Enter new '{nameof(Employee.Job)}': ");
                        employeeForUpdate.Job = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Job));
                        break;
                    case 5:
                        Console.Write($"Enter new '{nameof(Employee.Address)}': ");
                        employeeForUpdate.Address = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Address));
                        break;
                    case 6:
                        Console.Write($"Enter new '{nameof(Employee.Contact_Number)}': ");
                        employeeForUpdate.Contact_Number = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Contact_Number));
                        break;
                    case 7:
                        Console.Write($"Enter new '{nameof(Employee.Education)}': ");
                        employeeForUpdate.Education = validationService.TrySetValue(Console.ReadLine(), nameof(Employee.Education));
                        break;
                    case 8:
                        EmployeeMenu(garage);
                        break;
                    default:
                        Console.WriteLine(AppConstants.Alert.UNKNOWN_COMMAND);
                        break;
                }
            }
        }
        /// <summary>
        /// Clear all information sbout warehouse and employees
        /// </summary>
        /// <param name="garage">object</param>
        /// <param name="employees">object</param>
        public static void ClearInfoAboutWarehouse(ref Warehouse garage)
        {
            garage = null;
            Console.WriteLine("Clear info success");
        }
        /// <summary>
        /// Display to console informations about free vacancy 
        /// </summary>
        /// <param name="garage">object</param>
        public static void DisplayFreeVacancy(Warehouse garage)
        {
            Console.WriteLine($"Number of free vacancy: {garage.Number_of_vacancy}");
        }
        /// <summary>
        /// Display to console runtime information
        /// </summary>
        public static void DisplayRunTime()
        {
            TimeSpan cl = clock.Elapsed;
            string elapsedTime = string.Format("{0:00} : {1:00}", cl.Minutes, cl.Seconds);
            Console.WriteLine("RunTime " + elapsedTime);
        }
        /// <summary>
        /// Display to console 'Time Menu'
        /// </summary>
        public static void TimeMenu()
        {
            Console.Clear();
            DisplayRunTime();
            Console.WriteLine("\n\t Time Menu");
            Console.WriteLine($"1 - Time stop");
            Console.WriteLine($"2 - Continue time");
            Console.WriteLine($"3 - Restart time ");
            Console.WriteLine($"4 - Display current execution time");
            Console.WriteLine($"5 - Return to 'Main Menu'");
            Console.Write(AppConstants.Command.ENTER_YOUR_CHOICE);
            int.TryParse(Console.ReadLine(), out int number);
            Console.WriteLine();
            switch (number)
            {
                case 1:
                    clock.Stop();
                    TimeMenu();
                    break;
                case 2:
                    clock.Start();
                    TimeMenu();
                    break;
                case 3:
                    clock.Restart();
                    TimeMenu();
                    break;
                case 4:
                    DisplayRunTime();
                    TimeMenu();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine(AppConstants.Alert.UNKNOWN_COMMAND);
                    break;
            }
        }
    }
}