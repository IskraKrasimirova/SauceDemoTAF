using Reqnroll;
using SauceDemoTAF.UiTests.Pages;

namespace SauceDemoTAF.UiTests.Steps
{
    [Binding]
    public class ProductsSteps
    {
        private readonly ProductsPage _productsPage;

        public ProductsSteps(ProductsPage productsPage)
        {
          _productsPage = productsPage;  
        }

        [When("I add the first product to the cart")]
        public void WhenIAddTheFirstProductToTheCart()
        {
            _productsPage.AddProductToCartByIndex(0);
            _productsPage.VerifyProductIsAdded(0);
        }

        [When("I add the last product to the cart")]
        public void WhenIAddTheLastProductToTheCart()
        {
            var itemsCount = _productsPage.GetProductsCount;
            _productsPage.AddProductToCartByIndex(itemsCount-1);
            _productsPage.VerifyProductIsAdded(itemsCount-1);
        }

        [When("I add previous to the last product to the cart")]
        public void WhenIAddPreviousToTheLastProductToTheCart()
        {
            _productsPage.VerifyIsAtProductsPage();
            var itemsCount = _productsPage.GetProductsCount;
            _productsPage.AddProductToCartByIndex(itemsCount - 2);
            _productsPage.VerifyProductIsAdded(itemsCount - 2);
        }
    }
}
