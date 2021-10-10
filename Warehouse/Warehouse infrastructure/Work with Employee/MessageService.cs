using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class MessageService
    {
        private static ValidationService validationService = new ValidationService();
        private static EmployeeService employeeService = new EmployeeService();
        private static FolderService folderService = new FolderService();
        /// <summary>
        /// Adds message object to mailbox dictionary
        /// </summary>
        /// <param name="garage">gets object parameters</param>
        public void SendMail(Warehouse garage)
        {
            Message message = DataForMail(garage);
            if (message != null)
            {
                List<Message> listMessage = new List<Message>();
                listMessage.Add(message);
                garage.MailBox.Add($"{message.id}", listMessage);
                folderService.SaveData(message, $"{message.id}", nameof(garage.MailBox));
                Console.WriteLine("Message sent!");
            }
        }
        /// <summary>
        /// Create message object
        /// </summary>
        /// <param name="garage">gets object parameters</param>
        /// <returns></returns>
        private Message DataForMail (Warehouse garage)
        {
            List<Employee> garageEmployee = new List<Employee>(garage.Employee);
            List<Employee> tempEmployee = new List<Employee>();
            Message message;
            int choice = 0;
            Console.Write($"Enter '{nameof(Message.Sender)}' name: ");
            string sender = validationService.TrySetValue(Console.ReadLine(), nameof(Message.Sender));
            Console.WriteLine();
            Console.Write($"Enter 'Mail' text: ");
            string body = validationService.TrySetValue(Console.ReadLine(), nameof(Message.Body));
            Console.WriteLine();
            while (choice != garageEmployee.Count + 1 & choice != garageEmployee.Count + 2 & choice != garageEmployee.Count + 3)
            {
                employeeService.DisplayWarehouseEmployee(garageEmployee);
                Console.WriteLine(garageEmployee.Count + 1 + ")" + "Send mail to all emploee\n");
                Console.WriteLine(garageEmployee.Count + 2 + ")" + "Send mail\n");
                Console.WriteLine(garageEmployee.Count + 3 + ")" + AppConstants.Command.RETURN);
                Console.Write($"Choose '{nameof(Message.Receiver)}' (enter number): ");
                choice = validationService.TrySetNumber(Console.ReadLine(), nameof(garage.Employee));
                if (choice == garageEmployee.Count + 1)
                {
                    tempEmployee = garage.Employee;
                    Console.Clear();
                    break;
                }
                if (choice == garageEmployee.Count + 2 && tempEmployee != null)
                {
                    Console.Clear();
                    break;
                }
                if (choice == garageEmployee.Count + 3)
                {
                    tempEmployee = null;
                    break;
                }
                if (choice < 0 || choice > garageEmployee.Count + 3)
                {
                    Console.WriteLine("Incorrect value");
                }
                if (choice > 0 && choice <= garageEmployee.Count)
                {
                    tempEmployee.Add(garageEmployee[choice - 1]);
                    garageEmployee.RemoveAt(choice - 1);
                    Console.Clear();
                }
            }
            if (tempEmployee == null)
            {
                message = null;
            }
            else { message = new Message(sender, tempEmployee, body); }
            return message;
        }
        /// <summary>
        /// Show mail for all employees
        /// </summary>
        /// <param name="mailBox">gets object parameters</param>
        public void ShowAllMail(Dictionary<string, List<Message>> mailBox)
        {
            foreach (KeyValuePair<string, List<Message>> mail in mailBox)
            {
                Console.WriteLine(mail.Key);
                Console.WriteLine(nameof(Message.Body) + ": " + mail.Value[0].Body);
                for (int i = 0; i < mail.Value.Count; i++)
                {
                    Console.Write(nameof(Message.Receiver) + ": ");
                    for (int y = 0; y < mail.Value[i].Receiver.Count; y++)
                    {
                        Console.Write(mail.Value[i].Receiver[y].Name + ", ");
                    }
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Show mail for specific employee
        /// </summary>
        /// <param name="mailBox">gets object parameters</param>
        /// <param name="garage">gets object parameters</param>
        public void ShowMailForSpecificEmployee(Dictionary<string, List<Message>> mailBox, Warehouse garage)
        {
            employeeService.DisplayWarehouseEmployee(garage.Employee);
            Console.WriteLine(garage.Employee.Count + 1 + ")" + AppConstants.Command.RETURN);
            Console.WriteLine();
            Console.Write($"Choose '{nameof(Message.Receiver)}' (enter number): ");
            int choice = validationService.TrySetNumber(Console.ReadLine(), nameof(garage.Employee));
            Console.Clear();
            if (choice == garage.Employee.Count + 1)
            { }
            if (choice > 0 || choice <= garage.Employee.Count)
            {
                foreach (KeyValuePair<string, List<Message>> mail in mailBox)
                {
                    foreach (Message mes in mail.Value)
                    {
                        foreach (Employee emp in mes.Receiver)
                        {
                            if (emp.id == garage.Employee[choice - 1].id)
                            {
                                Console.WriteLine(mail.Key);
                                Console.WriteLine(nameof(Message.Body) + ": " + mail.Value[0].Body);
                                Console.Write(nameof(Message.Receiver) + ": " + emp.Name);
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            else { Console.WriteLine("Incorrect value");}
        }
    }
}