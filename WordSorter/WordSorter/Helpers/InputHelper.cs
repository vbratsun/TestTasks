using System;
using System.Collections.Generic;
using System.Linq;
using WordSorter.Extensions;
using WordSorter.Model;

namespace WordSorter.Helpers
{
    public class InputHelper
    {
        public InputData GetData()
        {
            var userInputData = new InputData
            {
                Quantity = GetQuantity(),
                PlainWords = GetWords()

            };
            
            while (userInputData.Quantity != GetWordsList(userInputData.PlainWords).Count)
            {
                Console.WriteLine("Количество слов не совпадает с указанным!");
                userInputData = new InputData
                {
                    Quantity = GetQuantity(),
                    PlainWords = GetWords()
                };
            }

            return userInputData;
        }

        private int GetQuantity()
        {
            int quantity;
            var input = string.Empty;

            while (int.TryParse(input, out quantity) != true)
            {
                Console.WriteLine("Введите целочисленное количество слов для сортировки:");
                input = Console.ReadLine();
            }
            
            return quantity;
        }

        private string GetWords()
        {
            var words = string.Empty;

            while (string.IsNullOrEmpty(words))
            {
                Console.WriteLine("Введите слова для сортировки через пробел:");
                words = Console.ReadLine();
            }

            return words;
        }

        private List<string> GetWordsList(string plainWords, char delimiter = ' ')
        {
            if (string.IsNullOrEmpty(plainWords))
            {
                throw new ArgumentException($"{nameof(plainWords)} is null or empty!");
            }

            return plainWords.Split(delimiter).ToList();
        }

        public InputData GetPreparedInputData(InputData inputData)
        {
            var filledInData = new InputData
            {
                PlainWords = inputData.PlainWords,
                Quantity = inputData.Quantity,
                WordItems = new List<Word>()
            };

            foreach (var item in GetWordsList(filledInData.PlainWords))
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