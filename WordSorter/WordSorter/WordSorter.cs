using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSorter.AppManager;
using WordSorter.Model;

namespace WordSorter
{
    public class WordSorter
    {
        protected static ApplicationManager App;

        public static void Main()
        {
            App = ApplicationManager.GetInstance();

            var plainData = GetData();

        }

        private static InputData GetData()
        {
            var userInputData = new InputData();

            Console.WriteLine("Введите количество слов для сортировки:");
            userInputData.WordsQuantity = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Введите слова для сортировки через пробел:");
            userInputData.WordsUnsorted = Console.ReadLine();

            return userInputData;
        }

        private static OutputData SortData(InputData inputData)
        {
            return null;
        }

        private static OutputData PerformData(OutputData outputData)
        {
            return null;
        }
    }
}
