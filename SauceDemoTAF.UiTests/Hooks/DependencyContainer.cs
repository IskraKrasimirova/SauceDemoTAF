using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using SeleniumTestFramework.UiTests.Models.Builders;
using SeleniumTestFramework.UiTests.Models.Factories;
using SeleniumTestFramework.UiTests.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using ConfigurationManager = SeleniumTestFramework.UiTests.Utilities.ConfigurationManager;

namespace SeleniumTestFramework.UiTests.Hooks
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

            // Short syntax for registering page classes
            //services.AddScoped<LoginPage>();
            //services.AddScoped<DashboardPage>();
            //services.AddScoped<RegisterPage>();
            //services.AddScoped<UsersPage>();
        }
    }
}
