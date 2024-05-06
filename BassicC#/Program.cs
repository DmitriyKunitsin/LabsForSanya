namespace BassicC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("\nПередача параметров по ссылке и модификатор ref\n");
            int number = 5;
            //Передача параметров по ссылке и модификатор ref
            program.Increment(ref number);

            Console.WriteLine("\nВыходные параметры. Модификатор out\n");
            //Выходные параметры. Модификатор out
            int result;
            program.Sum(10, 20, out result);

            Console.WriteLine($"3. Number in method Sum = {result}");


            program.GetRectangleData(10, 20, out int area, out int perimetr);

            Console.WriteLine($"4. area = {area} , perimetr = {perimetr}");

            // Входные параметры. Модификатор in
            Console.WriteLine("\nВходные параметры. Модификатор in\n");
            //Модификатор in указывает,
            //что данный параметр будет передаваться в метод по ссылке,
            //однако внутри метода его значение параметра нельзя будет изменить.

            program.Multiply(10, 11, out result);

            Console.WriteLine($"5. Multiply IN method = {result}");

            //ref-параметры только для чтения
            Console.WriteLine("\nref-параметры только для чтения\n");

            program.Dicrement(ref result);
            Console.WriteLine($"Число после метода Dicrement = {result}");

            Console.WriteLine("\nМассив параметров и ключевое слово params\n");
            //используя ключевое слово params, мы можем передавать неопределенное количество параметров

            program.SumParams(1, 4, 2, 13, 32, 4, 2, 13, 12, 23);
            program.SumParams(655, 324, 123, 4634, 46, 234);
            program.SumParams();

            int startSubtract = 100;
            program.SubtractParams(ref startSubtract, 19,23,22);
            Console.WriteLine($"startSubtract in method SubtractParams = {startSubtract}");

            Console.WriteLine("\nРекурсивная функция факториала\n");

            int factorial = program.Factorial(5);

            Console.WriteLine($"Factoail for numbers 5 = {factorial}");

            Console.WriteLine("\nРекурсивная функция Фибоначчи\n");

            int fibonachi = program.Fibonachi(5);

            Console.WriteLine($"Fibonachi for numbers 5 = {fibonachi}");




        }
        // Существует два способа передачи параметров в метод в языке C#: по значению и по ссылке.
        void Increment(ref int n)
        {//Передача параметров по ссылке и модификатор ref
            n++;
            Console.WriteLine($"1. Number in method Increment = {n}");

            n += 10;

            Console.WriteLine($"2. Number in method Increment = {n}");
        }

        void Sum(int x, int y, out int result)
        {//Выходные параметры. Модификатор out
            result = x + y;
        }

        void GetRectangleData(int width, int height, out int rectArea, out int rectPerimetr)
        {//Выходные параметры. Модификатор out
            rectArea = width * height;// площадь прямоугольника - произведение ширины на высоту
            rectPerimetr = (width + height) * 2;// периметр прямоугольника - сумма длин всех сторон
        }

        void Multiply(in int x, in int y, out int result)
        {//in внутри метода его значение параметра нельзя будет изменить
            result = x * y;
        }

        void Dicrement(ref readonly int n)
        {
            // n--; нельзя, иначе будет очишка компиляции
            Console.WriteLine($"Number in method Dicrement = {n}");
        }

        void SumParams(params int[] numbers)
        {//Сам параметр с ключевым словом params при определении метода должен представлять одномерный массив того типа,
         //данные которого мы собираемся использовать
            int res = 0;
            int count = 0;
            foreach (int i in numbers)
            {
                res += i;
                count++;
            }
            Console.WriteLine($"Result method SumParams = {res}, all numbers = {count}");
        }

        void SubtractParams(ref int startNumber, params int[] numbers)
        {
            int count = 0;
            foreach (int i in numbers)
            {
                startNumber -= i;
                count++;
            }
            Console.WriteLine($"Result method SubtractParams = {startNumber}, all numbers = {count}");
        }

        int Factorial(int n)
        {
            if(n == 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        int Fibonachi(int n)
        {
            if (n == 0 || n == 1) return n;

            return Fibonachi(n - 1) + Fibonachi(n - 2);
        }


    }
}
