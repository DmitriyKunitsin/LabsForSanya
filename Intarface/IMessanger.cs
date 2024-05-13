using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    internal interface IMessanger<in T, out K>
    {
        void SendMessage(T message);
        K WriteMessage(string text);
    }
}
