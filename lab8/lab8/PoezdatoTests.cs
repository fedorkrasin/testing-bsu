using System;
using System.Threading;
using lab8.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            option.AddArguments("--headless", "--no-sandbox", "--disable-dev-shm-usage");
            _driver = new ChromeDriver(option);
            
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        [Test]
        public void SearchTrainsTest()
        {
            var homePage = new HomePage(_driver).OpenPage();
            
            homePage.EnterFromPlace("Minsk")
                .EnterToPlace("Baranovichi")
                .SelectDate("16.12.2021")
                .CloseDateField()
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