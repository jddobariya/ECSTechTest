using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.Pages
{
    public class HomePage
    {
        private readonly BrowserContext _browserContext;
        private readonly IWebDriver _driver;
        private string homePageUrl = "http://localhost:3000/";

        #region WebElements
        private By RenderChallengeBtn = By.Id("render-challenge");
        #endregion
        public HomePage(BrowserContext browserContext)
        {
            _browserContext = browserContext;
            _driver = _browserContext.driver;
        }

        public void LoadHomePage()
        {
            _driver.Navigate().GoToUrl(homePageUrl);
        }

        public void ClickRenderChallengeBtn()
        {
            _driver.FindElement(RenderChallengeBtn).Click();
        }

    }
}
