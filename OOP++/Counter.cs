using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP__
{
    internal class Counter
    {
        public int Value { get; set; }

        public static Counter operator +(Counter a, Counter b) // +
        {
            return new Counter { Value = a.Value + b.Value };
        }
        public static bool operator >(Counter a, Counter b) // > 
        {
            return a.Value > b.Value;
        }
        public static bool operator <(Counter a, Counter b) // < 
        {
            return a.Value < b.Value;
        }

        public static int operator +(Counter a, int b) // +
        {
            return a.Value + b;
        }

        public static Counter operator ++(Counter a) // ++
        {
            return new Counter { Value = a.Value + 10 };
        }
        public static bool operator !(Counter counter) // !
        {
            return counter.Value == 0;
        }

        public static bool operator true(Counter counter) // true
        {
            return counter.Value != 0;
        }
        public static bool operator false(Counter counter) // false
        {
            return counter.Value == 0;
        }

    }
}
