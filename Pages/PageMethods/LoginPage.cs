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
using Specflow_CSharpProject.Pages.PageConstants;
using Specflow_CSharpProject.Utilities;

namespace Specflow_CSharpProject.Pages
{
    public class LoginPage : HelpActions
    {
        public IWebDriver driver;
        ILog log = LogManager.GetLogger("LoginPage");
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            log = LogManager.GetLogger("LoginPage");
        }

        public void VerifyLoginPage()
        {            
            if (IsDisplayed(LoginPageLocators.logo))
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
            if (IsDisplayed(LoginPageLocators.userName, 10))
                SendKeys(LoginPageLocators.userName, userName);
            else
            {
                log.Error("user Name field is not displayed");
                Assert.Fail("UserName Field is not displayed");
            }
            if (IsDisplayed(LoginPageLocators.pwd))
            {
                SendKeys(LoginPageLocators.pwd, password);

                // Verify Password is masked
                Assert.AreEqual("password", GetAttribute(LoginPageLocators.pwd, "type"),"Password is not masked");
            }
            else
            {
                log.Error("password field is not displayed");
                Assert.Fail("Password Field is not displayed");
            }

            if (IsDisplayed(LoginPageLocators.login))
                ClickWithScroll(LoginPageLocators.login);
            else
            {
                log.Error("login button is not displayed");
                Assert.Fail("login button is not displayed");
            }
        }

        public void verifyloginSuccessful()
        {

            if (IsDisplayed(LoginPageLocators.menu))
                ClickWithScroll(LoginPageLocators.menu);
            else
            {
                log.Error("menu is not loaded");
                //Assert.Fail("menu is not loaded");
            }
            
            if (IsDisplayed(LoginPageLocators.logout))
                log.Info("User is logged in");
            else
            {
                log.Error("User is not logged in");
                Assert.Fail("User is not logged in");
            }
        }

        public void verifyErrorMessage(string eMessage)
        {
            
            if (IsDisplayed(LoginPageLocators.error))
            {
                log.Info("Error message is displayed");
                string errorMsg = GetText(LoginPageLocators.errorText);
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
