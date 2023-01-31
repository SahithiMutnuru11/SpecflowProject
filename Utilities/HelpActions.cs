using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Specflow_CSharpProject.Base;
using System;

namespace Specflow_CSharpProject.Utilities
{
    public class HelpActions : TestBase
    {
        public IWebDriver driver = TestBase.driver;
        ILog log = LogManager.GetLogger("HelpActionsClass");

        public void SendKeys(By element, string value, int timeout = 10)
        {
            if(WaitUntilElementIsClickable(element, timeout))
            {
                try
                {
                    var ele = driver.FindElement(element);
                    ScrollIntoView(ele);
                    ele.Click();
                    ele.SendKeys(value);
                }
                catch(Exception e)
                {
                    log.Error(e);
                    Console.WriteLine(e);
                }
            }
            else
                Assert.Fail("Element is not clickable");
        }

        public void ClickWithScroll(By element, int timeout = 10)
        {
            if (WaitUntilElementIsClickable(element, timeout))
            {
                try
                {
                    var ele = driver.FindElement(element);
                    ScrollIntoView(ele);
                    ele.Click();
                }
                catch (Exception e)
                {
                    log.Error(e);
                    Console.WriteLine(e);
                }
            }
            else
                Assert.Fail("Element is not clickable");
        }

        public string GetText(By element, int timeOut = 10)
        {
            string text = null;
            log.Info("waiting for element");
            if (WaitUntilElementIsVisibile(element, timeOut))
            {
                text = driver.FindElement(element).Text;
                log.Info($"Retrieved text is : {text}");
            }
            return text;
        }

        public string GetAttribute(By element, string value, int timeOut = 10)
        {
            string text = null;
            log.Info("waiting for element");
            if (WaitUntilElementIsVisibile(element, timeOut))
            {
                text = driver.FindElement(element).GetAttribute(value);
                log.Info($"Retrieved Attribute is : {text}");
            }
            return text;
        }

        public bool IsDisplayed(By element, int timeOut = 15)
        {
            bool flag = false;
            log.Info("waiting for element");
            if(WaitUntilElementIsVisibile(element, 15))
            {
                flag = true;
            }
            return flag;
        }

        public bool WaitUntilElementIsVisibile(By element, int timeOut = 30)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            var ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            if(ele != null)
            {
                return true;
            }
            return false;
        }

        public bool WaitUntilElementIsClickable(By element, int timeOut = 30)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            var ele = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            if (ele != null)
            {
                return true;
            }
            return false;
        }

        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView()", element);
        }
    }
}
