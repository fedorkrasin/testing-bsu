using OpenQA.Selenium;

namespace Poezdato.PageObjects
{
    public class TrainsPage : Page
    {
        public TrainsPage(IWebDriver webDriver, string entryUrl) : base(webDriver, entryUrl) { }
        
        public override TrainsPage OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }
    }
}