using System.Threading;
using lab8.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        }

        [Test]
        public void SearchTrainsTest()
        {
            var homePage = new HomePage(_driver).OpenPage();
            
            Assert.Pass();
        }
    }
}