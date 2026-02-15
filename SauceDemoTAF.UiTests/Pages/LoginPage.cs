using OpenQA.Selenium;
using SauceDemoTAF.UiTests.Utilities.Extensions;

namespace SauceDemoTAF.UiTests.Pages
{
    public class LoginPage: BasePage
    {
        // Elements 
        private IWebElement UsernameInput => _driver.FindElement(By.XPath("//input[@id='user-name']"));
        private IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@type='password']"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//input[@type='submit' and @id='login-button']"));
        private IWebElement LoginLogo => _driver.FindElement(By.XPath("//div[@id='root']//child::div[contains(text(),'Swag Labs')]"));

        public LoginPage(IWebDriver driver): base(driver)
        {
        }

        // Actions
        public string GetUsernameByText(string value)
        {
            var usernames = _driver.FindElement(By.XPath("//div[@id='login_credentials']")).Text;
            var username = usernames
                .Split('\n')
                .Select(x => x.Trim())
                .First(x => x == value);

            return username;
        }

        public string GetPassword()
        {
            var passwordsText = _driver.FindElement(By.XPath("//div[@class='login_password']")).Text;
            return passwordsText.Split('\n').Last().Trim();
        }

        public void LoginWith(string username, string password)
        {
            UsernameInput.EnterText(username);
            PasswordInput.EnterText(password);

            LoginButton.Click();
        }

        //public RegisterPage GoToRegisterPage()
        //{
        //    SignUpLink.Click();
        //    return new RegisterPage(_driver);
        //}

        // Validations

        public void VerifyIsAtLoginPage()
        {
            Assert.Multiple(() =>
            {
                Assert.That(UsernameInput.Displayed, "Username input is not visible.");
                Assert.That(PasswordInput.Displayed, "Password input is not visible.");
                Assert.That(LoginButton.Displayed, "Login button is not visible.");
                Assert.That(LoginLogo.Displayed, "Login logo is not visible.");
            });
        }
    }
}
