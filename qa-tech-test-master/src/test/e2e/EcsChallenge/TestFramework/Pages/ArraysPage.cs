using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.Pages
{
    public class ArraysPage
    {
        private readonly BrowserContext _browserContext;
        private readonly IWebDriver _driver;

        #region WebElements
        private By ChallengeSection => By.Id("challenge");
        private By Table => By.TagName("tbody");
        private By Row => By.TagName("tr");
        private By Column => By.TagName("td");

        private By ChallengeAnswer1Txt => By.Name("submit-1");
        private By ChallengeAnswer2Txt => By.Name("submit-2");
        private By ChallengeAnswer3Txt => By.Name("submit-3");
        private By YourNameTxt => By.Name("submit-4");
        private By SubmitBtn => By.Id("submit-answers");
        private By Dialog => By.XPath("//*[@class='dialog']/div/div/div/div");
        #endregion
        public ArraysPage(BrowserContext browserContext)
        {
            _browserContext = browserContext;
            _driver = _browserContext.driver;
        }

        public void GetTableData()
        {
            _driver.ScrollToElement(_driver.FindElement(ChallengeSection));
            var tableElement = _driver.FindElement(Table);
            var rowElements = tableElement.FindElements(Row);
            var rowList = new List<int[]>();
            foreach (var row in rowElements)
            {                
                var columnList = new List<int>();
                var columnElements = row.FindElements(Column);
                foreach(var column in columnElements)
                {
                    columnList.Add(Convert.ToInt32(column.Text));
                }
                rowList.Add(columnList.ToArray());
            }
            _browserContext.tableData = rowList;
        }

        public void SubmitAnswers(string challenge1,string challenge2,string challenge3, string name)
        {
            _driver.ScrollToEndOfPage();
            _driver.FindElement(ChallengeAnswer1Txt).SendKeys(challenge1);
            _driver.FindElement(ChallengeAnswer2Txt).SendKeys(challenge2);
            _driver.FindElement(ChallengeAnswer3Txt).SendKeys(challenge3);
            _driver.FindElement(YourNameTxt).SendKeys(name);
            _driver.FindElement(SubmitBtn).Click();
        }

        public string DialogText()
        {
            var message =_driver.FindElement(Dialog).Text;
            return message;
        }
        public void FindIndex()
        {
            _browserContext.answers = new List<int>();
            foreach (var row in _browserContext.tableData)
            {
                int index = -1;
                int sum = 0;
                int leftsum = 0;

                for (int i = 0; i < row.Length; ++i)
                    sum += row[i];

                for (int i = 0; i < row.Length; ++i)
                {
                    sum -= row[i];

                    if (leftsum == sum)
                    {
                        index = i;
                    }
                    leftsum += row[i];
                }
                _browserContext.answers.Add(index);
            }
        }
    }
}
