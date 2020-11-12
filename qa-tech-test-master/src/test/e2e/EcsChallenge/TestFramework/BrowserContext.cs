using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace TestFramework
{
    public class BrowserContext
    {
        public IWebDriver driver;
        public List<int[]> tableData { get; set; }
        public List<int> answers { get; set; }
        public BrowserContext()
        {
            if (driver == null)
            {
                driver = new Driver().Chrome();
            }

        }

    }
}
