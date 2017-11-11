using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    public class Subscriber
    {
        public int value { get; set; }
        private EventPublisher eventPublisher;

        public Subscriber()
        {
            eventPublisher = new EventPublisher();
            eventPublisher.beforePrintEvent += log;
        }
        public void Increase(int value)
        {
            eventPublisher.Increase(value);
        }

        public void log(string message)
        {
            Console.WriteLine("log before add {0}",message);
        }
    }
}
