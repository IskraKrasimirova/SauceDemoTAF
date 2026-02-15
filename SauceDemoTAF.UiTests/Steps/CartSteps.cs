using Reqnroll;
using SauceDemoTAF.UiTests.Pages;

namespace SauceDemoTAF.UiTests.Steps
{
    [Binding]
    public class CartSteps
    {
        private readonly ProductsPage _productsPage;

        public CartSteps(ProductsPage productsPage)
        {
            _productsPage = productsPage;
        }

        [When("I verify the correct products are added to the cart:")]
        public void WhenIVerifyTheCorrectProductsAreAddedToTheCart(DataTable dataTable)
        {
            var cartPage = _productsPage.GoToCart();
            cartPage.VerifyIsAtCartPage();
            cartPage.VerifyCartIsNotEmpty();

            var expectedProducts = dataTable.Rows.Select(r => r[0].ToString().Trim());
            var actualProducts = cartPage.GetCartProductsNames();

            Assert.That(actualProducts.Count(), Is.EqualTo(expectedProducts.Count()));

            Assert.That(actualProducts, Is.EquivalentTo(expectedProducts));
        }
    }
}
