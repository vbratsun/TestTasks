using System;
using WordSorter.Model;

namespace WordSorter.Helpers
{
    public class OutputHelper
    {
        public void PerformData(OutputData outputData)
        {
            Console.WriteLine("Вывод:");
            foreach (var word in outputData.SortedWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}