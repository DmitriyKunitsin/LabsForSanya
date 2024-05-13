using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    internal interface IMovable
    {
        protected internal delegate void MoveHeandler();
        void Move() => Console.WriteLine("Реализация метода интерфейса по умолчанию");
        protected internal void Moves();
        protected internal string Name { get; }
        protected internal event MoveHeandler MoveEvent;
    }
}
