using OpenQA.Selenium;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace TestFramework.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly BrowserContext _browserContext;
        private readonly IWebDriver _driver;
        private static Process process;

        public Hooks(BrowserContext browserContext)
        {
            _browserContext = browserContext;
            _driver = _browserContext.driver;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var mainDirectory = currentDirectory.Substring(0,currentDirectory.IndexOf("\\src"));

            process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = $"{currentDirectory}\\YarnStart.bat";
            startInfo.Arguments = $"{mainDirectory}";
            process.StartInfo = startInfo;
            process.Start();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            process.Dispose();
        }

    }
}
