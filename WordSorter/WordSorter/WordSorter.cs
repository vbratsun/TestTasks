using WordSorter.AppManager;

namespace WordSorter
{
    public class WordSorter
    {
        protected static ApplicationManager App;

        public static void Main()
        {
            App = ApplicationManager.GetInstance();

            var plainData = App.InputHelper.GetData();
            var preparedInputData = App.InputHelper.GetPreparedInputData(plainData);
            var sortedData = App.DataHelper.GetSortedData(preparedInputData);
            App.OutputHelper.PerformData(sortedData);
        }
    }
}