using System.Threading.Channels;

namespace Lambdas
{
    //Лямбда-выражения представляют упрощенную запись анонимных методов.
    //Лямбда-выражения позволяют создать емкие лаконичные методы,
    //которые могут возвращать некоторое значение и которые можно передать в качестве параметров в другие методы.
    internal class Program
    {
        //Ламбда-выражения имеют следующий синтаксис:
        //слева от лямбда-оператора => определяется список параметров,
        //а справа блок выражений, использующий эти параметры:
        //(список_параметров) => выражение
        /// <summary>delegate void Message();</summary>
        delegate void Message();
        /// <summary>delegate int AddCount(int i);</summary>
        /// <param name="i">The i.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        delegate int AddCount(int i);
        /// <summary>delegate void Operation(int a, int b);</summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        delegate void Operation(int a, int b);
        /// <summary>delegate bool IsEqual(int x);</summary>
        /// <param name="x">The x.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        delegate bool IsEqual(int x);
        /// <summary>delegate int MathOperation(int a, int b);</summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        delegate int MathOperation(int a, int b);
        /// <summary>delegate void PrintHandler(string message);</summary>
        /// <param name="message">The message.</param>
        delegate void PrintHandler(string message);

        enum OperationType
        {
            Add, Subtract, Multiply
        }
        static void Main(string[] args)
        {
            //С точки зрения типа данных лямбда-выражение представляет делегат.
            //Например, определим простейшее лямбда-выражение:
            //delegate void Message();
            Message Hello = () => Console.WriteLine("Hello");
            Hello();
            Hello();
            Hello();
            //delegate int AddCount(int i);
            AddCount count = (int i) =>
            {
                Console.Write($"Значение лямбды {i}\t");
                return ++i;
            };
            // Если использовать i++, то увлечиения не будет
            // Постфиксный оператор инкремента i++ увеличивает значение i, но возвращает его значение до увеличения. 
            for (int i = 0; i < 10;)
            {
                Console.Write($"\nЦикл номер {i}\t");
                i = count(i);
                Console.Write($"Значение I после лямбды {i}\n");
            }

            Message Hello_2 = () =>
            {
                Console.WriteLine("\nВас приветствует");
                Console.WriteLine("Hello 2");
            };
            Hello_2();

            Console.WriteLine("\nПараметры лямбды\n");
            //delegate void Operation(int a, int b);
            //При определении списка параметров мы можем не указывать для них тип данных:
            Operation operation = (a, b) => Console.WriteLine($"{a}+{b} = {a + b}");
            operation(5, 5);
            operation(10, 12);
            operation(10, 33);
            //При определении списка параметров мы можем не указывать для них тип данных:
            //Однако если мы применяем неявную типизацию, то у компилятора могут возникнуть трудности,
            //чтобы вывести тип делегата для лямбда-выражения, например, в следующем случае
            // var sum = (x, y) => Console.WriteLine($"{x} + {y} = {x + y}");   // ! Ошибка
            var sum = (int a, int b) => Console.WriteLine($"{a}+{b} = {a + b}");
            sum(5, 5);
            sum(10, 12);
            sum(10, 33);
            //Если лямбда имеет один параметр, для которого не требуется указывать тип данных, то скобки можно опустить:
            PrintHandler printHandler = message => Console.WriteLine(message);
            printHandler("\nHello");
            printHandler("PrintHandler Лямда с не указанным типом данных ");

            //Начиная с C# 12 параметры лямбда-выражений могут иметь значения по умолчанию:
            var welcome = (string message = "\nЛямда со значением по умолчанию") => Console.WriteLine(message);

            welcome();// Hello
            welcome("Hello world");// Hello world

            Console.WriteLine("\nВозвращение результата\n");

            //Лямбда-выражение может возвращать результат. Возвращаемый результат можно указать после лямбда-оператора:
            var sumReturn = (int a, int b) => a + b;
            int sumResult = sumReturn(5, 5);//10
            Console.WriteLine(sumResult);

            MathOperation multpy = (a, b) => a * b;
            int multyResult = multpy(5, 5);
            Console.WriteLine(multyResult);

            //Если лямбда-выражение содержит несколько выражений (или одно выражение в фигурных скобках),
            //тогда нужно использовать оператор return, как в обычных методах:

            var subtract = (int x, int y) =>
            {
                if (x > y) return x - y;
                else return y - x;
            };
            int resultSubOne = subtract(10, 5);
            // или так
            // TResult func<int T1, int T2, out TResult>(T1 arg, T2 arg)
            Func<int, int, int> subtract2 = (a, b) =>
            {
                return (a > b) ? a - b : b - a;
            };
            int resultSubTwo = subtract2(10, 5);
            Console.WriteLine($"\nИспользование лямды с return первый вариант :{resultSubOne}, второй :{resultSubTwo}");

            Console.WriteLine("\nДобавление и удаление действий в лямбда-выражении\n");

            var hello = () => Console.Write("Приветствие\n");
            hello();

            var message = () => Console.WriteLine("Message");
            message += hello;// добавляем лямбда-выражение из переменной hello
            message += Print;// добавляем метод

            message();

            Console.WriteLine("__________________________________");

            message -= Print;// удаляем метод
            message -= hello;// удаляем лямбда-выражение из переменной hello

            message?.Invoke();// на случай, если в message больше нет действий

            void Print() => Console.WriteLine("Welcome to C#");

            Console.WriteLine("\nЛямбда-выражение как аргумент метода\n");


            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //найдем сумму чисел больше 5
            int resultOne = Sum(integers, x => x > 5);
            Console.WriteLine($"суммa чисел больше 5 : " + resultOne);

            // найдем сумму четных чисел
            int resultTwo = Sum(integers, x => x % 2 == 0);
            Console.WriteLine($"суммa четных чисел  : " + resultTwo);
            //В цикле проходим по всем числам и складываем их.
            //Причем складываем только те числа, для которых делегат IsEqual func возвращает true.
            //То есть делегат IsEqual здесь фактически задает условие, которому должны соответствовать значения массива.
            //Но на момент написания метода Sum нам неизвестно, что это за условие.
            int Sum(int[] numbers, IsEqual func)
            {
                int result = 0;
                foreach (int i in numbers)
                {
                    if (func(i))
                        result += i;
                }
                return result;
            }

            Console.WriteLine("\nЛямбда-выражение как результат метода\n");

            //Метод также может возвращать лямбда-выражение.
            //В этом случае возвращаемым типом метода выступает делегат,
            //которому соответствует возвращаемое лямбда-выражение. Например:

            MathOperation mathOperation = SelectedOperation(OperationType.Add);
            Console.WriteLine($"Результат метода Add 5 + 10 = " + mathOperation(5, 10));
            mathOperation = SelectedOperation(OperationType.Subtract);
            Console.WriteLine($"Результат метода Subtract 12 - 7 = " + mathOperation(12, 7));
            mathOperation = SelectedOperation(OperationType.Multiply);
            Console.WriteLine($"Результат метода Multiply 12 * 7 = " + mathOperation(12, 7));

            MathOperation SelectedOperation(OperationType opType)
            {
                switch (opType)
                {
                    case OperationType.Add: return (x, y) => x + y;
                    case OperationType.Subtract: return (x, y) => x - y;
                    default: return (x, y) => x * y;
                }
            }








        }
    }
}
