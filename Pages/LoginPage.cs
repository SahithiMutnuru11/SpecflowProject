using log4net;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace TestProject_Cyara.Pages
{
    public class LoginPage
    {
        IWebDriver driver;
        ILog log;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            log = LogManager.GetLogger("LoginPage");
        }

        public void VerifyLoginPage()
        {
            IWebElement logo = driver.FindElement(By.CssSelector(".login_logo"));
            if (logo.Displayed)
            {
                log.Info("Login page is successfully loaded");
            }
            else
            {
                log.Error("Login Page is not loaded properly");
            }
        }

        public void enterUserCredentials(string userName, string password)
        {
            IWebElement user = driver.FindElement(By.Id("user-name"));
            IWebElement pwd = driver.FindElement(By.Id("password"));
            if (user.Displayed)
                user.SendKeys(userName);
            else
            {
                log.Error("user Name field is not displayed");
                Assert.Fail("UserName Field is not displayed");
            }
            if (pwd.Displayed)
            {
                pwd.SendKeys(password);

                // Verify Password is masked
                Assert.AreEqual("password",pwd.GetAttribute("type"),"Password is not masked");
            }
            else
            {
                log.Error("password field is not displayed");
                Assert.Fail("Password Field is not displayed");
            }
            IWebElement login = driver.FindElement(By.Id("login-button"));

            if (login.Displayed)
                login.Click();
            else
            {
                log.Error("login button is not displayed");
                Assert.Fail("login button is not displayed");
            }
        }

        public void verifyloginSuccessful()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Open Menu']")));
            IWebElement menu = driver.FindElement(By.XPath("//button[text()='Open Menu']"));
            if (menu.Displayed)
                menu.Click();
            else
            {
                log.Error("menu is not loaded");
                //Assert.Fail("menu is not loaded");
            }
            var element2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Logout']")));
            IWebElement logout = driver.FindElement(By.XPath("//a[text()='Logout']"));
            if (logout.Displayed)
                log.Info("User is logged in");
            else
            {
                log.Error("User is not logged in");
                Assert.Fail("User is not logged in");
            }
        }

        public void verifyErrorMessage(string eMessage)
        {
            IWebElement error = driver.FindElement(By.XPath("//div[@class='error-message-container error']"));
            if (error.Displayed)
            {
                log.Info("Error message is displayed");
                string errorMsg = driver.FindElement(By.XPath("//div[@class='error-message-container error']//h3")).Text;
                Assert.IsTrue(errorMsg.Contains(eMessage), "Error message is not as expected");
            }
            else
            {
                log.Error("Error message is displayed");
                Assert.Fail("Error message is displayed");
            }
        }
    }
}
