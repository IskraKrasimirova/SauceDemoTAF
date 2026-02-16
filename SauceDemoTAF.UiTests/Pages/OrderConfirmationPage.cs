using OpenQA.Selenium;
using SauceDemoTAF.UiTests.Utilities.Extensions;

namespace SauceDemoTAF.UiTests.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        private IWebElement CompleteTitle => _driver.FindElement(By.XPath("//span[@class='title' and contains(text(), 'Checkout: Complete')]"));
        private IWebElement GreetingHeader => _driver.FindElement(By.XPath("//h2[@class='complete-header' and contains(text(), 'Thank you for your order!')]"));
        private IWebElement BackToProductsButton => _driver.FindElement(By.XPath("//button[@id='back-to-products']"));

        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToProductsPage()
        {
            BackToProductsButton.Click();
        }

        public void VerifyIsAtOrderConfirmationPage()
        {
            _driver.WaitUntilUrlContains("checkout-complete.html");

            Assert.Multiple(() =>
            {
                Assert.That(CompleteTitle.Displayed, "Title is not visible.");
                Assert.That(GreetingHeader.Displayed, "Greeting is not visible.");
                Assert.That(BackToProductsButton.Displayed, "Back To Products button is not visible.");
            });
        }
    }
}
