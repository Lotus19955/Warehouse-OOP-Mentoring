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
        private int vacancy;
        private Employee[] employee;
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
        public int Vacancy
        {
            get { return vacancy; }
            private set { vacancy = value; }
        }
        public Employee[] Employee
        {
            get { return employee; }
            set { employee = value; }
        }
        public Warehouse(string title, string address, string number, int vacancy)
        {
            this.Title = title;
            this.Address = address;
            this.Number = number;
            this.Vacancy = vacancy;
        }
        public void UpdateVacancy(int number)
        {
            this.Vacancy = number;
        }
    }
}
