using System;
using System.Threading;
using WordSorter.Helpers;

namespace WordSorter.AppManager
{
    public class ApplicationManager
    {
        private static readonly ThreadLocal<ApplicationManager> App = new ThreadLocal<ApplicationManager>();

        private readonly Lazy<DataHelper> _dataHelper;
        private readonly Lazy<InputHelper> _inputHelper;
        private readonly Lazy<OutputHelper> _outputHelper;

        private ApplicationManager()
        {
            _dataHelper = new Lazy<DataHelper>(() => new DataHelper());
            _inputHelper = new Lazy<InputHelper>(() => new InputHelper());
            _outputHelper = new Lazy<OutputHelper>(() => new OutputHelper());
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

        public DataHelper DataHelper => _dataHelper.Value;
        public InputHelper InputHelper => _inputHelper.Value;
        public OutputHelper OutputHelper => _outputHelper.Value;
    }
}