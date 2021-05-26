using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class Person : HasId
    {
        private string name;
        private string surname;
        private int age;
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
        public Person(Guid ID, string name, string surname, int age)
            :base (ID)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }
    }
}
