using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowTask.Pages;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTask.StepDefinitions
{
    [Binding]
    public class CreateAUserStepDefinitions
    {
        IWebDriver _driver;
        ScenarioContext _scenarioContext;
        LoginPage _loginPage;
        public CreateAUserStepDefinitions(IObjectContainer _container)
        {
            _scenarioContext = _container.Resolve<ScenarioContext>();
            _driver = _container.Resolve<IWebDriver>();
            _loginPage = _container.Resolve<LoginPage>();
        }

        [Given(@"User is on automation exercise home page")]
        public void GivenUserIsOnAutomationExerciseHomePage() => 
            _loginPage.NavigateTosite();

        [When(@"User click login link text")]
        public void WhenUserClickLoginLinkText() => _loginPage.ClickLoginBtn();

        [When(@"User enter the following signup details")]
        public void WhenUserEnterTheFollowingSignupDetails(Table table)
        {
            dynamic enterDetails = table.CreateDynamicInstance();
            _loginPage.LoginInformation(enterDetails.Name, string.Format(enterDetails.Email, DateTime.Now.ToString("HHmmssfff")));
        }

        [When(@"User click signup button")]
        public void WhenUserClickSignupButton() => _loginPage.ClickSignUpBtn();

        [Then(@"User is on '([^']*)' page")]
        public void ThenUserIsOnPage(string expectedPageHeader)
        {
            var actualPageHeader = _loginPage.GetEnterAccountInformationHeaderText();
            Assert.AreEqual(expectedPageHeader, actualPageHeader);
        }

        [When(@"User click title")]
        public void WhenUserClickTitle() => _loginPage.ClickTitle();

        [When(@"User enter password")]
        public void WhenUserEnterPassword() => _loginPage.EnterUserPwd(readTestDataConfig.UserPassword());

        [When(@"User enter date of birth")]
        public void WhenUserEnterDateOfBirth()
        {
            _loginPage.EnterDOB(readTestDataConfig.Days(), readTestDataConfig.Month(),
                readTestDataConfig.Year());
        }

        [When(@"user enter first name")]
        public void WhenUserEnterFirstName() => _loginPage.
            EnterUserFirstName(readTestDataConfig.UserFirstName());

        [When(@"User enter last name")]
        public void WhenUserEnterLastName() => _loginPage.
            EnterUserLastName(readTestDataConfig.UserLastName());

        [When(@"User enter company")]
        public void WhenUserEnterCompany() => _loginPage.
            EnterUserCompany(readTestDataConfig.UserCompay());

        [When(@"User enter first adress")]
        public void WhenUserEnterFirstAdress() => _loginPage.
            EnterUserAddress1(readTestDataConfig.UserAddress());

        [When(@"User enter second address")]
        public void WhenUserEnterAddress() => _loginPage.
            EnterUserAddress2(readTestDataConfig.UserAddress2());

        [When(@"User select country")]
        public void WhenUserSelectCountry() => _loginPage.
            EnterUserCountry(readTestDataConfig.UserCountry());

        [When(@"User enter state")]
        public void WhenUserEnterState() => _loginPage.
            EnterUserState(readTestDataConfig.UserState());

        [When(@"User enter city")]
        public void WhenUserEnterCity() => _loginPage.
            EnterUserCity(readTestDataConfig.UserCity()); 

        [When(@"User enter zipCode")]
        public void WhenUserEnterZipCode() => _loginPage.
            EnterUserZipCode(readTestDataConfig.UserZipCode());

        [When(@"User enter mobile")]
        public void WhenUserEnterMobile() => _loginPage.
            EnterUserMobile(readTestDataConfig.UserMobile());

        [When(@"User click create account button")]
        public void WhenUserClickCreateAccountButton() => _loginPage.ClickCreateAccount();

        [Then(@"User should be presented with a pageheader '([^']*)'")]
        public void ThenUserShouldBePresentedWithAPageheader(string expectedPageHeader)
        {
            var actualPageHeader = _loginPage.GetPageHeaderText();
            Assert.AreEqual(expectedPageHeader, actualPageHeader);
        }

        [Then(@"User should see a message '([^']*)'")]
        public void ThenUserShouldSeeAMessage(string expectedPageMsg)
        {
            var actualPageMsg = _loginPage.GetPageMsgText();
            Assert.AreEqual(expectedPageMsg, actualPageMsg);
        }

        [Then(@"User should see the user account name created '([^']*)'")]
        public void ThenUserShouldSeeTheUserAccountNameCreated(string expectedUserName)
        {
            var actualUserName = _scenarioContext.Get<string>("userName");
            Assert.AreEqual(expectedUserName, actualUserName);
        }

    }
}