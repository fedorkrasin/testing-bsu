using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Poezdato.PageObjects
{
    public class Page
    {
        public Page(IWebDriver webDriver, string entryUrl)
        {
            WebDriver = webDriver;
            EntryUrl = entryUrl;
            PageFactory.InitElements(webDriver, this);
        }

        protected IWebDriver WebDriver { get; }

        protected string EntryUrl { get; }

        public string CurrentUrl => WebDriver.Url;

        public virtual Page OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);

            return this;
        }

        protected IWebElement FindElementBy(By key)
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(key));
        }

        protected IReadOnlyCollection<IWebElement> FindElementsBy(By key)
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElements(key));
        }
    }
}