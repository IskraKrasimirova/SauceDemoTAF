using Reqnroll;
using SauceDemoTAF.UiTests.Pages;
using SauceDemoTAF.UiTests.Utilities.Constants;

namespace SauceDemoTAF.UiTests.Steps
{
    [Binding]
    public class OrderSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly OrderPage _orderPage;
        private readonly OrderConfirmationPage _orderConfirmationPage;

        public OrderSteps(ScenarioContext scenarioContext, OrderPage orderPage, OrderConfirmationPage orderConfirmationPage)
        {
            _scenarioContext = scenarioContext;
            _orderPage = orderPage;
            _orderConfirmationPage = orderConfirmationPage;
        }

        [Then("the order should be successfully placed")]
        public void ThenTheOrderShouldBeSuccessfullyPlaced()
        {
            _orderPage.VerifyIsAtOrderPage();

            var expectedItems = _scenarioContext.Get<IEnumerable<string>>(ContextConstants.ItemNames);
            var actualItems = _orderPage.GetOrderProductsNames();

            Assert.That(actualItems.Count(), Is.EqualTo(expectedItems.Count()));

            Assert.That(actualItems, Is.EquivalentTo(expectedItems));

            _orderPage.FinishOrder();
            _orderConfirmationPage.VerifyIsAtOrderConfirmationPage();
            _orderConfirmationPage.GoToProductsPage();
        }
    }
}
