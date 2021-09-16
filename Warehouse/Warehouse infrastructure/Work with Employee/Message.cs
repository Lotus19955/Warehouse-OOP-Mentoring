using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class Message : IHasId
    {
        private string sender;
        private List<Employee> receiver;
        private string body;
        private Guid Id;
        public Guid id
        {
            get { return Id; }
            set { Id = Guid.NewGuid(); }
        }
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        public List<Employee> Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public Message() { }
        public Message(string sender, List<Employee> receiver, string body)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.Body = body;
            this.id = Guid.NewGuid();
        }
    }
}