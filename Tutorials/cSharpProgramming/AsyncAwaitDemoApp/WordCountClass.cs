using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsyncAwaitDemoApp
{
    public class Words
    {
        public string WordName { get; set; }
        public int NoOfOccurance { get; set; }
    }

    public class WordCountClass
    {
        /// 
        /// Reads through the file, generates unique words and its number of occurrences
        /// 
        /// 
        public List<Words> FindWordCounts()
        {
            //Ensure that LongFile.txt exists
            var words = Regex.Matches(File.ReadAllText(@"C:\TheWalkingDead\LongFile.txt"), @"\w+").Cast<Match>()
            .Select((m, pos) => new { Word = m.Value, Pos = pos })
            .GroupBy(s => s.Word, StringComparer.CurrentCultureIgnoreCase)
            .Select(g => new Words { WordName = g.Key, NoOfOccurance = g.Select(z => z.Pos).Count() })
            .ToList();

            return words;
        }

        /// 
        /// Reads through the file, generates unique words and its number of occurrences using Async and Await
        /// 
        /// 
        public async Task<List<Words>> FindWordCountsAsync()
        {
            //Ensure that LongFile.txt exists
            var words = Regex.Matches(File.ReadAllText(@"C:\TheWalkingDead\LongFile.txt"), @"\w+").Cast<Match>()
            .Select((m, pos) => new { Word = m.Value, Pos = pos })
            .GroupBy(s => s.Word, StringComparer.CurrentCultureIgnoreCase)
            .Select(g => new Words { WordName = g.Key, NoOfOccurance = g.Select(z => z.Pos).Count() });

            //This is more like Task-Based Asynchronous Pattern
            return await Task.Run(() => words.ToList());
        }
    }
}
