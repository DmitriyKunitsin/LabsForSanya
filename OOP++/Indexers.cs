using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP__
{
    class Person
    {
        public string Name { get; }
        public Person(string name) => this.Name = name;
    }
    class Company
    {
        Person[] personal;
        public Company(Person[] personal) => this.personal = personal;
        public Person this[int index]
        {
            get
            { // если индекс имеется в массиве
                if (index >= 0 && index < this.personal.Length)
                {
                    return this.personal[index];// то возвращаем объект Person по индексу
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"index {index} не существует");// иначе генерируем исключение
                }
            }
            set
            {// если индекс есть в массиве
                if (index >= 0 && index <= this.personal.Length)
                {
                    this.personal[index] = value;// переустанавливаем значение по индексу
                }
            }
        }
        internal class User
        {
            string name = "";
            string email = "";
            string phone = "";
            public string this[string propname]
            {
                get
                {
                    switch (propname)
                    {
                        case "name": return name;
                        case "email": return email;
                        case "phone": return phone;
                        default: throw new Exception("Unknown Property Name");
                    }
                }
                set
                {
                    switch (propname)
                    {
                        case "name":
                            name = value;
                            break;
                        case "email":
                            email = value;
                            break;
                        case "phone":
                            phone = value;
                            break;
                    }
                }
            }


        }

    }
}
