using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestFramework
{
    public static class DriverExtension
    {
        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
        }

        public static void ScrollToEndOfPage(this IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
        }
    }
}
