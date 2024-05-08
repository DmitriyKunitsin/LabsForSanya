using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Generic
    {
        public static void SendMessage<T>(T message) where T : Message
        {
            Console.WriteLine($"Отправляется сообщение: {message.Text}");
        }
    }

    class Gen<T>
    {//Угловые скобки в описании class Gen<T> указывают,
     //что класс является обобщенным, а тип T,
     //заключенный в угловые скобки, будет использоваться этим классом.
        public T Id { get; set; }
        public string Name { get; set; }
        public Gen(T id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    /*
     Gen<int> test1 = new Gen<int>(545, "Test");// упаковка не нужна
     Gen<string> test2 = new Gen<string>("abc123", "Test2");

    int testId = test1.Id;// распаковка не нужна
    string testStringId = test2.Id; // преобразование типов не нужно

     */
    class Company<P>
    {
        public P CEO { get; set; }// президент компании
        public Company(P CEO)
        {
            this.CEO = CEO;
        }

    }
    class Works<T>
    {
        public static T? code;
        public T Id { get; set; }
        public string Name { get; set; }
        public Works(T Id, string name)
        {
            this.Id = Id;
            Name = name;
        }
    }

    class Lesson<T, K>
    {
        public T Id { get; set; }
        public K Password { get; set; }
        public string Name { get; set; }
        public Lesson(T id, K password, string name)
        {
            Id = id;
            Password = password;
            Name = name;
        }
    }

    class Message
    {
        public string Text { get; } // текст сообщения
        public Message(string text)
        {
            Text = text;
        }
    }

    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }

    class SmsMessage : Message
    {
        public SmsMessage(string text) : base(text) { }
    }

    class Messenger<T> where T : Message
    {
        public void SendMessenger(T message)
        {
            Console.WriteLine($"Отправляется сообщение: {message.Text}");
        }
    }

    class MessengerTwo<T, P>
        where T : Message
        where P : Person
    {
        public void SendMess(P sender, P reciever, T message)
        {
            Console.WriteLine($"Отправитель: {sender.Name}");
            Console.WriteLine($"Получатель: {reciever.Name}");
            Console.WriteLine($"Сообщение: {message.Text}");
        }
    }

    class Worker<T>
    {
        public T Id { get; set; }
        public Worker(T id)
        {
            Id = id;
        }
    }

    class UniversalWorks<T> : Worker<T>
    {
        public UniversalWorks(T id) : base(id) { }
    
    
    }

    class StringWorker : Worker<string>
    {
        public StringWorker(string text) : base(text) { }
    }
}
