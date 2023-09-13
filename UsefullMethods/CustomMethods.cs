using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowTask.UsefullMethods
{
    public class CustomMethods
    {
        public void WaitForAlertBy(IWebDriver browser)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public void WaitForElementBy(IWebDriver browser, By by)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitForElementTextBy(IWebDriver browser, By by, string text)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
        }

        public void WaitForElementByWithoutSeleniumExtras(IWebDriver browser, By by)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(by));
        }

        public void SelectFromDropDownByText(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public void SelectFromDropDownByIndex(IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public void SelectFromDropDownByValue(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public IJavaScriptExecutor ScrollIntoViewAndClickViaJs(IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            js.ExecuteScript("arguments[0].click()", element);
            return js;
        }

        public IJavaScriptExecutor ScrollIntoViewViaJs(IWebDriver driver, int x, int y)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy({x}, {y})");
            return js;
        }

        private static void SendKeysWithJavaScript(IWebDriver driver, IWebElement element, string value)
        {
            IJavaScriptExecutor? Js = (IJavaScriptExecutor?)driver;
            Js?.ExecuteScript("arguments[0].value = arguments[1];", element, value);
        }
    }
}