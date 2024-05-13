using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    internal class Human : IClonable, IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Work { get; set; }
        public Human(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Human(string name, int age, Company company)
        {
            this.Name = name;
            this.Age = age;
            this.Work = company;
        }
        public object Clone()
        {
            return new Human(this.Name, this.Age);
        }
        public object HardClone()
        {
            return new Human(this.Name, this.Age, new Company(this.Work.Name));
        }

        public int CompareTo(object? o)
        {
            if (o is Human human) return Name.CompareTo(human.Name);
            else throw new ArgumentException("Некорректное значение параметра");
        }


    }
}
