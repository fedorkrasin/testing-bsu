using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace lab8.Pages
{
    public class Page
    {
        public Page(IWebDriver webDriver, string entryUrl)
        {
            this.WebDriver = webDriver;
            this.EntryUrl = entryUrl;
            PageFactory.InitElements(webDriver, this);
        }

        protected IWebDriver WebDriver { get; }

        protected string EntryUrl { get; }

        public string CurrentUrl => this.WebDriver.Url;

        public virtual Page OpenPage()
        {
            this.WebDriver.Navigate().GoToUrl(this.EntryUrl);

            return this;
        }
    }
}