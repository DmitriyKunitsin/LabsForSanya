using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP__
{
    internal class CounterSecond
    {
        public int Second { get; set; }

        public static implicit operator CounterSecond(int second)
        {// implicit - неявное преобразование
            return new CounterSecond { Second = second };
        }

        public static explicit operator int(CounterSecond counter)
        {//explicit - явное преобразование
            return counter.Second;
        }
        public static explicit operator CounterSecond(Timer timer)
        {// из таймера в секунды
            int h = timer.Hours * 3600;
            int m = timer.Minutes * 60;
            return new CounterSecond { Second = h + m + (int)timer.Seconds };
        }
        public static implicit operator Timer(CounterSecond counter)
        {
            int h = counter.Second / 3600;
            int m = (counter.Second % 3600) / 60;
            int s = (counter.Second % 60);
            return new Timer { Hours = h, Minutes = m, Seconds = s };
        }





    }
}
