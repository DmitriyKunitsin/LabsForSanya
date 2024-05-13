using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    internal class Aircraft : IMove
    {
        public string Name { get; set; }
        public Aircraft(string name)
        {
            Name = name;
        }
    }
}
