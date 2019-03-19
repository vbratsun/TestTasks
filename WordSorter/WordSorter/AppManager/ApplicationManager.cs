using System;
using System.Threading;

namespace WordSorter.AppManager
{
    public class ApplicationManager
    {
        private static readonly ThreadLocal<ApplicationManager> App = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
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
