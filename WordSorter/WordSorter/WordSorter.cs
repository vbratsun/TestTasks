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

            var plainData = App.DataHelper.GetStubData3();
            //var plainData = App.DataHelper.GetData();

            var preparedInputData = App.DataHelper.GetPreparedInputData(plainData);
            var sortedData = App.DataHelper.GetSortedData(preparedInputData);
            App.DataHelper.PerformData(sortedData);
        }
    }
}
