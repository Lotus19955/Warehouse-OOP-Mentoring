using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class MessageService
    {
        private static ValidationService validationService = new ValidationService();
        private static EmployeeService employeeService = new EmployeeService();
        private static FolderService folderService = new FolderService();
        
        public void MailToAll(Warehouse garage)
        {
            Message message = DataForMail(garage);
            List<Message> listMessage = new List<Message>();
            listMessage.Add(message);
            garage.MailBox.Add($"{message.id}", listMessage);
            folderService.SaveData(garage.MailBox,FolderService.Folder.MailBox, nameof(garage.MailBox));
            Console.WriteLine("Message sent!");
        }
        private Message DataForMail (Warehouse garage)
        {
            List<Employee> employee = new List<Employee>();
            Console.Write($"Enter '{nameof(Message.Sender)}' name: ");
            string sender = validationService.TrySetValue(Console.ReadLine(), nameof(Message.Sender));
            Console.WriteLine();
            employeeService.DisplayWarehouseEmployee(garage);
            Console.WriteLine($"{garage.Employee.Count + 1}) All employees");
            Console.WriteLine();
            Console.WriteLine($"{garage.Employee.Count + 2}) Return");
            Console.Write($"Choose '{nameof(Message.Receiver)}' (enter number): ");
            int choice = validationService.TrySetNumber(Console.ReadLine(), nameof(garage.Employee));
            if (choice > 0 && choice <= garage.Employee.Count + 1)
            {
                if (choice >= 1 && choice < garage.Employee.Count)
                {
                    employee.Add(garage.Employee[choice - 1]);
                }
                if (choice == garage.Employee.Count + 1)
                {
                    employee.AddRange(garage.Employee);
                }
            }
            else 
            {
                while (choice <= 0 | choice > garage.Employee.Count + 1)
                { 
                    Console.WriteLine("Incorrect value");
                    Console.Write($"Choose '{nameof(Message.Receiver)}' (enter number): ");
                    choice = validationService.TrySetNumber(Console.ReadLine(), nameof(garage.Employee));
                    if (choice == garage.Employee.Count + 2)
                    {
                        MailToAll(garage);
                    }
                }
            }
            var receiver = employee;
            Console.Write($"Enter 'Mail' text: ");
            string body = validationService.TrySetValue(Console.ReadLine(), nameof(Message.Body));
            Console.Clear();
            Message message = new Message(sender, receiver, body);
            return message;
        }
        public void ShowMail (Dictionary<string,List<Message>> mailBox)
        {
            if(mailBox != null)
            {
                foreach (var mail in mailBox)
                {
                    Console.WriteLine(mail.Key + " - " + mail.Value);
                }
            }
            else {Console.WriteLine($"{mailBox} is empty!");}
        }
    }
}