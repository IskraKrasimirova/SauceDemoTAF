using Reqnroll;
using SauceDemoTAF.UiTests.Models.Factories;
using SauceDemoTAF.UiTests.Pages;

namespace SauceDemoTAF.UiTests.Steps
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly CheckoutPage _checkoutPage;
        private readonly IUserFactory _userFactory;

        public CheckoutSteps(CheckoutPage checkoutPage, IUserFactory userFactory)
        {
            _checkoutPage = checkoutPage;
            _userFactory = userFactory;
        }

        [When("I finish the checkout")]
        public void WhenIFinishTheCheckout()
        {
            var user = _userFactory.CreateDefault();
            _checkoutPage.CompleteCheckout(user);
        }
    }
}
