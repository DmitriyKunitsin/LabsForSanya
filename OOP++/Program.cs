using static OOP__.Company;

namespace OOP__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = new Counter { Value = 45 };
            Counter counter2 = new Counter { Value = 95 };
            bool result = counter1 > counter2;
            Console.WriteLine(result);//false

            Counter counter3 = counter1 + counter2;
            Console.WriteLine(counter3.Value);//140

            result = counter3 > counter2;
            Console.WriteLine(result);//true

            int resultInt = counter3 + 111;//251
            Console.WriteLine(resultInt);

            ++counter3;
            Console.WriteLine(counter3.Value); // 150

            counter3.Value += resultInt;

            Console.WriteLine(counter3.Value);//401


            Counter BoolConter = new Counter { Value = 0 };

            if (!BoolConter) // BoolConter == 0
            {
                Console.WriteLine(true); // true
            }
            else
            {
                Console.WriteLine(false);
            }

            if (BoolConter)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false); // false
            }

            Console.WriteLine("\nПерегрузка операций преобразования типов\n");

            Console.WriteLine("\nexplicit and implicit \n");
            CounterSecond counterSecond = new CounterSecond { Second = 60 };
            //explicit - явное преобразование
            int secondNow = (int)counterSecond;
            Console.WriteLine(secondNow); // 60
            // implicit - неявное преобразование
            CounterSecond counterSecond2 = secondNow;
            Console.WriteLine(counterSecond2.Second); // 60

            CounterSecond second = new CounterSecond { Second = 65932 };

            Timer timer = second;
            Console.WriteLine($"{timer.Hours}:{timer.Minutes}:{timer.Seconds}");//18:18:52

            CounterSecond second2 = (CounterSecond)timer;
            Console.WriteLine(second2.Second);//65932


            Console.WriteLine("\nИндексаторы\n");

            var microsoft = new Company(new[]
            {
                new Person("Tom"), new Person("Dima"), new Person("Serega"), new Person("Oleg")
            });// получаем объект из индексатора

            Person firsPerson = microsoft[0];
            Console.WriteLine(firsPerson.Name); // Tom

            // переустанавливаем объект
            microsoft[0] = new Person("Vadim");
            Console.WriteLine(microsoft[0].Name); // Vadim

            User tom = new User();
            // устанавливаем значения
            tom["name"] = "Tomchik";
            tom["email"] = "tom@gmail.ru";
            tom["phone"] = "+1234556767";

            // получаем значение
            Console.WriteLine(tom["name"]); // Tom

            Console.WriteLine("\nСсылка как результат функции\n");

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            ref int numberRef = ref Find(4, numbers);
            numberRef = 34;
            Console.WriteLine(numbers[3]); // 34


            static ref int Find(int number, int[] numbers)
            {
                for (int i = 0; i < numbers.Length; ++i)
                {
                    if (numbers[i] == number)
                    {
                        return ref numbers[i];
                    }
                }
                throw new IndexOutOfRangeException("число не найдено");
            }



        }
    }
}
