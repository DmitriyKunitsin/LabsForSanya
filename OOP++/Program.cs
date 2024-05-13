namespace OOP__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = new Counter { Value = 45};
            Counter counter2 = new Counter { Value = 95};
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

            if(!BoolConter) // BoolConter == 0
            {
                Console.WriteLine(true); // true
            } else
            {
                Console.WriteLine(false);
            }

            if(BoolConter)
            {
                Console.WriteLine(true); 
            }
            else
            {
                Console.WriteLine(false); // false
            }


        }
    }
}
