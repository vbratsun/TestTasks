using System;
using System.Threading;
using WordSorter.Helpers;

namespace WordSorter.AppManager
{
    public class ApplicationManager
    {
        private static readonly ThreadLocal<ApplicationManager> App = new ThreadLocal<ApplicationManager>();

        private readonly Lazy<DataHelper> _dataHelper;
        public DataHelper DataHelper => _dataHelper.Value;

        private ApplicationManager()
        {
            _dataHelper = new Lazy<DataHelper>(()=>new DataHelper(this));
        }

        ~ApplicationManager()
        {
        }

        public static ApplicationManager GetInstance()
        {
            if (!App.IsValueCreated)
            {
                App.Value = new ApplicationManager();
            }
            Console.WriteLine($"Return App {App.GetHashCode()} instance");
            return App.Value;
        }
    }
}
