using System;
using WordSorter.AppManager;
using WordSorter.Model;

namespace WordSorter.Helpers
{
    public class OutputHelper
    {
        private ApplicationManager _app;

        public OutputHelper(ApplicationManager app)
        {
            //_app = app;
        }

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