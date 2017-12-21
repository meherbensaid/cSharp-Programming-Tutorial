using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WordCountClass w = new WordCountClass();
            w.FindWordCounts();
        }
    }
}
