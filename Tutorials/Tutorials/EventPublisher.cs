using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    public class EventPublisher
    {
       

        public delegate void BeforePrint(string meessage);
        public event BeforePrint beforePrintEvent;

        public void Increase(int value)
        {
            if (beforePrintEvent != null)
            {
                beforePrintEvent("hello");
            }
            Console.WriteLine("value is {0}",value);
        }
        

    }
}
