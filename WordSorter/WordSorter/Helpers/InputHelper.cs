using System;
using WordSorter.AppManager;
using WordSorter.Model;

namespace WordSorter.Helpers
{
    public class InputHelper
    {
        private ApplicationManager _app;

        public InputHelper(ApplicationManager app)
        {
            //_app = app;
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

            Console.WriteLine("Введите количество слов для сортировки:");
            userInputData.Quantity = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Введите слова для сортировки через пробел:");
            userInputData.PlainWords = Console.ReadLine();

            return userInputData;
        }
    }
}