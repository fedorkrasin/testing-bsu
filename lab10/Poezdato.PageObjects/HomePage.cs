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