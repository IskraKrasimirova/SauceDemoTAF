using OpenQA.Selenium;
using Reqnroll;

namespace SauceDemoTAF.UiTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _driver;

        public Hooks(IWebDriver driver)
        {
            _driver = driver;
        }

        [AfterScenario(Order = 1)]
        public void CloseBrowser()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
