using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using SauceDemoTAF.UiTests.Models.Builders;
using SauceDemoTAF.UiTests.Models.Factories;
using SauceDemoTAF.UiTests.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using ConfigurationManager = SauceDemoTAF.UiTests.Utilities.ConfigurationManager;

namespace SauceDemoTAF.UiTests.Hooks
{
    public class DependencyContainer
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();
            
            services.AddSingleton(sp =>
            {
                return ConfigurationManager.Instance.SettingsModel;
            });

            services.AddScoped<IWebDriver>(sp =>
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

                //var options = new ChromeOptions();

                //// Disable password manager completely
                //options.AddUserProfilePreference("credentials_enable_service", false);
                //options.AddUserProfilePreference("profile.password_manager_enabled", false);

                //// Disable all password-related popups
                //options.AddArgument("--disable-save-password-bubble"); 
                //options.AddArgument("--disable-features=PasswordManagerOnboarding,PasswordManagerRedesign"); 
                //options.AddArgument("--disable-features=PasswordLeakDetection");

                //// Optional but recommended
                //options.AddArgument("--disable-notifications");

                //var driver = new ChromeDriver(options);

                var driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                return driver;
            });

            services.AddSingleton<IUserFactory, UsersFactory>();
            services.AddScoped<UserBuilder>();

            RegisterPages(services);

            return services;
        }

        private static void RegisterPages(ServiceCollection services)
        {
            services.AddScoped(sp =>
            {
                var driver = sp.GetRequiredService<IWebDriver>();
                return new LoginPage(driver);
            });

            services.AddScoped<ProductsPage>();
            //services.AddScoped<CartPage>();
        }
    }
}
