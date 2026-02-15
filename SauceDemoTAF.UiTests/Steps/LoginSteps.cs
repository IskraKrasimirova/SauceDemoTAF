using OpenQA.Selenium;
using Reqnroll;
using SauceDemoTAF.UiTests.Models;
using SauceDemoTAF.UiTests.Pages;

namespace SauceDemoTAF.UiTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductsPage _productsPage;
        private readonly SettingsModel _settingsModel;

        public LoginSteps(IWebDriver driver,  LoginPage loginPage, ProductsPage productsPage, SettingsModel model)
        {
            _driver = driver;
            _loginPage = loginPage;
            _productsPage = productsPage;
            _settingsModel = model;
        }


        [Given("I am logged in as standard user")]
        public void GivenIAmLoggedInAsStandardUser()
        {
            _driver.Navigate().GoToUrl(_settingsModel.BaseUrl);
            _loginPage.VerifyIsAtLoginPage();

            var standardUsername = _loginPage.GetUsernameByText("standard_user");
            var password = _loginPage.GetPassword();
            _loginPage.LoginWith(standardUsername, password);

            _productsPage.VerifyIsAtProductsPage();
        }
    }
}
