using OpenQA.Selenium;
using SauceDemoTAF.UiTests.Utilities.Extensions;

namespace SauceDemoTAF.UiTests.Pages
{
    public class ProductsPage : BasePage
    {
        private IWebElement ProductsTitle => _driver.FindElement(By.XPath("//span[@class='title' and contains(text(), 'Products')]"));

        private IWebElement ProductsList => _driver.FindElement(By.XPath("//div[@class='inventory_list']"));

        private IReadOnlyCollection<IWebElement> ProductItems => _driver.FindElements(By.XPath("//div[@class='inventory_item']"));

        private IWebElement AppLogo => _driver.FindElement(By.XPath("//div[@class='app_logo' and contains(text(),'Swag Labs')]"));

        public ProductsPage(IWebDriver driver) : base(driver)
        {
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
    }
}
