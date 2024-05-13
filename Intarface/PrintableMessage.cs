using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    interface IPrintableMessage : IPrintable, IMessage { }
    internal class PrintableMessage : IPrintableMessage
    {
        public string Text { get; }
        public PrintableMessage(string text) => this.Text = text;
        public void Print() => Console.WriteLine(this.Text);
    }
}
