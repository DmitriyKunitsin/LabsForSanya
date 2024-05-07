using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStructNamespace
{
    internal class MyChechkNulable
    {
        public void PrintUpper(string text)
        {
            if (text != null)
            {
                Console.WriteLine(text.ToUpper());
            }
        }

        //с помощью оператора is мы можем проверить значение объекта:
        //объект is значение

        public void PrintLower(string text)
        {
            if (text is not null)
            {
                Console.WriteLine(text.ToLower());
            }
            // ИЛИ
            if (text is null)
            {
                return;
            }
            // OR
            if (text is string)
            {
                Console.WriteLine(text.ToLower());
            }
        }

        // null-объединения
        // Оператор ??
        // Он применяется для установки значений по умолчанию для типов, которые допускают значение null:
        // левый_операнд ?? правый_операнд
        // Оператор ?? возвращает левый операнд, если этот операнд не равен null.
        // Иначе возвращается правый операнд. При этом левый операнд должен принимать null
        public void myTestOperand(string? text = null)
        {
            string name = text ?? "TOM"; // равно Tom, так как text равен null
            Console.WriteLine(name);// Tom

            int? id = 200;
            int peronid = id ?? 1;// равно 200, так как id не равен null
            Console.WriteLine(peronid);// 200

            //можно использовать производный оператора ??=

            string? test = null;

            test ??= "TEST ??=";// аналогично test = test ?? "Sam";
            Console.WriteLine(test);


        }





    }
}
