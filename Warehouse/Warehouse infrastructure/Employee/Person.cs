using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public abstract class Person : IHasId
    { 
        private string name;
        private string surname;
        private int age;
        private Guid Id;
        public Guid id
        {
            get { return Id; }
            set { Id = Guid.NewGuid(); }
        }
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
        public Person(string name, string surname, int age) : base() 
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.id = Guid.NewGuid();
        }
    }
}
