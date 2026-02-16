using OpenQA.Selenium;
using SauceDemoTAF.UiTests.Models;
using SauceDemoTAF.UiTests.Utilities.Extensions;

namespace SauceDemoTAF.UiTests.Pages
{
    public class CheckoutPage : BasePage
    {
        private IWebElement CheckoutTitle => _driver.FindElement(By.XPath("//span[@class='title' and contains(text(), 'Checkout')]"));
        private IWebElement FirstNameInput => _driver.FindElement(By.XPath("//input[@id='first-name']"));
        private IWebElement LastNameInput => _driver.FindElement(By.XPath("//input[@id='last-name']"));
        private IWebElement PostalCodeInput => _driver.FindElement(By.XPath("//input[@id='postal-code']"));
        private IWebElement ContinueButton => _driver.FindElement(By.XPath("//input[@id='continue']"));
        private IWebElement CancelButton => _driver.FindElement(By.XPath("//button[@id='cancel']"));

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        public void CompleteCheckout(UserModel user)
        {
            FirstNameInput.EnterText(user.FirstName);
            LastNameInput.EnterText(user.LastName);
            PostalCodeInput.EnterText(user.PostalCode);

            _driver.ScrollAndClickJs(ContinueButton);
        }

        public void VerifyIsAtCheckoutPage()
        {
            _driver.WaitUntilUrlContains("checkout-step-one.html");

            Assert.Multiple(() =>
            {
                Assert.That(CheckoutTitle.Displayed, "Title is not visible.");
                Assert.That(FirstNameInput.Displayed, "First Name field is not visible.");
                Assert.That(LastNameInput.Displayed, "Last Name field is not visible.");
                Assert.That(PostalCodeInput.Displayed, "Postal Code field is not visible.");
                Assert.That(ContinueButton.Displayed, "Continue button is not visible.");
                Assert.That(CancelButton.Displayed, "Cancel button is not visible.");
            });
        }
    }
}
