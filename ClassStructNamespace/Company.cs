using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStructNamespace
{
    internal class Company
    {
        public string Title = "Unknown";

        public Company()
        {
            Console.WriteLine("Создание объекта Company");
        }

        public Company(string Title)
        {
            this.Title = Title;
        }
    }
}
