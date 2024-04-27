namespace DelegatesActionPredicateFunc
{
    //В .NET есть несколько встроенных делегатов, которые используются в различных ситуациях.
    //И наиболее используемыми, с которыми часто приходится сталкиваться,
    //являются Action, Predicate и Func.
    internal class Program
    {
        public delegate void Action();

        /// <summary>
        /// Данный делегат имеет ряд перегруженных версий.Каждая версия принимает разное число параметров: от Action&lt;in T1&gt; до Action&lt;in T1, in T2,....in T16&gt;.Таким образом можно передать до 16 значений в метод.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        public delegate void Action<in T>(T obj);

        /// <summary>Делегат Predicate&lt;T&gt; принимает один параметр и возвращает значение типа bool</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public delegate bool Predicate<in T>(T obj);

        static void Main(string[] args)
        {

            Console.WriteLine("\nAction\n");

            void DoOperation(int a, int b, Action<int, int> action) => action(a, b);

            DoOperation(5, 5, Add);
            DoOperation(5, 5, Multiply);


            void Add(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
            void Multiply(int x, int y) => Console.WriteLine($"{x} * {y} = {x * y}");


            Console.WriteLine("\nPredicate\n");
            //Делегат Predicate<T> принимает один параметр и возвращает значение типа bool:

            Predicate<int> isPositive = (int x) => x > 0;
            //Как правило, используется для сравнения, сопоставления некоторого объекта T определенному условию.
            //В качестве выходного результата возвращается значение true,
            //если условие соблюдено, и false, если не соблюдено
            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));

            Console.WriteLine("\nFunc\n");

            //Еще одним распространенным делегатом является Func.
            //Он возвращает результат действия и может принимать параметры.
            //Он также имеет различные формы: от Func<out T>(),
            //где T - тип возвращаемого значения, до Func<in T1, in T2,...in T16, out TResult>(),
            //то есть может принимать до 16 параметров.
            //TResult Func<out TResult>()
            //TResult Func<in T, out TResult>(T arg)
            //TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2)
            //TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3)
            //TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            // TResult - это тип данных результата функции.
            // in T - Тип данных входного аргумента функции.
            // out TResult -  Результат

            int result1 = DoOparetin2(6, DoubleNumber);
            int result2 = DoOparetin2(6, SquareNumber);

            int result3 = DoOperation3(6, 6, Add2);
            int result4 = DoOperation3(6, 6, Minus);

            int DoOparetin2(int x, Func<int, int> operation) => operation(x);
            int Add2(int a, int b) => a + b;
            int Minus(int a, int b) => a - b;
            int DoOperation3(int a, int b, Func<int, int, int> operation) => operation(a, b);
            //Метод DoOperation() в качестве параметра принимает делегат Func<int, int>,
            //то есть ссылку на метод, который принимает число int и возвращает также значение int.


            Func<int, int, int> Add3 = (x, y) =>
            {
                return x + y;
            };
            int result5 = DoOperation3(6, 6, (a, b) => Add3(a, b));

            int TestSubtract(int a, int b) => a - b;

            int TestDoOperation(int a, int b, Func<int, int, int> operation)
            {
                Console.WriteLine($"Нахожусь внутри функции TestDoOperation для выполнения {a} - {b}");
                return operation(a, b);
            }

            int DoubleNumber(int x) => 2 * x;
            int SquareNumber(int x) => x * x;
            Console.WriteLine($"DoubleNumber = 2 * 6 = {result1}");
            Console.WriteLine($"SquareNumber = 6 * 6 = {result2}");
            Console.WriteLine($"Add2 = 6 + 6 = {result3}");
            Console.WriteLine($"Minus = 6 - 6 = {result4}");
            Console.WriteLine($"DoOperation3 = {result5}");
            int result6 = TestDoOperation(6, 6, TestSubtract);
            Console.WriteLine($"TestDoOperation = {result6}");


            Func<int, int, string> createStrin = (a, b) => $"{a}{b}";
            //Здесь переменная createString представляет лямбда-выражение,
            //которое принимает два числа int и возвращает строку,
            //то есть представляет делегат Func<int, int, string>.
            Console.WriteLine(createStrin(1, 5));
            Console.WriteLine(createStrin(4, 6));
        }
    }
}
