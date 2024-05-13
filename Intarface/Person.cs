using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Intarface.IMovable;

namespace Intarface
{
    internal class Person : IMovable
    {

        string name;
        public event MoveHeandler? moveEvent;
        event MoveHeandler IMovable.MoveEvent
        {
            add => moveEvent += value;
            remove => moveEvent -= value;
        }
        string IMovable.Name { get => name; }
        public Person(string name) => this.name = name;
        void IMovable.Moves()
        {
            Console.WriteLine($"{name} is walking");
            moveEvent?.Invoke();
        }

        public void Move() => Console.WriteLine("Человек идет");

    }
}
