using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace lab8.Pages
{
    public class TimetablePage : Page
    {
        public TimetablePage(IWebDriver webDriver) : base(webDriver, "https://poezdato.net/raspisanie-poezdov/minsk--baranovichi/16.12.2021/") { }
        
        public List<IWebElement> DepartureTimeList => GetDepartureTimeList();

        private List<IWebElement> GetDepartureTimeList()
        {
            var trainsTable = WebDriver.FindElement(By.TagName("table"));
            var trainsTableBody = trainsTable.FindElement(By.TagName("tbody"));
            var trainTableRows = trainsTableBody.FindElements(By.TagName("tr"));
            var departureTimeList = trainTableRows.Select(trainTableRow =>
                trainTableRow.FindElements(By.TagName("td"))[3].FindElement(By.TagName("span")));

            return departureTimeList.ToList();
        }
        
        public override TimetablePage OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }
    }
}