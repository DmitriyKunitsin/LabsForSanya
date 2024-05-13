using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    //Ковариантные интерфейс
    interface IMessangerOut<out T>
    {
        T WriteMessage(string text);
    }


    class TestMessage
    {
        public string Text { get; set; }
        public TestMessage(string text) => Text = text;
    }
    
    class TestEmailMessage : TestMessage
    {
        public TestEmailMessage(string text) : base(text) { }
    }
    class EmailWriter : IMessangerOut<TestEmailMessage>
    {
        public TestEmailMessage WriteMessage(string text)
        {
            return new TestEmailMessage($"Email : {text}");
        }
    }
    //Контравариантные интерфейс
    interface IMessangerIn<in T>
    {
        void SendMessage(T message);
    }

    class SendMessenger : IMessangerIn<TestMessage>
    {
        public void SendMessage(TestMessage message)
        {
            Console.WriteLine($"Отправляется сообщение: {message.Text}");
        }
    }

    //Совмещение ковариантности и контравариантности

    interface IMessangeInAndOut<in T, out K>
    {
        void SendMessage(T message);
        K WriteMessage(string text);
    }

    internal class SimpleMessenger : IMessangeInAndOut<TestMessage, TestEmailMessage>
    {
        public void SendMessage(TestMessage message)
        {
            Console.WriteLine($"Отправляется сообщение: {message.Text}");
        }

        public TestEmailMessage WriteMessage(string text)
        {
            return new TestEmailMessage($"Email : {text}");
        }

    }



}
