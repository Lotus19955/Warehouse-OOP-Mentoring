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
        public string Contact_Number 
        {
            get { return number; }
            set { number = value; }
        }
        public int Number_of_vacancy
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
            this.Contact_Number = number;
            this.Number_of_vacancy = vacancy;
        }
        public void UpdateVacancy(int number)
        {
            this.Number_of_vacancy = number;
        }
        public override string ToString()
        {
            return $"{nameof(Title)}: {title} {nameof(Address)}: {address} " +
                   $"{nameof(Contact_Number)}: {number} {nameof(Number_of_vacancy)}: {vacancy}";
        }
    }
}
