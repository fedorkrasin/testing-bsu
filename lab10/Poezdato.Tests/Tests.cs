using NUnit.Framework;
using Poezdato.Models;
using Poezdato.Services;

namespace Poezdato.Tests
{
    public class Tests
    {
        private WebDriverManager _manager;
        
        [SetUp]
        public void Setup()
        {
            _manager = new WebDriverManager();
        }

        [Test]
        public void SearchTrainsTest()
        {
            var url = _manager.PassTripFeatures(new TripLocation("Baranovichi", "Minsk"), new TripDate("15.12.2021"));
            Assert.AreEqual(url, "https://poezdato.net/raspisanie-poezdov/baranovichi--minsk/15.12.2021/");
        }

        [Test]
        public void AdvancedSearchTrainsTest()
        {
            var url = _manager.PassTripAdvancedFeatures(new TripLocation("Baranovichi", "Minsk"),
                new TripDate("15.12.2021"),
                new TripTime("22:00"), new TripTime("23:30"));
            Assert.AreEqual(url, "https://poezdato.net/raspisanie-poezdov/baranovichi--minsk/15.12.2021/22.00/23.30/");
        }
    }
}