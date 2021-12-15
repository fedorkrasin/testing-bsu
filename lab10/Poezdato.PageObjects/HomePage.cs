using System;
using Framework.Driver.Support;
using OpenQA.Selenium;

namespace Poezdato.PageObjects
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver webDriver) : base(webDriver, "https://poezdato.net/") { }
        
        public IWebElement FromPlaceField => FindElementBy(By.Id("dir_from"));
        public IWebElement ToPlaceField => FindElementBy(By.Id("dir_where"));
        public IWebElement DateField => FindElementBy(By.Id("dir_date"));
        public IWebElement FindButton => FindElementBy(By.Id("dir_submit"));
        public IWebElement AdvancedSearchButton => FindElementBy(By.Id("trigger_advanced_1"));
        public IWebElement DirectionTimeFrom => FindElementBy(By.Id("dir_time_from"));
        public IWebElement DirectionTimeTo => FindElementBy(By.Id("dir_time_to"));
        public IWebElement ErrorInner => FindElementBy(By.ClassName("error_inner")).FindElement(By.TagName("p"));
        public IWebElement ReverseFromToButton => FindElementBy(By.Id("reverce"));

        public HomePage EnterFromPlace(string place)
        {
            FromPlaceField.SendKeys(place);
            return this;
        }

        public HomePage EnterToPlace(string place)
        {
            ToPlaceField.SendKeys(place);
            return this;
        }

        public HomePage SelectDate(string date)
        {
            DateField.SendKeys(date);
            return this;
        }

        public HomePage CloseDateField()
        {
            DateField.SendKeys(Keys.Return);
            return this;
        }

        public HomePage OpenAdvancedSearch()
        {
            AdvancedSearchButton.Click();
            return this;
        }

        public HomePage EnterFromTime(string time)
        {
            DirectionTimeFrom.SendKeys(time);
            return this;
        }
        
        public HomePage EnterToTime(string time)
        {
            DirectionTimeTo.SendKeys(time);
            return this;
        }

        public HomePage PressReverseFromToButton()
        {
            ReverseFromToButton.Click();
            return this;
        }

        public HomePage SearchTrips()
        {
            FindButton.SendKeys(Keys.Return);
            return this;
        }

        public override HomePage OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }
    }
}