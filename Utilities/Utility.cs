using OpenQA.Selenium;
using Specflow_CSharpProject.Base;
using System;

namespace Specflow_CSharpProject.Utilities
{
    public class Utility
    {
        public IWebDriver driver = TestBase.driver;
        public void DefaultBrowserAction(string url)
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }
    }
}
