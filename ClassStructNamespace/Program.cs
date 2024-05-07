using print = System.Console;

namespace ClassStructNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person Dima = new Person("Dima");
            Person Vanya = new Person("Vanya", 28);
            Person personOne = new Person("Tip", 33, "Compania");

            person.Print();
            Dima.Print();
            Vanya.Print();
            personOne.Print();


            Console.WriteLine("\nИнициализаторы объектов\n");
            //С помощью инициализатора мы можем установить значения только доступных из вне класса полей и свойств объекта.
            //Например, в примере выше поля name и age имеют модификатор доступа public,
            //поэтому они доступны из любой части программы.

            //Инициализатор выполняется после конструктора, поэтому если и в конструкторе,
            //и в инициализаторе устанавливаются значения одних и тех же полей и свойств,
            //то значения, устанавливаемые в конструкторе, заменяются значениями из инициализатора.

            //Инициализаторы удобно применять, когда поле или свойство класса представляет другой класс

            Person newPerson = new Person
            {
                Name = "Tom",
                Age = 21,
                Company = new Company { Title = "Luch" }
            };

            newPerson.Print();

            Console.WriteLine("\nДеконструкторы\n");

            // Деконструкторы(не путать с деструкторами) позволяют выполнить декомпозицию объекта на отдельные части.

            (string name, int age) = Dima;

            Console.WriteLine(name);    // Dima
            Console.WriteLine(age);     // 18

            // По сути деконструкторы это не более,чем более удобный способ разложения объекта на компоненты.
            // Это все равно, что если бы мы написали

            string variable1; int variable2;

            Dima.Deconstruct(out variable1, out variable2);

            Console.WriteLine($"variable1 = {variable1}, variable2 = {variable2}");

            //При получении значений из деконструктора нам необходимо предоставить столько переменных,
            //сколько деконструктор возвращает значений. Однако бывает, что не все эти значения нужны.
            //И вместо возвращаемых значений мы можм использовать прочерк _.
            //Например, нам надо получить только возраст пользователя:

            (_, int ages) = Dima;
            Console.WriteLine(ages);

            Console.WriteLine("\nСтруктуры\n");

            // Создание объекта структуры
            Manager manager = new Manager();

            manager.Name = "Dima";
            manager.Age = ages;

            manager.Print();

            Manager manager2 = new Manager("Test", 22);
            manager2.Print();

            Manager manager3 = new();
            manager3.Print();

            //Если нам необходимо скопировать в один объект структуры значения из другого с небольшими изменениями,
            //то мы можем использовать оператор with:
            Manager testManager = manager3 with { Age = 44 };
            testManager.Print();

            Human human = new Human("Dima", "Kunitsin");
            Console.WriteLine(human.FullName);

            Human testHman = new Human();
            Console.WriteLine($"Name {testHman.FirstName} , Lastname : {testHman.LastName}");

            Human TwoTestHuman = new Human(44);
            Console.WriteLine(TwoTestHuman.OldYear);
            Console.WriteLine(TwoTestHuman.FullCardName);

            Console.WriteLine("\nNullable\n");

            MyNullable myNullable = new MyNullable();

            myNullable.PrintNullable(19);
            myNullable.PrintNullable(null);

            myNullable.MyGetVal(21);
            myNullable.MyGetVal(null);
            
            MyChechkNulable myChechkNulable  = new MyChechkNulable();

            myChechkNulable.myTestOperand();
            //С помощью выражения using print = System.Console указываем,
            //что псевдонимом для класса System.Console будет имя print
            string text = "Check using print = System.Console";
            print.WriteLine(text);

        }

        struct Manager
        {
            public string Name;
            public int Age;

            public Manager() : this("dEFOULT") { }
            public Manager(string name) : this(name, 18) { }

            public Manager(string Name, int Age)
            {
                this.Name = Name;
                this.Age = Age;
            }

            public void Print()
            {
                Console.WriteLine($"Имя : {Name}, Возвраст : {Age}");
            }
        }
    }


}
