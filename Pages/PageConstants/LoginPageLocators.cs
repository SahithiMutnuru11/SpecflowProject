using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow_CSharpProject.Pages.PageConstants
{
    public static class LoginPageLocators
    {
        public static readonly By logo = By.CssSelector(".login_logo");
        public static readonly By userName = By.Id("user-name");
        public static readonly By pwd = By.Id("password");
        public static readonly By login = By.Id("login-button");
        public static readonly By menu = By.XPath("//button[text()='Open Menu']");
        public static readonly By logout = By.XPath("//a[text()='Logout']");
        public static readonly By error = By.XPath("//div[@class='error-message-container error']");
        public static readonly By errorText = By.XPath("//div[@class='error-message-container error']//h3");

        public static By samp(string text)
        {
            return By.XPath($"//a[text()='{text}']");
        }
    }
}
