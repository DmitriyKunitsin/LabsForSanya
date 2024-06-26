﻿using System.Threading.Channels;

namespace Closures
{//Замыкание (closure) представляет объект функции,
 //который запоминает свое лексическое окружение даже в том случае,
 //когда она выполняется вне своей области видимости.
    internal class Program
    {//Технически замыкание включает три компонента:

        // - внешняя функция, которая определяет некоторую область видимости и в которой определены некоторые переменные
        // и параметры - лексическое окружение
        // - переменные и параметры(лексическое окружение), которые определены во внешней функции
        // - вложенная функция, которая использует переменные и параметры внешней функции


        //В языке C# реализовать замыкания можно разными способами - с помощью локальных функций и лямбда-выражений.
        static void Main(string[] args)
        {
            //создание замыканий через локальные функции:
            Console.WriteLine("\nCоздание замыканий через локальные функции\n");
            var fn = Outer();// fn = Inner, так как метод Outer возвращает функцию Inner

            fn();//6
            fn();//7
            fn();//8

            Action Outer()// метод или внешняя функция
            {//Здесь метод Outer в качестве возвращаемого типа имеет тип Action,
             //то есть метод возвратить функцию, которая не принимает параметров и имеет тип void.
                int x = 5;
                void Inner() // локальная функция
                {
                    x++;// операции с лексическим окружением
                    Console.WriteLine(x);
                }
                return Inner;// возвращаем локальную функцию
            }
            Console.WriteLine("\nРеализация с помощью лямбда-выражений\n");
            //С помощью лямбд можно сократить определение замыкания:
            var outerFn = () =>
            {
                int x = 10;
                var innerFn = () => Console.WriteLine(++x);
                return innerFn;
            };

            var FF = outerFn();

            FF();//11
            FF();//12
            FF();//13
            FF();//14


            //Применение параметров
            Console.WriteLine("\nПрименение параметров\n");
            //Кроме внешних переменных к лексическому окружению также
            //относятся параметры окружающего метода. Рассмотрим использование параметров:

            var GG = Multiply(5);

            Console.WriteLine(GG(5));//20
            Console.WriteLine(GG(6));//30
            Console.WriteLine(GG(7));//35

            //Здесь внешняя функция - метод Multiply возвращает функцию,
            //которая принимает число int и возвращает число int.
            Operation Multiply(int x)
            {

                int Inner(int m)
                {
                    return x * m;
                }

                return Inner;
                //Для этого определен делегат Operation,
                //который будет представлять возвращаемый тип
            }

            // OR________________________________

            var multiply2 = (int x) => (int m) => x * m;

            var GG2 = multiply2(5);

            Console.WriteLine("\n" + GG2(5));
            Console.WriteLine(GG2(6));
            Console.WriteLine(GG2(7));

        }
        delegate int Operation(int x);
    }
}
