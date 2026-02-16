using OpenQA.Selenium;
using SauceDemoTAF.UiTests.Utilities.Extensions;

namespace SauceDemoTAF.UiTests.Pages
{
    public class OrderPage : BasePage
    {
        private IWebElement OverviewTitle => _driver.FindElement(By.XPath("//span[@class='title' and contains(text(), 'Checkout: Overview')]"));
        private IWebElement QuantityLabel => _driver.FindElement(By.XPath("//div[@class='cart_quantity_label' and contains(text(), 'QTY')]"));
        private IWebElement DescriptionLabel => _driver.FindElement(By.XPath("//div[@class='cart_desc_label' and contains(text(), 'Description')]"));
        private IWebElement FinishButton => _driver.FindElement(By.XPath("//button[@id='finish']"));
        private IWebElement CancelButton => _driver.FindElement(By.XPath("//button[@id='cancel']"));

        private IReadOnlyCollection<IWebElement> OrderItems => _driver.FindElements(By.XPath("//div[@class='cart_item']"));
        private IReadOnlyCollection<IWebElement> SummaryInfoLabels => _driver.FindElements(By.XPath("//div[@class='summary_info']/child::div[@class='summary_info_label']"));
        private IWebElement PaymentInfoLabel => _driver.FindElement(By.XPath("//div[@class='summary_info_label' and contains(text(), 'Payment Information')]"));
        private IWebElement ShippingInfoLabel => _driver.FindElement(By.XPath("//div[@class='summary_info_label' and contains(text(), 'Shipping Information')]"));
        private IWebElement TotalPriceLabel => _driver.FindElement(By.XPath("//div[@class='summary_info_label' and contains(text(), 'Price Total')]"));

        public OrderPage(IWebDriver driver) : base(driver)
        {
        }

        public void FinishOrder()
        {
            _driver.ScrollAndClickJs(FinishButton);
        }

        public IEnumerable<string> GetOrderProductsNames()
        {
            var productNames = _driver.FindElements(By.XPath("//div[@class='inventory_item_name']"))
                .Select(e => e.Text.Trim())
                .ToList();

            return productNames;
        }

        public void VerifyIsAtOrderPage()
        {
            _driver.WaitUntilUrlContains("checkout-step-two.html");

            Assert.Multiple(() =>
            {
                Assert.That(OverviewTitle.Displayed, "Title is not visible.");
                Assert.That(QuantityLabel.Displayed, "Quantity label is not visible.");
                Assert.That(DescriptionLabel.Displayed, "Description label is not visible.");
                Assert.That(OrderItems, Is.Not.Empty, "Order items should not be empty.");
                Assert.That(PaymentInfoLabel.Displayed, "PaymentInfo label is not visible.");
                Assert.That(ShippingInfoLabel.Displayed, "ShippingInfo label is not visible.");
                Assert.That(TotalPriceLabel.Displayed, "Total Price label is not visible.");
                Assert.That(FinishButton.Displayed, "Finish button is not visible.");
                Assert.That(CancelButton.Displayed, "Cancel button is not visible.");
            });
        }
    }
}
