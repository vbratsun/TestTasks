using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public InputData GetStubData()
        {
            return new InputData
            {
                NumberOfWords = 5,
                PlainWords = "Кашалот Катафалк Шар Трактор Яблоко"
            };
        }

        public InputData GetData()
        {
            var userInputData = new InputData();

            Console.WriteLine("Введите количество слов для сортировки:");
            userInputData.NumberOfWords = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Введите слова для сортировки через пробел:");
            userInputData.PlainWords = Console.ReadLine();

            return userInputData;
        }

        public InputData GetPreparedInputData(InputData inputData, char delimiter = ' ')
        {
            var filledInData = new InputData
            {
                PlainWords = inputData.PlainWords,
                NumberOfWords = inputData.NumberOfWords
            };

            filledInData.UnsortedWords = inputData.PlainWords.Split(delimiter).ToArray();

            return filledInData;
        }

        public OutputData GetSortedData(InputData inputData)
        {
            var sortedData = new OutputData
            {
                NumberOfWords = inputData.NumberOfWords,
                UnsortedWords = inputData.UnsortedWords
            };

            sortedData.SortedWords = SortWords(inputData.UnsortedWords);

            return sortedData;
        }

        private string[] SortWords(string[] words)
        {
            var unsortedWords = words;
            var sortedWords = new[] { String.Empty, };

            return sortedWords;
        }



        public void PerformData(OutputData outputData)
        {
            Console.WriteLine("Вывод:\n");
            foreach (var word in outputData.SortedWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}