using System;
using System.Collections.Generic;
using System.Linq;
using WordSorter.AppManager;
using WordSorter.Extensions;
using WordSorter.Model;

namespace WordSorter.Helpers
{
    public class InputHelper
    {
        private ApplicationManager _app;

        public InputHelper(ApplicationManager app)
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

        public InputData GetStubData3()
        {
            return new InputData
            {
                Quantity = 5,
                PlainWords = "Огонь Стена Паровоз Земля Мяч"
            };
        }

        public InputData GetData()
        {
            var userInputData = new InputData();

            userInputData.Quantity = GetQuantity();
            userInputData.PlainWords = GetWords();

            return userInputData;
        }

        private int GetQuantity()
        {
            Console.WriteLine("Введите количество слов для сортировки:");
            var quantity = Convert.ToInt16(Console.ReadLine());

            return quantity;
        }

        private string GetWords()
        {
            Console.WriteLine("Введите слова для сортировки через пробел:");
            var words = Console.ReadLine();

            return words;
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
    }
}