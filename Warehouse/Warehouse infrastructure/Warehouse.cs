using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{

    public class Warehouse
    {
        private string title;
        private string address;
        private string number;
        private int vacation = 10;
        public string Title 
        {
            get { return title; }
            set { title = value; }
        }
        public string Address 
        {
            get { return address; }
            set { address = value; }
        }
        public string Number 
        {
            get { return number; }
            set { number = value; }
        }
        public int Vacation
        {
            get { return vacation; }
            set { vacation = value; }
        }
        public Warehouse(string title, string address, string number)
        {
            this.Title = title;
            this.Address = address;
            this.Number = number;
        }
    }
    public class Employees
    {
        private string name;
        private string surname;
        private int age;
        private string job;
        private string address;
        private string number;
        private string education;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Job
        {
            get { return job; }
            set { job = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Education
        {
            get { return education; }
            set { education = value; }
        }
        public Employees(string name, string surname, int age, string job, string address, string number, string education)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Job = job;
            this.Address = address;
            this.Number = number;
            this.Education = education;
        }
    }
    public class WarehouseService    
    {
        private static Warehouse garage = null;
        private static Employees[] employees = new Employees[10];
        /// <summary>
        /// Object menu
        /// </summary>
        /// <param name="garage">object</param>
        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("\t Menu");
            Console.WriteLine("1 - Update menu");
            Console.WriteLine("2 - Display menu");
            Console.WriteLine("3 - Clear information about warehouse");
            Console.WriteLine("4 - Add information about employee");
            Console.WriteLine("5 - Search employee");
            Console.WriteLine("6 - Remove employee");
            Console.WriteLine("7 - Exit");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            Console.WriteLine();
            switch (number)
            {
                case 1:
                    UpdateInformation(garage);
                    Menu();
                    break;
                case 2:
                    DisplayMenu(garage);
                    Menu();
                    break;
                case 3:
                    ClearInfoAboutWarehouse(garage, employees);
                    Menu();
                    break;
                case 4:
                    CreateEmployees();
                    Menu();
                    break;
                case 5:
                    SearchEmployeesByNameAndSurname(employees);
                    Menu();
                    break;
                case 6:
                    RemoveEmployee(employees);
                    Menu();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu();
                    break;
            }
        }
        /// <summary>
        /// Update information in object
        /// </summary>
        /// <param name="garage">object</param>
        private static void UpdateInformation(Warehouse garage)
        {
            Console.WriteLine("\t Update Menu");
            Console.WriteLine($"1 - Update '{nameof(garage.Title)}'");
            Console.WriteLine($"2 - Update '{nameof(garage.Address)}'");
            Console.WriteLine($"3 - Update 'Contact {nameof(garage.Number)}'");
            Console.WriteLine("4 - Return to 'Menu'");
            Console.Write("Enter your choise: ");
            string choise = Console.ReadLine();
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    Console.Write("Enter new 'Title': ");
                    garage.Title = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Title));
                    Menu();
                    break;
                case 2:
                    Console.Write("Enter new 'Address': ");
                    garage.Address = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Address));
                    Menu();
                    break;
                case 3:
                    Console.Write("Enter new 'Contact number': ");
                    garage.Number = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Number));
                    Menu();
                    break;
                case 4:
                    Menu();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu();
                    break;
            }
        }
        /// <summary>
        /// Display to console 'Display menu'
        /// </summary>
        /// <param name="garage">object</param>
        private static void DisplayMenu(Warehouse garage)
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
            int.TryParse(choise, out int number);
            switch (number)
            {
                case 1:
                    Display(garage.Title, nameof(garage.Title));
                    Menu();
                    break;
                case 2:
                    Display(garage.Address, nameof(garage.Address));
                    Menu();
                    break;
                case 3:
                    Display(garage.Number, nameof(garage.Number));
                    Menu();
                    break;
                case 4:
                    DisplayWarehouseEmployee(employees);
                    Menu();
                    break;
                case 5:
                    DisplayFreeVacations(garage);
                    break;
                case 6:
                    Menu();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    Menu();
                    break;
            }
        }
        /// <summary>
        /// Display to console information about object
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        private static void Display(string param, string paramName)
        {
            Console.WriteLine($"Warehouse {paramName}: {param} ");
        }
        /// <summary>
        /// Display to console informations about free vacations 
        /// </summary>
        /// <param name="garage">object</param>
        private static void DisplayFreeVacations(Warehouse garage)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    garage.Vacation--;
                }

            }
            Console.WriteLine($"Number of free vacation: {garage.Vacation}");
            garage.Vacation = 10;
        }
        /// <summary>
        /// Display to console information about employees
        /// </summary>
        /// <param name="employees">object</param>
        private static void DisplayWarehouseEmployee(Employees[] employees)
        {
            int number = 1;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    Console.WriteLine($"{number}) Name:{employees[i].Name} " +
                        $" Surname:{employees[i].Surname} " +
                        $" Age:{employees[i].Age} " +
                        $" Position:{employees[i].Job} " +
                        $" Address:{employees[i].Address} " +
                        $" Number:{employees[i].Number} " +
                        $" Education:{employees[i].Education} ");
                    number++;
                    Console.WriteLine();
                }
            }
            if (employees.Length <= 0)
            {
                Console.WriteLine("there are no employees. First, you need to hire it.");
            }
        }
        /// <summary>
        /// Clear all information sbout warehouse and employees
        /// </summary>
        /// <param name="garage">object</param>
        /// <param name="employees">object</param>
        private static void ClearInfoAboutWarehouse(Warehouse garage, Employees[] employees)
        {
            garage.Title = null;
            garage.Address = null;
            garage.Number = null;
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = null;
            }
        }
        /// <summary>
        /// Check objects parameters for null or empty
        /// </summary>
        /// <param name="param">gets object parameters</param>
        /// <param name="paramName">gets 'Names' of object parameters</param>
        /// <returns></returns>
        private static string ValidationForNullOrEmpty(string param, string paramName)
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
        /// Create you employee object
        /// </summary>
        /// <returns>object</returns>
        private static void CreateEmployees()
        {
            employees[0] = new Employees("Andrei", "Yermalovich", 26, "Director", "Minsk", "1234567", "Higher");
            employees[6] = new Employees("Fred", "Yog", 21, "Cleaner", "Minsk", "9876543", "Middle");
            employees[7] = new Employees("Greg", "Gog", 27, "Storekeeper", "Minsk", "4563782", "Higher");
            employees[8] = new Employees("Alis", "Vangog", 30, "Accountant", "Minsk", "1598673", "Higher");
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    Console.Write($"Enter '{nameof(Employees.Name)}' of employee: ");
                    string name = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Name));

                    Console.Write($"Enter '{nameof(Employees.Surname)}' of employee: ");
                    string surname = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Surname));

                    Console.Write($"Enter  'Contact {nameof(Employees.Age)}' of employee: ");
                    string intAge = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Age));
                    int.TryParse(intAge, out int age);

                    Console.Write($"Enter '{nameof(Employees.Job)}' of employee: ");
                    string job = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Job));

                    Console.Write($"Enter  '{nameof(Employees.Address)}' of employee: ");
                    string homeAddress = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Address));

                    Console.Write($"Enter  'Contact {nameof(Employees.Number)}' of employee: ");
                    string contactNumber = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Number));

                    Console.Write($"Enter  '{nameof(Employees.Education)}' of employee: ");
                    string education = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Education));

                    employees[i] = new Employees(name, surname, age, job, homeAddress, contactNumber, education);
                    break;
                }
            }
        }
        /// <summary>
        /// Create you warehouse objects
        /// </summary>
        /// <returns>object</returns>
        /// <returns>object</returns>
        public static void CreateObject()
        {
            Console.WriteLine("First you need to add information about warehouse");
            Console.Write($"Enter '{nameof(garage.Title)}' of warehouse: ");
            string title = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Title));

            Console.Write($"Enter '{nameof(garage.Address)}' of warehouse: ");
            string address = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Address));

            Console.Write($"Enter  'Contact {nameof(garage.Number)}' of warehouse: ");
            string number = ValidationForNullOrEmpty(Console.ReadLine(), nameof(garage.Number));

            garage = new Warehouse(title, address, number);
        }
        /// <summary>
        /// Find employee by 'Name' and 'Surname' in employee array
        /// </summary>
        /// <param name="employees">object</param>
        private static void SearchEmployeesByNameAndSurname(Employees[] employees)
        {
            Console.WriteLine($"Enter employee '{nameof(Employees.Name)}' and '{nameof(Employees.Surname)}' to find");
            Console.Write($"Enter '{nameof(Employees.Name)}': ");
            string findName = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Name));
            Console.Write($"Enter '{nameof(Employees.Surname)}': ");
            string findSurname = ValidationForNullOrEmpty(Console.ReadLine(), nameof(Employees.Surname));
            bool validation;
            for (int i = 0; i < employees.Length; i++)
            {
                validation = (employees[i] != null) && (findName == employees[i].Name) && (findSurname == employees[i].Surname);
                if (validation)
                {
                    Console.WriteLine($"Name:{employees[i].Name} " +
                    $" Surname:{employees[i].Surname} " +
                    $" Age:{employees[i].Age} " +
                    $" Position:{employees[i].Job} " +
                    $" Address:{employees[i].Address} " +
                    $" Number:{employees[i].Number} " +
                    $" Education:{employees[i].Education} ");
                }
            }
        }
        /// <summary>
        /// Remove employee from array
        /// </summary>
        /// <param name="employees">object</param>
        private static void RemoveEmployee(Employees[] employees)
        {
            DisplayWarehouseEmployee(employees);
            Console.Write("Enter number witch employes you need to fire: ");
            string choice = Console.ReadLine();
            int.TryParse(choice, out int intChoice);
            bool validation = (intChoice > 1) && (intChoice < employees.Length);
            if (intChoice <= 1)
            {
                employees[0] = null;
                Console.WriteLine("Remove success");
            }
            if (intChoice > employees.Length)
            {
                employees[employees.Length - 1] = null;
                Console.WriteLine("Remove success");
            }
            if (validation)
            {
                employees[intChoice - 1] = null;
                Console.WriteLine("Remove success");
            }
        }
    }
}
