using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class Employee : Person
    {
        private string job;
        private string address;
        private string number;
        private string education;
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
        public string Contact_Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Education
        {
            get { return education; }
            set { education = value; }
        }
        public Employee(string name, string surname, int age, string job, string address, string number, string education)
            :base (name, surname, age)
        {
            this.Job = job;
            this.Address = address;
            this.Contact_Number = number;
            this.Education = education;
        }
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name} {nameof(Surname)}: {base.Surname} " +
                   $"{nameof(Age)}: {base.Age} {nameof(Job)}: {job} " +
                   $"{nameof(Address)}: {address} {nameof(Contact_Number)}: {number} " +
                   $"{nameof(Education)}: {education} ";
        }
    }
}
