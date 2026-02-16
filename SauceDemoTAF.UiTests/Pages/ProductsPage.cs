using OpenQA.Selenium;
using SauceDemoTAF.UiTests.Utilities.Extensions;

namespace SauceDemoTAF.UiTests.Pages
{
    public class ProductsPage : BasePage
    {
        private IWebElement ProductsTitle => _driver.FindElement(By.XPath("//span[@class='title' and contains(text(), 'Products')]"));

        private IWebElement ProductsList => _driver.FindElement(By.XPath("//div[@class='inventory_list']"));

        private IReadOnlyCollection<IWebElement> ProductItems => _driver.FindElements(By.XPath("//div[@class='inventory_item']"));

        private IWebElement CartLink => _driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));

        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }

        public int GetProductsCount => ProductItems.Count;

        public void AddProductToCartByIndex(int index)
        {
            var product = ProductItems.ElementAt(index);
            var addButton = product.FindElement(By.XPath(".//button[text()='Add to cart']"));
            _driver.ScrollAndClickJs(addButton);
        }

        public void GoToCart()
        {
            _driver.ScrollAndClickJs(CartLink);
        }

        public void VerifyIsAtProductsPage()
        {
            _driver.WaitUntilUrlContains("inventory.html");

            Assert.Multiple(() =>
            {
                Assert.That(ProductsTitle.Displayed, "Title is not visible.");
                Assert.That(ProductsList.Displayed, "Products list is not visible.");
                Assert.That(ProductItems.Count, Is.GreaterThan(0), "No products found on the Products page.");
            });
        }

        public void VerifyProductIsAdded(int index)
        {
            var product = ProductItems.ElementAt(index);
            var addButtons = product.FindElements(By.XPath(".//button[text()='Add to cart']"));
            var removeButtons = product.FindElements(By.XPath(".//button[text()='Remove']"));

            Assert.Multiple(() =>
            {
                Assert.That(addButtons.Count, Is.EqualTo(0));
                Assert.That(removeButtons.Count, Is.EqualTo(1));
            });
        }
    }
}
