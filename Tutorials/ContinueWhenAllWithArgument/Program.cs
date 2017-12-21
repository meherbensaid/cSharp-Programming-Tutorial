using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ContinueWhenAllWithArgument
{
    class Program
    {
        private const string PATH = @"D:\cSharp-Programming-Tutorial\Tutorials\ContinueWhenAllWithArgument";
        public static void Main()
        {
            string[] filenames = { $"{PATH}\\chapter1.txt", $"{PATH}\\chapter2.txt"};
            string pattern = @"\b\w+\b";
            var tasks = new List<Task>();
            int totalWords = 0;

            // Determine the number of words in each file.
            foreach (var filename in filenames)
                tasks.Add(Task.Factory.StartNew(fn => {
                    var chaine=fn.ToString();
                    if (!File.Exists(fn.ToString()))
                        throw new FileNotFoundException("{0} does not exist.", filename);

                    StreamReader sr = new StreamReader(fn.ToString());
                    String content = sr.ReadToEnd();
                    sr.Close();
                    int words = Regex.Matches(content, pattern).Count;
                    Interlocked.Add(ref totalWords, words);
                    Console.WriteLine("{0,-25} {1,6:N0} words", fn, words);
                },
                                                  filename));

            var finalTask = Task.Factory.ContinueWhenAll(tasks.ToArray(), wordCountTasks => {
                int nSuccessfulTasks = 0;
                int nFailed = 0;
                int nFileNotFound = 0;
                foreach (var t in wordCountTasks)
                {
                    if (t.Status == TaskStatus.RanToCompletion)
                        nSuccessfulTasks++;

                    if (t.Status == TaskStatus.Faulted)
                    {
                        nFailed++;
                        t.Exception.Handle((e) => {
                            if (e is FileNotFoundException)
                                nFileNotFound++;
                            return true;
                        });
                    }
                }
                Console.WriteLine("\n{0,-25} {1,6} total words\n",
                                  String.Format("{0} files", nSuccessfulTasks),
                                  totalWords);
                if (nFailed > 0)
                {
                    Console.WriteLine("{0} tasks failed for the following reasons:", nFailed);
                    Console.WriteLine("   File not found:    {0}", nFileNotFound);
                    if (nFailed != nFileNotFound)
                        Console.WriteLine("   Other:          {0}", nFailed - nFileNotFound);
                }
            });
            finalTask.Wait();
        }
    }
}
