using System.Collections.Generic;
using System.Linq;
using WordSorter.AppManager;
using WordSorter.Model;

namespace WordSorter.Helpers
{
    public class DataHelper
    {
        private ApplicationManager _app;

        public DataHelper(ApplicationManager app)
        {
            _app = app;
        }
        
        public OutputData GetSortedData(InputData inputData)
        {
            var sortedData = new OutputData
            {
                Quantity = inputData.Quantity,
                WordItems = inputData.WordItems
            };
            sortedData.SortedWords = SortWords(GetReversedWords(inputData.WordItems));

            return sortedData;
        }

        private List<Word> GetReversedWords(List<Word> words)
        {
            var tempCollection = new List<Word>();

            foreach (var word in words)
            {
                tempCollection.Add(word);
            }

            var wordsWithSameParams = new List<Word>();

            for (int i = 0; i < tempCollection.Count; i++)
            {
                var selection = tempCollection.Distinct()
                        .Where(word => word.Length == tempCollection[i].Length && word.Vowels == tempCollection[i].Vowels).ToList();

                foreach (var selected in selection)
                {
                    tempCollection.Remove(selected);
                }

                if (selection.Count > 1)
                {
                    wordsWithSameParams.AddRange(selection);
                }
            }
            wordsWithSameParams.Reverse();
            
            return wordsWithSameParams.Union(words).ToList();
        }

        private List<string> SortWords(List<Word> words)
        {
            var sortedWords = new List<Word>();
            sortedWords.AddRange(words.OrderByDescending(w => w.Vowels).ThenByDescending(w => w.Length));

            return sortedWords.Select(word => word.Value).ToList();
        }
    }
}