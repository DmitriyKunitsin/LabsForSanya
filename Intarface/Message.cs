using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    internal class Message : IMessage, IPrintable
    {
        public string Text { get; }
        public Message(string message) => Text = message;
        public void Print() => Console.WriteLine(Text);
    }
}
