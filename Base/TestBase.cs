using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        [BeforeScenario]
        public static void Initialization()
        {
            string browser = (ConfigurationManager.GetSection("BROWSER") as System.Collections.Specialized.NameValueCollection)[browserName];
            if (browser.Equals("chrome"))
            {
                directory = Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;

                options.AddArguments("--disable-background-mode");
                options.AddArguments("--disable-extentions");
                driver = new ChromeDriver(directory + "\\Drivers", options);
            }

            if (ScenarioContext.Current.ContainsKey("driver"))
            {
                ScenarioContext.Current.Remove("driver");
            }

            ScenarioContext.Current.Add("driver", driver);
        }

        [AfterScenario]
        public static void QuitDriver()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            driver.Quit();
        }
    }
}
