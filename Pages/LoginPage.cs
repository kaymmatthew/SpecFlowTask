using BoDi;
using OpenQA.Selenium;
using SpecFlowTask.UsefullMethods;

namespace SpecFlowTask.Pages
{
    public class LoginPage
    {
        readonly IWebDriver _driver;
        readonly CustomMethods _customMethods;
        readonly ScenarioContext _scenarioContext;
       
        public LoginPage(IWebDriver driver, IObjectContainer _container)
        {
            _driver = driver;
            _customMethods = new CustomMethods();
            _scenarioContext = _container.Resolve<ScenarioContext>();
        }

        private IWebElement SignUpLoginButton => _driver.FindElement(By.PartialLinkText("Signup"));
        private IWebElement SignUpName => _driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement SignUpEmail => _driver.FindElement(By.XPath("//input[@data-qa='signup-email']"));
        private IWebElement SignUpButton => _driver.FindElement(By.XPath("//*[@data-qa='signup-button']"));
        private IList<IWebElement> AssertSignUpFormsPage => _driver.FindElements(
            By.XPath("//*[@class='title text-center']"));
        private IWebElement Mr => _driver.FindElement(By.Id("id_gender1"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement Days => _driver.FindElement(By.Id("days"));
        private IWebElement Months => _driver.FindElement(By.CssSelector("#months"));
        private IWebElement Year => _driver.FindElement(By.CssSelector("#years"));
        private IWebElement FirstName => _driver.FindElement(By.XPath("//input[@id='first_name']"));
        private IWebElement LastName => _driver.FindElement(By.XPath("//input[@id='last_name']"));
        private IWebElement Company => _driver.FindElement(By.CssSelector("#company"));
        private IWebElement Address => _driver.FindElement(By.CssSelector("#address1"));
        private IWebElement Address2 => _driver.FindElement(By.CssSelector("#address2"));
        private IWebElement Country => _driver.FindElement(By.Id("country"));
        private IWebElement State => _driver.FindElement(By.CssSelector("#state"));
        private IWebElement City => _driver.FindElement(By.XPath("//input[@id='city']"));
        private IWebElement ZipCode => _driver.FindElement(By.XPath("//input[@id='zipcode']"));
        private IWebElement Mobile => _driver.FindElement(By.XPath("//input[@id='mobile_number']"));
        private IWebElement CreateAccount => _driver.FindElement(By.XPath("//button[@data-qa='create-account']"));
        private IWebElement AssertPageHeader => _driver.FindElement(By.XPath("//*[@class='title text-center']"));
        private IList<IWebElement> AssertPageMessage => _driver.FindElements(By.XPath("//*[contains(@style,'font-family:')]"));



        public void LoginInformation(string _name, string _email)
        {
            SignUpName.SendKeys(_name);
            SignUpEmail.SendKeys(_email);
            _scenarioContext["userName"] = _name;
        }

        public void ClickTitle() => Mr.Click();
        public void EnterUserPwd(string password)
        {
            Password.SendKeys(password);
        } 

        public void EnterDOB(string days, string month, string year)
        {
            _customMethods.SelectFromDropDownByText(Days, days);
            _customMethods.SelectFromDropDownByText(Months, month);
            _customMethods.SelectFromDropDownByText(Year, year);
        }

        public void EnterUserFirstName(string fName)
        {
            FirstName.SendKeys(fName);
        } 
        public void EnterUserLastName(string lName)
        {
            LastName.SendKeys(lName);
        } 
        public void EnterUserCompany(string userCompay)
        {
            Company.SendKeys(userCompay);
        } 
        public void EnterUserAddress1(string userAddress)
        {
            Address.SendKeys(userAddress);
        } 
        public void EnterUserAddress2(string userAddress2)
        {
            Address2.SendKeys(userAddress2);
        }
        public void EnterUserCountry(string userCountry) 
        {
            _customMethods.SelectFromDropDownByText(Country, userCountry);
        } 
        public void EnterUserState(string userState)
        {
            State.SendKeys(userState);
        } 
        public void EnterUserCity(string userCity)
        {
            City.SendKeys(userCity);
        } 
        public void EnterUserZipCode(string userZipCode)
        {
            ZipCode.SendKeys(userZipCode);
        } 
        public void EnterUserMobile(string userMobile)
        {
            Mobile.SendKeys(userMobile);
            _customMethods.ScrollIntoViewViaJs(_driver, 0, 250);
        } 
        public void ClickCreateAccount() => CreateAccount.Click();

        public void ClickSignUpBtn() => SignUpButton.Click();

        public string GetEnterAccountInformationHeaderText()
        {
            var PageHeadertext = AssertSignUpFormsPage.First();
            return PageHeadertext.Text;
        }

        public void ClickLoginBtn() => SignUpLoginButton.Click();

        public void NavigateTosite() => _driver.Navigate().GoToUrl(readTestDataConfig.AutomationExerciseUrl());

        public string GetPageHeaderText()
        {
            var pageHeaderText = AssertPageHeader;
            return pageHeaderText.Text;
        }

        public string GetPageMsgText()
        {
            var pageMessage = AssertPageMessage.First();
            return pageMessage.Text;
        }
    }
}