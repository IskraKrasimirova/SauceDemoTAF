using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoTAF.UiTests.Utilities;
using SauceDemoTAF.UiTests.Utilities.Extensions;

namespace SauceDemoTAF.UiTests.Pages
{
    public class ProductsPage : BasePage
    {
        private IWebElement ProductsTitle => _driver.FindElement(By.XPath("//span[@class='title' and contains(text(), 'Products')]"));

        private IWebElement ProductsList => _driver.FindElement(By.XPath("//div[@class='inventory_list']"));

        private IReadOnlyCollection<IWebElement> ProductItems => _driver.FindElements(By.XPath("//div[@class='inventory_item']"));

        private IWebElement CartLink => _driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));

        private IWebElement SortingDropdown => _driver.FindElement(By.XPath("//select[@class='product_sort_container']"));


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

        public void SelectSorting(string optionText)
        {
            var select = new SelectElement(SortingDropdown);
            select.SelectByText(optionText);

            Retry.Until(() =>
            {
                var options = new SelectElement(SortingDropdown).Options;
                if (options.Count == 0)
                    throw new Exception("Sorting dropdown still empty");
            });
        }

        public List<decimal> GetItemsPrices()
        {
            var prices = new List<decimal>();

            foreach (var item in ProductItems)
            {
                var priceText = item.FindElement(By.XPath(".//div[@class='inventory_item_price']")).Text.Trim().Replace("$", "");
                prices.Add(decimal.Parse(priceText));
            }

            return prices;
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
