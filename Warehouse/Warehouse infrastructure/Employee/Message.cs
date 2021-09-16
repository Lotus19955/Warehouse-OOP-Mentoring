using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    class Message
    {
        private string sender;
        private string receiver;
        private string mail;
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
        private string Receicer
        {
            get { return receiver; }
            set { receiver = value; }
        }
        private string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public Message() { }
        public Message(string sender, string receiver, string mail)
        {
            this.Sender = sender;
            this.Receicer = receiver;
            this.Mail = mail;
        }
        //public static SharedMailbox
    }
}
