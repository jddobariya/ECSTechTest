using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TestFramework
{
    public class Driver
    {
        public IWebDriver Chrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("disable-save-password-bubble");
            options.AddArgument("disable-popup-blocking");
            options.AddArgument("disable-web-security");

            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddArgument("start-maximized");
            options.AddArgument("lang=en-GB");
            options.AddArgument("no-sandbox");

            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            var driverFolder = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Drivers";

            IWebDriver driver = new ChromeDriver(driverFolder, options);

           return driver;
        }

    }

}
