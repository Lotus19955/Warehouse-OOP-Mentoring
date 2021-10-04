using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    [Serializable]
    public class Message : Person, IMailid
    {
        private string sender;
        private List<Employee> receivers;
        private string body;
        private Guid mailId;
        public Guid mailid
        {
            get { return mailId; }
            set { mailId = Guid.NewGuid(); }
        }
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        public List<Employee> Receiver 
        {
            get { return receivers; }
            set { receivers = value; }
        }
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public Message (string sender, List<Employee> receiver, string body):base()
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.Body = body;
            this.mailid = Guid.NewGuid();
        }
    }
}