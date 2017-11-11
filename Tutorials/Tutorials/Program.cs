using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscriber subscriber = new Subscriber() { value=140};
            subscriber.Increase(10);
            
        }
    }
}
