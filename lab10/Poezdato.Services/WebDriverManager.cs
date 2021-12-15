using System;
using Framework.Driver.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Poezdato.Models;
using Poezdato.PageObjects;
using Poezdato.WebDriver;

namespace Poezdato.Services
{
    public class WebDriverManager
    {
        private IWebDriver _webDriver;

        public WebDriverManager()
        {
            _webDriver = ChromeDriverEntity.Driver;
        }

        public string PassTripFeatures(TripLocation location, TripDate date)
        {
            var homePage = new HomePage(_webDriver).OpenPage();

            homePage.EnterFromPlace(location.FromPlace)
                .EnterToPlace(location.ToPlace)
                .SelectDate(date.DepartureDay)
                .CloseDateField()
                .SearchTrips();

            return homePage.CurrentUrl;
        }

        public string PassTripAdvancedFeatures(TripLocation location, TripDate date, TripTime fromTime, TripTime toTime)
        {
            var homePage = new HomePage(_webDriver).OpenPage();

            homePage.OpenAdvancedSearch()
                .EnterFromPlace(location.FromPlace)
                .EnterToPlace(location.ToPlace)
                .SelectDate(date.DepartureDay)
                .CloseDateField()
                .EnterFromTime(fromTime.Time)
                .EnterToTime(toTime.Time)
                .SearchTrips();

            return homePage.CurrentUrl;
        }

        public bool CheckTrainAvailability(TripLocation location, TripDate date, TripTime fromTime, TripTime toTime, string text)
        {
            var homePage = new HomePage(_webDriver).OpenPage();

            homePage.OpenAdvancedSearch()
                .EnterFromPlace(location.FromPlace)
                .EnterToPlace(location.ToPlace)
                .SelectDate(date.DepartureDay)
                .CloseDateField()
                .EnterFromTime(fromTime.Time)
                .EnterToTime(toTime.Time)
                .SearchTrips();

            return homePage.ErrorInner.Text == text;
        }

        public bool CheckReverseFromToButton(TripLocation location)
        {
            var homePage = new HomePage(_webDriver).OpenPage();

            homePage.EnterFromPlace(location.FromPlace)
                .EnterToPlace(location.ToPlace);

            var prevFromPlace = homePage.FromPlaceField.Text;
            var prevToPlace = homePage.ToPlaceField.Text;

            homePage.PressReverseFromToButton();

            var fromPlace = homePage.FromPlaceField.Text;
            var toPlace = homePage.ToPlaceField.Text;

            return prevFromPlace == toPlace && prevToPlace == fromPlace;
        }

        public bool AreTrainsInOrder()
        {
            var timetablePage = new TimetablePage(_webDriver).OpenPage();
            var departureTimeList = new DepartureTimeList(timetablePage.DepartureTimeList);
            return departureTimeList.AreElementsInOrder();
        }
        
        public string NoTripFeatures()
        {
            var homePage = new HomePage(_webDriver).OpenPage();
            homePage.SearchTrips();
            return homePage.CurrentUrl;
        }

        public void DestroyDrive()
        {
            ChromeDriverEntity.CloseDriver();;
        }
    }
}