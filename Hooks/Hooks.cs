using BoDi;
using OpenQA.Selenium.Chrome;
using SpecFlowTask.Drivers;
using System.Diagnostics;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace SpecFlowTask.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        IObjectContainer container;
        public Hooks(IObjectContainer _container)
        {
            container = _container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--headless");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            container.RegisterInstanceAs(driver);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
            using (var process = Process.GetCurrentProcess())
            {
                if (process.ToString() == "chromedriver")
                {
                    process.Kill(true);
                }
                else if (process.ToString() == "gechodriver")
                {
                    process.Kill(true);
                }
                driver?.Dispose(); driver = null;
            }
        }
    }
}