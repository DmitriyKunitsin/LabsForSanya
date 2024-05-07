using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassStructNamespace
{
    internal class MyNullable
    {
        public void PrintNullable(int? numb)
        {
            //   Console.WriteLine(numb.Value);    // ! Ошибка
            //   Console.WriteLine(numb);          // Ошибки нет - просто ничего не выведет
            if (numb.HasValue)
            {
                Console.WriteLine(numb.Value);
                // или
                //Console.WriteLine(numb);
            }
            else
            {
                Console.WriteLine("параметр равен null");
            }
        }

        public void MyGetVal(int? n)
        {
            n = null;
            Console.WriteLine(n.GetValueOrDefault());// 0  - значение по умолчанию для числовых типов
            Console.WriteLine(n.GetValueOrDefault(10));// 10
            // метод GetValueOrDefault(). Он возвращает значение переменной/параметра,
            // если они не равны null. Если они равны null,
            // то возвращается значение по умолчанию.
            n = 15;

            Console.WriteLine(n.GetValueOrDefault()); // 15
            Console.WriteLine(n.GetValueOrDefault(10)); // 15

        }

        //Преобразование значимых nullable-типов

        void TransformTypeTinT1(int? n)
        {//явное преобразование от T? к T
            if (n.HasValue)
            {
                int x2 = (int)n;
                Console.WriteLine(x2);
            }
        }

        void TransformTypeTinT2(int n)
        {//неявное преобразование от T к T?
            int? x2 = n;
            Console.WriteLine(x2);
        }

        void TransformTypeVinT1(int x1)
        {//неявные расширяющие преобразования от V к T?
            long? x2 = x1;
            Console.WriteLine(x2);
        }

        void TransformTypeVinT2(long x1)
        {//явные сужающие преобразования от V к T?
            int? x2 = (int?)x1;
            Console.WriteLine(x2);
        }

        public void TransformVinT3(long? x1)
        {//явные сужающие преобразования от V? к T?
            int? x2 = (int?)x1;
            Console.WriteLine(x2);
        }

        public void TransVinT(long? x1 = null)
        {//явные сужающие преобразования от V? к T
            if (x1.HasValue)
            {
                int x2 = (int)x1;
                Console.WriteLine(x2);
            }
        }



    }
}
