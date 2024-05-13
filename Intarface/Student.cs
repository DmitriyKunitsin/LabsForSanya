using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    internal class Student : ISchool, IUniversity
    {
        void ISchool.Study() => Console.WriteLine("Учиться в школе");
        void IUniversity.Study() => Console.WriteLine("Учиться в университете");
    }
}
