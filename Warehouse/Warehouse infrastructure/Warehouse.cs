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

        public Warehouse(string title, string address, string number)
        {
            this.Title = title;
            this.Address = address;
            this.Number = number;
        }
    }
}