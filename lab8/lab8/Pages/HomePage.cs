﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace lab8.Pages
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver webDriver) : base(webDriver, "https://poezdato.net/") { }

        public IWebElement Frame => FindBy(By.Id("cmp-iframe"));
        public IWebElement FromPlaceField => FindBy(By.Id("dir_from"));
        public IWebElement ToPlaceField => FindBy(By.Id("dir_where"));
        public IWebElement DateField => FindBy(By.Id("dir_date"));
        public IWebElement FindButton => FindBy(By.Id("dir_submit"));

        public HomePage ClickFrame()
        {
            Frame.Click();

            return this;
        }

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
        
        private IWebElement FindBy(By key)
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(key));
        }
        
        public HomePage CloseDateField()
        {
            // FromPlaceField.Click();

            DateField.SendKeys(Keys.Return);
            return this;
        }

        public void SearchTrips()
        {
            // FindButton.Click();
            FindButton.SendKeys(Keys.Return);
        }

        public override HomePage OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);

            return this;
        }
    }
}