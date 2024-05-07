using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStructNamespace
{

    class Person
    {
        public string Name = "Undefiend"; // Имя
        public int Age; // Возраст
        public Company Company;

        public Person()
        {
            Console.WriteLine("Создание объекта Person");
            Name = "Nastya";
            Age = 27;
            this.Company = new Company();
        }

        public Person(string Name)
        {
            Console.WriteLine("Создание объекта Person");
            this.Name = Name;
            Age = 18;
            this.Company = new Company();
        }
        public Person(string Name, int Age)
        {
            Console.WriteLine("Создание объекта Person");
            this.Name = Name;
            this.Age = Age;
            this.Company = new Company();
        }

        public Person(string Name, int Age, string CompanyName)
        {
            Console.WriteLine("Создание объекта Person");
            this.Name = Name;
            this.Age = Age;
            this.Company = new Company(CompanyName);
        }


        public void Print() => Console.WriteLine($"Имя :{Name} \nВозвраст : {Age}\nКомпания : {Company.Title}");

        public void Deconstruct(out string personName, out int personAge)
        {
            personName = Name;
            personAge = Age;
        }



    }
}
