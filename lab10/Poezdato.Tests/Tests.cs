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

        [Test]
        public void TrainNotAvailabilityTest()
        {
            var isNotAvailable = _manager.CheckTrainAvailability(new TripLocation("Baranovichi", "Minsk"),
                new TripDate("15.12.2021"),
                new TripTime("22:00"), new TripTime("22:01"), "По вашему запросу поезда не найдены");
            Assert.IsTrue(isNotAvailable);
        }

        [Test]
        public void ReverseFromToButtonTest()
        {
            var isReversed = _manager.CheckReverseFromToButton(new TripLocation("Baranovichi", "Minsk"));
            Assert.IsTrue(isReversed);
        }
        
        [Test]
        public void TrainsAreInOrderOfDepartureTest()
        {
            var areTrainsInOrder = _manager.AreTrainsInOrder();
            Assert.IsTrue(areTrainsInOrder);
        }

        [Test]
        public void NoTripFeaturesTest()
        {
            var url = _manager.NoTripFeatures();
            Assert.AreEqual(url, "https://poezdato.net/");
        }
    }
}