using System.Security.Cryptography;

namespace Intarface
{
    internal class Program
    {
            /*Что может определять интерфейс? В целом интерфейсы могут определять следующие сущности:

            Методы
            
            Свойства
            
            Индексаторы
            
            События
            
            Статические поля и константы (начиная с версии C# 8.0)
            Однако интерфейсы не могут определять нестатические переменные. 
             */
        static void Main(string[] args)
        {
            Person person = new Person("Dima");
            Car car = new Car("BMW");
            IMove aircraft = new Aircraft("Airline");
            DoAction(car);
            aircraft.Move();

            void DoAction(IMove movable) => movable.Move();

            Console.WriteLine("\nМножественная реализация интерфейсов\n");

            Message hello = new Message("hello interface");
            hello.Print();
            if(hello is Message someMessage) someMessage.Print();

            Console.WriteLine("\nЯвная реализация интерфейсов\n");

            Student student = new Student();
            ((ISchool)student).Study();
            ((IUniversity)student).Study();

            Console.WriteLine("\nМодификаторы доступа\n");

            IMovable tom = new Person("Tom");
            // подписываемся на событие
            tom.MoveEvent += () => Console.WriteLine($"{tom.Name} is walking");
            tom.MoveEvent += () => Console.WriteLine($"{tom.Name} is идет");
            tom.Moves();

            Console.WriteLine("\nИнтерфейсы как ограничения обобщений\n");
            // создаем мессенджер
            var telegramm = new Messanger<Message>();
            // создаем сообщение
            var message = new Message("Hello message and ограничения обобщений");
            // отправляем сообщение
            telegramm.Send(message);


            var whatsap = new Messanger<IPrintableMessage>();

            var sms = new PrintableMessage("Hello whtasap");

            whatsap.Send(sms);

            Console.WriteLine("\nПоверхностное копирование\n");

            var tomchik = new Human("Tomchik",23);
            var bobchik = (Human)tomchik.Clone();
            bobchik.Name = "Bobchik";
            Console.WriteLine($"Hello new Human {bobchik.Name} and old Human {tomchik.Name}");

            Console.WriteLine("\nГлубокое копирование\n");

            var dimchik = new Human("Dimchik", 27, new Company("Luch"));
            var sergo = (Human)dimchik.HardClone();
            sergo.Work.Name = "Google";
            Console.WriteLine($"Hello sergo for company = {sergo.Work.Name} and dimchir for company = {dimchik.Work.Name}");

            Console.WriteLine("\nСортировка объектов. Интерфейс IComparable\n");

            var w1 = new Human("Sort1", 23);
            var w2 = new Human("Sort2", 45);
            var w4 = new Human("Sort4", 67);
            var w3 = new Human("Sort3", 50);

            Human[] humans = { w1, w2, w3 , w4};

            foreach(Human human in humans)
            {
                Console.WriteLine($"Name : {human.Name} | age: {human.Age}");
            }

            Console.WriteLine("\nКовариантные интерфейсы\n");

            IMessangerOut<TestMessage> messangerOut = new EmailWriter();
            TestMessage messOut = messangerOut.WriteMessage("Hello world and WriteMessage OUT");
            Console.WriteLine(messOut.Text);//Email : Hello world and WriteMessage OUT

            IMessangerOut<TestEmailMessage> messangerOut2 = new EmailWriter();
            IMessangerOut<TestMessage> messangerOut1 = messangerOut2;
            TestMessage testEmailMess = messangerOut1.WriteMessage("Hi!");
            Console.WriteLine(testEmailMess.Text);// Email: Hi!

            Console.WriteLine("\nКонтравариантные интерфейсы\n");


            IMessangerIn<TestEmailMessage> INmess = new SendMessenger();
            INmess.SendMessage(new TestEmailMessage("Hello sendMessage "));

            IMessangerIn<TestMessage> INMessag = new SendMessenger();
            IMessangerIn<TestEmailMessage> messangerIn = INMessag;

            messangerIn.SendMessage(new TestEmailMessage("Hello new TestEmailMessage sendMessage "));


            Console.WriteLine("\nСовмещение ковариантности и контравариантности\n");

            IMessangeInAndOut<TestEmailMessage, TestMessage> messangeInAndOut = new SimpleMessenger();
            TestMessage testMessage = messangeInAndOut.WriteMessage("Hello IMessangeInAndOut<TestEmailMessage, TestMessage> messangeInAndOut.WriteMessage");
            Console.WriteLine(testMessage.Text);
            messangeInAndOut.SendMessage(new TestEmailMessage("Test Message"));

            IMessangeInAndOut<TestEmailMessage, TestEmailMessage> inAndOut = new SimpleMessenger();
            TestEmailMessage testEmailMessage = inAndOut.WriteMessage("Message from Email");
            inAndOut.SendMessage(testEmailMessage);

            IMessangeInAndOut<TestMessage, TestMessage> andOut = new SimpleMessenger();
            TestMessage simpleMessage = andOut.WriteMessage("Message from Message");
            andOut.SendMessage(simpleMessage);


        }
    }
}
