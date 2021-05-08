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
        private Employees[] employee;
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
            private set { vacation = 10; }
        }
        public Employees[] Employee
        {
            get { return employee; }
            set { employee = value; }
        }
        public Warehouse(string title, string address, string number)
        {
            this.Title = title;
            this.Address = address;
            this.Number = number;
        }
    }
}
