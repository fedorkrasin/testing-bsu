using System;
using System.Threading;
using Framework.Driver.Support;
using Framework.Waiter;
using lab8.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace lab8
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;
        
        [SetUp]
        public void InitDriver()
        {
            var option = new ChromeOptions();
            option.AddArguments("--headless", "--window-size=1920,937");
            _driver = new ChromeDriver(option);
            
            // _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            // var element = _driver.FindElement(By.Id("dir_from"));
            // var actions = new Actions(_driver);
            // actions.MoveToElement(element);
            
            Thread.Sleep(2000);
        }

        [Test]
        public void SearchTrainsTest()
        {
            var homePage = new HomePage(_driver).OpenPage();

            // var element = homePage.FromPlaceField;
            // var actions = new Actions(_driver);
            // actions.MoveToElement(element);
            // actions.Perform();

            homePage.ClickFrame()
                .EnterFromPlace("Minsk")
                .EnterToPlace("Baranovichi")
                .SelectDate("16.12.2021")
                // .CloseDateField()
                .SearchTrips();

            var expectedPageUrl = "https://poezdato.net/raspisanie-poezdov/minsk--baranovichi/16.12.2021/";
            var expectedPage = new Page(_driver, expectedPageUrl).OpenPage();
            
            Assert.AreEqual(homePage.CurrentUrl, expectedPage.CurrentUrl);
        }
        
        [TearDown]
        public void CloseDriver()
        {
            _driver.Close();
        }
    }
}