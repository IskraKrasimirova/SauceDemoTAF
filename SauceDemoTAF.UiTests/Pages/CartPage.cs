using OpenQA.Selenium;
using SauceDemoTAF.UiTests.Utilities.Extensions;

namespace SauceDemoTAF.UiTests.Pages
{
    public class CartPage : BasePage
    {
        private IWebElement CartTitle => _driver.FindElement(By.XPath("//span[@class='title' and contains(text(), 'Your Cart')]"));
        private IWebElement QuantityLabel => _driver.FindElement(By.XPath("//div[@class='cart_quantity_label' and contains(text(), 'QTY')]"));
        private IWebElement DescriptionLabel => _driver.FindElement(By.XPath("//div[@class='cart_desc_label' and contains(text(), 'Description')]"));
        private IWebElement CheckoutButton => _driver.FindElement(By.XPath("//button[@id='checkout']"));
        private IWebElement ContinueButton => _driver.FindElement(By.XPath("//button[@id='continue-shopping']"));

        private IReadOnlyCollection<IWebElement> CartItems => _driver.FindElements(By.XPath("//div[@class='cart_item']"));

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public IEnumerable<string> GetCartProductsNames()
        {
            //var productNames = new List<string>();

            //foreach (var item in CartItems)
            //{
            //    var itemName = item.FindElement(By.XPath(".//div[@class='inventory_item_name']")).Text.Trim();

            //    productNames.Add(itemName);
            //}

            //return productNames;

            var productNames = _driver.FindElements(By.XPath("//div[@class='inventory_item_name']"))
                .Select(e => e.Text.Trim());

            return productNames;
        }

        public void VerifyIsAtCartPage()
        {
            _driver.WaitUntilUrlContains("cart.html");

            Assert.Multiple(() =>
            {
                Assert.That(CartTitle.Displayed, "Title is not visible.");
                Assert.That(QuantityLabel.Displayed, "Quantity label is not visible.");
                Assert.That(DescriptionLabel.Displayed, "Description label is not visible.");
                Assert.That(CheckoutButton.Displayed, "Checkout button is not visible.");
                Assert.That(ContinueButton.Displayed, "Continue shopping button is not visible.");
            });
        }

        public void VerifyCartIsNotEmpty()
        {
            Assert.That(CartItems.Count, Is.GreaterThan(0), "Cart is empty.");
        }
    }
}
