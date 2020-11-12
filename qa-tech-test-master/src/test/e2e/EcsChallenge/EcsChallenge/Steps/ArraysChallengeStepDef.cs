using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestFramework;
using TestFramework.Pages;
using FluentAssertions;
using System.Reflection.Metadata;

namespace EcsChallenge.Steps
{
    [Binding]
    public sealed class ArraysChallengeStepDef
    {
        private static IWebDriver _driver;
        private readonly BrowserContext _browserContext;
        private readonly HomePage _homePage;
        private readonly ArraysPage _arraysPage;
        public ArraysChallengeStepDef(BrowserContext browserContext)
        {
            _browserContext = browserContext;
            _driver = _browserContext.driver;
            _homePage = new HomePage(_browserContext);
            _arraysPage = new ArraysPage(_browserContext);
        }

        [Given(@"I am on the Ecs challenge homepage")]
        public void GivenIAmOnTheEcsChallengeHomepage()
        {
            _homePage.LoadHomePage();
        }

        [Given(@"I click on RenderChallengButton")]
        public void WhenIClickOnRenderChallengButton()
        {
            _homePage.ClickRenderChallengeBtn();
        }

        [Given(@"I create an array of each row in table")]
        public void GivenICreateAnArrayOfEachRowInTable()
        {
            _arraysPage.GetTableData();
        }

        [When(@"I '(.*)' submit all my '(.*)' answers for the challenge")]
        public void WhenISubmitAllMyAnswersForTheChallenge(string name, string validOrInvalid)
        {
            if (validOrInvalid.ToLower() == "valid")
            {
                _arraysPage.FindIndex();
                var challenge1 = _browserContext.answers[0].ToString();
                var challenge2 = _browserContext.answers[1].ToString();
                var challenge3 = _browserContext.answers[2].ToString();
                _arraysPage.SubmitAnswers(challenge1,challenge2,challenge3,name);
            }
            else
            {
                _arraysPage.SubmitAnswers("","", "", name);
            }
        }

        [Then(@"I should recieve a message '(.*)'")]
        public void ThenIShouldRecieveAMessage(string message)
        {
            _arraysPage.DialogText().Should().Contain(message);
        }



    }
}
