using Reqnroll;
using SauceDemoTAF.UiTests.Pages;
using SauceDemoTAF.UiTests.Utilities.Constants;

namespace SauceDemoTAF.UiTests.Steps
{
    [Binding]
    public class CartSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ProductsPage _productsPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutPage _checkoutPage;

        public CartSteps(ScenarioContext scenarioContext, ProductsPage productsPage, CartPage cartPage, CheckoutPage checkoutPage)
        {
            _scenarioContext = scenarioContext;
            _productsPage = productsPage;
            _cartPage = cartPage;
            _checkoutPage = checkoutPage;
        }

        [When("I verify the correct products are added to the cart:")]
        public void WhenIVerifyTheCorrectProductsAreAddedToTheCart(DataTable dataTable)
        {
            _productsPage.GoToCart();
            _cartPage.VerifyIsAtCartPage();
            _cartPage.VerifyCartIsNotEmpty();

            var expectedProducts = dataTable.Rows.Select(r => r[0].ToString().Trim());
            var actualProducts = _cartPage.GetCartProductsNames();

            Assert.That(actualProducts.Count(), Is.EqualTo(expectedProducts.Count()));

            Assert.That(actualProducts, Is.EquivalentTo(expectedProducts));

            _scenarioContext[ContextConstants.ItemNames] = actualProducts;
        }

        [When("I remove the first item from the cart")]
        public void WhenIRemoveTheFirstItemFromTheCart()
        {
            _cartPage.RemoveCartItemByIndex(0);
            _cartPage.GoToProducts();
        }

        [When("I go to checkout")]
        public void WhenIGoToCheckout()
        {
            _cartPage.GoToCheckoutPage();
            _checkoutPage.VerifyIsAtCheckoutPage();
        }


        [Then("the cart should be empty")]
        public void ThenTheCartShouldBeEmpty()
        {
            _productsPage.VerifyIsAtProductsPage();
            _productsPage.GoToCart();
            _cartPage.VerifyCartIsEmpty();
        }
    }
}
