using lab8.Objects;
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
            option.AddArguments("--headless", "--window-size=1920,1920");
            _driver = new ChromeDriver(option);
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

        [Test]
        public void TrainsAreInOrderOfDepartureTest()
        {
            var timetablePage = new TimetablePage(_driver).OpenPage();

            var departureTimeList = new DepartureTimeList(timetablePage.DepartureTimeList);
            
            Assert.IsTrue(departureTimeList.AreElementsInOrder());
        }
        
        [TearDown]
        public void CloseDriver()
        {
            _driver.Close();
        }
    }
}