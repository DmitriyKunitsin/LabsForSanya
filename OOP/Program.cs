namespace OOP
{
    internal class Program
    {
        /// <summary>принимает объект и тип, к которому нужно преобразовать этот объект. Она возвращает объект типа T или null, если преобразование не удалось</summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Наследование\n");
            Person person = new Person("Dima");
            person.Print();
            person = new Employe("Serega", "Sber");
            person.Print();


            //Восходящие преобразования. Upcasting
            Employe employe = new Employe("Tom", "Luch");

            Person person1 = employe;// преобразование от Employee к Person

            Console.WriteLine(person1.Name);

            //Нисходящие преобразования. Downcasting

            Employe employe1 = (Employe)person1; // преобразование от Person к Employee
            Console.WriteLine(employe1.Company + " " + employe1.Name);

            // Объект Employee также представляет тип object
            object obj = new Employe("Bill", "Microsoft");

            // чтобы обратиться к возможностям типа Employee, приводим объект к типу Employee
            Employe employee = (Employe)obj;

            Person person2 = new Client("Sam", "VTB");
            person2.Print();
            Client client = (Client)person2;
            Console.WriteLine(client.Name + " " + client.Bank);

            object obj2 = new Employe("Bill ", "Microsoft");

            ((Employe)obj2).Print();

            string company = ((Employe)obj2).Company;
            Console.WriteLine(company);

            //Способы преобразований
            //ключевое слово as. С помощью него программа пытается преобразовать выражение
            //к определенному типу, при этом не выбрасывает исключение

            Person person3 = new Person("Boris");
            Employe? employe2 = MyConvertTo<Employe>(person3);
            if (employe2 == null) { Console.WriteLine("Преобразование прошло неудачно"); }
            else { Console.WriteLine(employe2.Company); }

            //Если значение слева от оператора представляет тип, указаный справа от оператора,
            //то оператор is возвращает true, иначе возвращается false.
            //Причем оператор is позволяет автоматически преобразовать значение к типу,
            //если это значение представляет данный тип
            Person jerry = new Person("Jerry");
            if (jerry is Employe empl)
            {
                Console.WriteLine(empl.Company);
            }
            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }

            //Виртуальные методы и свойства
            //Те методы и свойства, которые мы хотим сделать доступными для переопределения,
            //в базовом классе помечается модификатором virtual. Такие методы и свойства называют виртуальными
            //А чтобы переопределить метод в классе-наследнике, этот метод определяется с модификатором override.
            //Переопределенный метод в классе-наследнике должен иметь тот же набор параметров,
            //что и виртуальный метод в базовом классе.

            Employe tom = new Employe("Tom", "Microsoft");
            // В классе Employee это свойство переопределено - возраст работника должен быть не меньше 18.
            Console.WriteLine(tom.Age); // 18
            tom.Age = 22;
            Console.WriteLine(tom.Age); // 22
            tom.Age = 12;
            Console.WriteLine(tom.Age); // 22





            Console.WriteLine("\n\n");


        }
        /// <summary>принимает объект и тип, к которому нужно преобразовать этот объект. Она возвращает объект типа T или null, если преобразование не удалось</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static T MyConvertTo<T>(object obj) where T : class
        {
            return obj as T;
        }


    }
}
