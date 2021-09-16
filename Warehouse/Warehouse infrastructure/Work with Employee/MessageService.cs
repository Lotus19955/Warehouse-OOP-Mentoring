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
        private static Message message = new Message();
        private static Message messageForAll = new Message();
        //private static Dictionary<Guid, List<Employee>> mailBoxForAll = new Dictionary<Guid, List<Employee>>();
        //private static Dictionary<Guid, Guid> mailBoxForOne = new Dictionary<Guid, Guid>();
        private static FolderService folderService = new FolderService();
        public void MessageMenu(Warehouse garage)
        {
            Console.WriteLine("\n\t Massage menu");
            Console.WriteLine($"1 - Send mail to all Employees");
            Console.WriteLine($"2 - Send mail to Employee");
            Console.WriteLine($"3 - Show sent message for all");
            Console.WriteLine($"4 - Show sent message for each employee");
            Console.WriteLine($"5 - {AppConstants.Command.RETURN}");
            Console.Write(AppConstants.Command.ENTER_YOUR_CHOICE);
            string choise = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(choise, out int number);
            Console.Clear();
            switch (number)
            {
                case 1:
                    MailToAll(garage);
                    break;
                case 2:
                    //MailToOne(garage);
                    break;
                case 3:
                    ShowMail(messageForAll);
                    break;
                case 4:
                  //  ShowMail(mailBoxForOne);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine(AppConstants.Alert.UNKNOWN_COMMAND);
                    break;
            }
        }
        private static void MailToAll(Warehouse garage)
        {
            messageForAll = DataForMailForAll(garage);
            Console.WriteLine("Message sent to all employee!");
            garage.MailBox.Add(messageForAll.id, messageForAll);
            folderService.SaveData<Dictionary<Guid, Message>>(garage.MailBox,FolderService.Folder.MailBoxForAll);
        }
        //private static void MailToOne(Warehouse garage)
        //{
        //    message = DataForMailForOne(garage, message);
        //    for (int i = 0; i < message.Receiver.Count; i++)
        //    {
        //        mailBoxForOne.Add(message.Receiver[i].id, message.id);
        //    }
        //    Console.WriteLine($"Message sent to {message.ToString()}");
        //}
        private static Message DataForMailForAll (Warehouse garage)
        {
            Console.Write($"Enter '{nameof(Message.Sender)}' name: ");
            string sender = validationService.TrySetValue(Console.ReadLine(), nameof(Message.Sender));
            Console.Write($"Enter 'Mail' text: ");
            string body = validationService.TrySetValue(Console.ReadLine(), nameof(Message.Body));
            Console.Clear();
            messageForAll = new Message(sender, garage.Employee, body);
            return messageForAll;
        }
        //private static Message DataForMailForOne(Warehouse garage, Message messageForOne)
        //{
        //    employeeService.DisplayWarehouseEmployee(garage);
        //    Console.Write("Enter number which employee you send mail: ");
        //    string choice = Console.ReadLine();
        //    if (int.TryParse(choice, out int intChoice))
        //    {
        //        messageForOne.Receiver.Add(garage.Employee[intChoice - 1]);
        //    }
        //    Console.WriteLine();
        //    Console.Write($"Enter '{nameof(Message.Sender)}' name: ");
        //    string sender = validationService.TrySetValue(Console.ReadLine(), nameof(Message.Sender));
        //    Console.WriteLine();
        //    Console.Write($"Enter 'Mail' text: ");
        //    string body = validationService.TrySetValue(Console.ReadLine(), nameof(Message.Body));
        //    Console.Clear();
        //    messageForOne = new Message(sender,messageForOne.Receiver,body);
        //    return messageForOne;
        //}
        private static void ShowMail (Message message)
        {
            Console.WriteLine($"{nameof(message.Sender)}: {message.Sender}");
            Console.WriteLine($"{nameof(message.Receiver)}: ");
            foreach (Employee employee in message.Receiver)
            {
                Console.WriteLine($"\t{nameof(employee.Name)}: {employee.Name}  {nameof(employee.Surname)}: {employee.Surname}");
            }
            Console.WriteLine($"{nameof(message.Body)}: {message.Body}");
        }
    }
}