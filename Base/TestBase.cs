using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Specflow_CSharpProject.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow_CSharpProject.Base
{
    [Binding]
    public class TestBase
    {
        public static IWebDriver driver;
        public static string directory = null;
        public static string browserName = "Chrome";
        private static ChromeOptions options = new ChromeOptions();
        static Utility utility = new Utility();

        [BeforeScenario]
        public static void Initialization()
        {
            string browser = (ConfigurationManager.GetSection("BROWSER") as System.Collections.Specialized.NameValueCollection)[browserName];
            if (browser.Equals("chrome"))
            {
                directory = utility.getDirectory();

                options.AddArguments("--disable-background-mode");
                options.AddArguments("--disable-extentions");
                //options.AddArguments("--headless");
                driver = new ChromeDriver(utility.GetDriverLocation(), options);
            }

            if (ScenarioContext.Current.ContainsKey("driver"))
            {
                ScenarioContext.Current.Remove("driver");
            }

            ScenarioContext.Current.Add("driver", driver);
            //ScenarioContext.Current.get["driver"];
        }

        [AfterScenario]
        public static void QuitDriver()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            try
            {
                if (ScenarioContext.Current.TestError != null)
                {
                    utility.GetScreenshot(driver);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
