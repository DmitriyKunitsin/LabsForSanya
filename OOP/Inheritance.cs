using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OOP
{
    internal class Inheritance
    {

    }

    public class Person
    {
        public readonly static int minAge = 1;
        public const string typeName = "Person";
        private string _name = " ";
        int age = 1;
        public virtual int Age
        {
            get => age;
            set { if (value > 0 && value < 100) age = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Person(string name)
        {
            this.Name = name;
        }

        public virtual void Print() => Console.WriteLine($"Person : {Name}");
    }

    class Employe : Person
    {
        // скрываем поля и константы базового класса
        public new readonly static int minAge = 18;
        public new const string typeName = "Employee";

        public override int Age
        {
            get => base.Age;
            set { if (value > 17 && value < 110) base.Age = value; }
        }
        public string Company { get; set; }
        //В данном случае в классе Employee переопределено свойство Name.
        //В блоке get нем мы берем значение свойства из базовового класса Person
        //и присоединяем к нему "Mr./Ms.". В блоке set передаем полученное значение в реализацию свойства
        //Name базового класса Person
        public new string Name
        {
            get => $"Mr./Ms. {base.Name}";
            set => base.Name = value;
        }
        public Employe(string name, string company) : base(name)
        {
            this.Company = company;
            base.Age = 18;// возраст для работников по умолчанию
        }
        //Также можно запретить переопределение методов и свойств.
        //В этом случае их надо объявлять с модификатором sealed
        public override sealed void Print()
        {
            Console.WriteLine(Name + " работает в " + Company);
            Console.WriteLine("ИЛИ");
            base.Print();
            Console.WriteLine(" работает в " + Company);
        }
    }

    class Client : Person
    {
        public string Bank { get; set; }
        public Client(string name, string bank) : base(name)
        {
            this.Bank = bank;
        }
        // Другим способом изменить функциональность метода, унаследованного от базового класса,
        // является скрытие (shadowing / hiding).
        public new void Print()
        {//В каких ситуациях можно использовать скрытие?
         //Например в родительском классе метод Print не является virtual
            Console.WriteLine($"Работник {Name}, явлляется клиентом банка {Bank}");
            //base.Print();   // вызываем метод Print из базового класса Person
        }
        //Фактически скрытие метода/свойства представляет определение в классе-наследнике метода или свойства,
        //которые соответствует по имени и набору параметров методу или свойству базового класса.
        //Для скрытия членов класса применяется ключевое слово new
    }
}
