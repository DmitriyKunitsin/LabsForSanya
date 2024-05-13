using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    internal class Car : IMove
    {
        public string Name { get; set; }
        public Car(string name) { this.Name = name; }
        public void Move() => Console.WriteLine($"машина {this.Name} едет");
    }
}
