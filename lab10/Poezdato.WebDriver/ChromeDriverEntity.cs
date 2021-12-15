using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Poezdato.WebDriver
{
    public class ChromeDriverEntity
    {
        private static IWebDriver _driver = InitializeWebDriver();

        private static IWebDriver InitializeWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--headless", "--disable-extensions");
            var chromeDriver = new ChromeDriver(options);
            chromeDriver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            chromeDriver.Manage().Window.Maximize();
            return chromeDriver;
        }

        public static IWebDriver Driver => _driver;

        public static void CloseDriver()
        {
            _driver.Close();
            _driver = null;
        }
    }
}