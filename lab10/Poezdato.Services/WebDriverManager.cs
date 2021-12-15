using System;
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

        public void DestroyDrive()
        {
            ChromeDriverEntity.CloseDriver();;
        }
    }
}