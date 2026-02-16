using Reqnroll;
using SauceDemoTAF.UiTests.Pages;


namespace SauceDemoTAF.UiTests.Steps
{
    [Binding]
    public class PrimaryHeaderSteps
    {
        private readonly PrimaryHeaderPage _primaryHeaderPage;
        private readonly LoginPage _loginPage;

        public PrimaryHeaderSteps(PrimaryHeaderPage primaryHeaderPage, LoginPage loginPage)
        {
            _primaryHeaderPage = primaryHeaderPage;
            _loginPage = loginPage;
        }

        [Then("I should be able to logout successfully")]
        public void ThenIShouldBeAbleToLogoutSuccessfully()
        {
            _primaryHeaderPage.VerifyPrimaryHeaderIsVisible();
            _primaryHeaderPage.OpenMenu();
            _primaryHeaderPage.Logout();
            _loginPage.VerifyIsAtLoginPage();
        }
    }
}
