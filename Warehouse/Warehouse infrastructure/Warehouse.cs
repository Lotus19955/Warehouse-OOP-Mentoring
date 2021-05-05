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
        private int vacation = 4;
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
            set { vacation = value; }
        }
        public Warehouse(string title, string address, string number)
        {
            this.Title = title;
            this.Address = address;
            this.Number = number;
        }
    }
    public class Employees
    {
        private string name;
        private string surname;
        private int age;
        private string job;
        private string homeAddress;
        private string contactNumber;
        private string education;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Job
        {
            get { return job; }
            set { job = value; }
        }
        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public string Education
        {
            get { return education; }
            set { education = value; }
        }
        public Employees(string name, string surname, int age, string job, string homeAddress, string contactNumber, string education)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Job = job;
            this.HomeAddress = homeAddress;
            this.ContactNumber = contactNumber;
            this.Education = education;
        }
    }
}