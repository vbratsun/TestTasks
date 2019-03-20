using System;
using System.Collections.Generic;
using System.Linq;
using WordSorter.AppManager;
using WordSorter.Extensions;
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

        public InputData GetStubData()
        {
            return new InputData
            {
                Quantity = 5,
                PlainWords = "Кашалот Катафалк Шар Трактор Яблоко"
            };
        }

        public InputData GetData()
        {
            var userInputData = new InputData();

            Console.WriteLine("Введите количество слов для сортировки:");
            userInputData.Quantity = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Введите слова для сортировки через пробел:");
            userInputData.PlainWords = Console.ReadLine();

            return userInputData;
        }

        public InputData GetPreparedInputData(InputData inputData, char delimiter = ' ')
        {
            var filledInData = new InputData
            {
                PlainWords = inputData.PlainWords,
                Quantity = inputData.Quantity,
                WordItems = new List<Word>()
            };

            var incomingWords = inputData.PlainWords.Split(delimiter).ToList();

            foreach (var item in incomingWords)
            {
                var word = new Word
                {
                    Value = item,
                    Length = item.Length,
                    Vowels = item.GetVowelsQuantity()
                };

                filledInData.WordItems.Add(word);
            }

            return filledInData;
        }

        public OutputData GetSortedData(InputData inputData)
        {
            var sortedData = new OutputData
            {
                Quantity = inputData.Quantity,
                WordItems = inputData.WordItems
            };

            sortedData.SortedWords = SortWords(inputData.WordItems);

            return sortedData;
        }

        private List<string> SortWords(List<Word> words)
        {
            var sortedWords = new List<Word>();

            sortedWords.AddRange(words.OrderByDescending(w => w.Vowels).ThenByDescending(w => w.Length));

            return sortedWords.Select(word => word.Value).ToList();
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