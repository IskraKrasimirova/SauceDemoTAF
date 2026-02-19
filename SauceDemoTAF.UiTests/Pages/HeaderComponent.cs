using OpenQA.Selenium;
using SauceDemoTAF.UiTests.Utilities.Extensions;

namespace SauceDemoTAF.UiTests.Pages
{
    public class HeaderComponent : BasePage
    {
        private IWebElement MenuButton => _driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));
        private IWebElement AppLogo => _driver.FindElement(By.XPath("//div[@class='app_logo' and contains(text(),'Swag Labs')]"));
        private IWebElement CartLink => _driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
        private IWebElement LogoutLink => _driver.FindElement(By.XPath("//a[@id='logout_sidebar_link']"));
        private IReadOnlyCollection<IWebElement> NavigationList => _driver.FindElements(By.XPath("//nav[@class='bm-item-list']/a"));
        private IWebElement MenuPanel => _driver.FindElement(By.XPath("//div[@class='bm-menu-wrap']"));
        public HeaderComponent(IWebDriver driver) : base(driver)
        {
        }

        public void OpenMenu()
        {
            _driver.ScrollAndClickJs(MenuButton);
            _driver.WaitUntilElementIsVisible(MenuPanel);
            Assert.That(NavigationList, Is.Not.Empty);
        }

        public void Logout()
        {
            _driver.WaitUntilElementIsClickable(LogoutLink);
            LogoutLink.Click();
        }

        public void VerifyPrimaryHeaderIsVisible()
        {
            Assert.Multiple(() =>
            {
                Assert.That(MenuButton.Displayed, "Menu is not visible.");
                Assert.That(AppLogo.Displayed, "App Logo is not visible.");
                Assert.That(CartLink.Displayed, "Cart Link is not visible.");
            });
        }
    }
}
