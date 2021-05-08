using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class Employees
    {
        private string name;
        private string surname;
        private int age;
        private string job;
        private string address;
        private string number;
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
        public string Education
        {
            get { return education; }
            set { education = value; }
        }
        public Employees(string name, string surname, int age, string job, string address, string number, string education)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Job = job;
            this.Address = address;
            this.Number = number;
            this.Education = education;
        }
    }
}
