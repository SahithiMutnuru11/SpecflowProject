using OpenQA.Selenium;
using Specflow_CSharpProject.Base;
using System;
using System.IO;
using TechTalk.SpecFlow;

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

        public string getDirectory()
        {
            return Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
        }

        public string GetDriverLocation()
        {
            return getDirectory() + "\\Drivers";
        }

        public string GetScreenshotFolder()
        {
            String filePath = Path.Combine(Directory.GetParent(getDirectory()).FullName, "Automation_Report");
            filePath = Path.Combine(filePath, "OutPut");
            filePath = Path.Combine(filePath, "Screenshots");
            filePath = Path.Combine(filePath, "Screenshots_On"+DateTime.Today.ToString("dd-MM-yyyy"));
            return filePath;
        }

        public void GetScreenshot(IWebDriver driver)
        {            
            string filePath = GetScreenshotFolder();
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                Console.WriteLine(filePath);
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                String fileName = ScenarioContext.Current.ScenarioInfo.Title.Replace(' ', '_') + DateTime.Now.ToString("HH-mm_dd-MM-yy") + ".png";
                fileName = Path.Combine(filePath, fileName);
                Console.WriteLine(fileName);
                ss.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
