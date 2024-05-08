using System.Threading.Channels;

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





            Console.WriteLine("\nАбстрактные классы и члены классов\n");

            Transport car = new Auto("BMW");
            Transport ship = new Ship("Корабль");
            Transport aircraft = new Aircraft("Самолет");

            car.Move();
            ship.Move();
            aircraft.Move();


            var rectanle = new Recrangle { Width = 20, Height = 20 };
            var circle = new Circle { Radius = 200 };

            PrintShape(rectanle);
            PrintShape(circle);


            void PrintShape(Shape shape) => Console.WriteLine($"Perimetr : {shape.GetPerimetr()}, Area : {shape.GetArea()}");

            Console.WriteLine("\nGeneric\n");

            Gen<int> tomas = new Gen<int>(545, "Tom");
            Gen<string> dima = new Gen<string>("abc123", "Dima");

            int checkIdTomas = tomas.Id;
            string checkStringIdDima = dima.Id;

            Console.WriteLine(checkIdTomas);
            Console.WriteLine(checkStringIdDima);

            Company<Gen<int>> microsoft = new Company<Gen<int>>(tomas);

            Console.WriteLine($"Президдент компании по имени : {microsoft.CEO.Name}, id = {microsoft.CEO.Id}");

            //Статические поля обобщенных классов

            Works<int> worker = new Works<int>(546, "Worker");
            Works<int>.code = 1234;

            Works<string> workerString = new Works<string>("abc546", "WorkerString");
            Works<string>.code = "meta";
            // В итоге для Works<string> и для Works<int> будет создана своя переменная code.
            Console.WriteLine($"Works<int>.code = {Works<int>.code}\tWorks<string>.code = {Works<string>.code}");

            Lesson<int, string> AccouuntTom = new Lesson<int, string>(1, "1234", "Tomas");
            Console.WriteLine($"Id tomasa = {AccouuntTom.Id}, password tomasa = {AccouuntTom.Password}, name card = {AccouuntTom.Name}");

            //Обобщенные методы
            static void SwapValues<T>(ref T x, ref T y)
            {
                (y, x) = (x, y);
            }

            static void SwapListElements<T>(ref List<T> list, int indexA, int indexB)
            {
                (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
            }

            int x = 7;
            int y = 1;
            Console.WriteLine($"До SwapValues<int> x = {x} y = {y}");
            SwapValues<int>(ref x, ref y);
            Console.WriteLine($"после SwapValues<int> x = {x} y = {y}");

            string xString = "Dima";
            string yString = "Vanya";
            Console.WriteLine($"До Swap<string> x = {xString} y = {yString}");
            SwapValues<string>(ref xString, ref yString);
            Console.WriteLine($"После Swap<string> x = {xString} y = {yString}");

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            Console.WriteLine($"До Swap<List> list[3] = {list[3]}, list[9] = {list[9]}");
            SwapListElements<int>(ref list, 3, 9);
            Console.WriteLine($"После Swap<List> list[3] = {list[3]}, list[9] = {list[9]}");

            Generic.SendMessage(new Message("Hello Message"));
            Generic.SendMessage(new SmsMessage("Hello Sms Message"));
            Generic.SendMessage<EmailMessage>(new EmailMessage("Hello Email Message"));

            Messenger<Message> telegram = new Messenger<Message>();
            telegram.SendMessenger(new Message("Hello telegramm"));

            Messenger<EmailMessage> outlook = new Messenger<EmailMessage>();
            outlook.SendMessenger(new EmailMessage("Hello outlook"));

            MessengerTwo<Message, Person> telega = new MessengerTwo<Message, Person>();
            Message hello = new Message("Hello");
            telega.SendMess(person3, person2, hello);


            Worker<int> worker1 = new Worker<int>(12);
            Worker<string> worker2 = new UniversalWorks<string>("33");
            UniversalWorks<int> worker3 = new UniversalWorks<int>(44);
            Console.WriteLine(worker1.Id);
            Console.WriteLine(worker2.Id);
            Console.WriteLine(worker3.Id);

            StringWorker stringWorker = new StringWorker("String StringWorker");
            Worker<string> worker4 = new StringWorker("String Worker");
            Console.WriteLine(stringWorker.Id);
            Console.WriteLine(worker4.Id);


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
