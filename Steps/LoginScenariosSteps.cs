using log4net;
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
using TechTalk.SpecFlow.Assist;
using TestProject_Cyara.Pages;

namespace TestProject_Cyara
{
    [Binding]
    public class LoginScenariosSteps
    {
        private static IWebDriver driver = null;
        public static string directory= null;
        public static string browserName = "Chrome";
        private static ChromeOptions options = new ChromeOptions();
        ILog log = LogManager.GetLogger("LoginScenariosSteps");

        public LoginPage loginPage;
        
        [BeforeScenario]
        public static void Initialization()
        {
            string browser = (ConfigurationManager.GetSection("BROWSER") as System.Collections.Specialized.NameValueCollection)[browserName];
            if (browser.Equals("chrome"))
            {
                directory = Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
                
                options.AddArguments("--disable-background-mode");
                options.AddArguments("--disable-extendtions");
                driver = new ChromeDriver(directory + "\\Drivers", options);
            }

        }

        [Given(@"I navigate to url - '(.*)'")]
        public void GivenINavigatetoUrl(string appName)
        {
            if (ScenarioContext.Current.ContainsKey("driver"))
            {
                ScenarioContext.Current.Remove("driver");
            }

            ScenarioContext.Current.Add("driver", driver);

            string url = (ConfigurationManager.GetSection("URL") as System.Collections.Specialized.NameValueCollection)[appName];
            driver.Manage().Cookies.DeleteAllCookies();

            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            loginPage = new LoginPage(driver);
        }

        [Then(@"I verify login page")]
        public void ThenIVerifyLoginPage()
        {
            loginPage.VerifyLoginPage();
        }

        [When(@"I enter user credentials")]
        public void WhenIEnterUserCred(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            //userName    password
            loginPage.enterUserCredentials(data.userName, data.password);
        }
	
	    [Then(@"I verify login successful")]
        public void ThenIVerifyLoginSuccessful()
        {
            loginPage.verifyloginSuccessful();
        }

        [Then(@"I Verify error message - '(.*)'")]
        public void ThenIVerifyerrorMessage(string errorMsg)
        {
            loginPage.verifyErrorMessage(errorMsg);
        }

        [AfterScenario]
        public void QuitDriver()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            driver.Quit();
        }
    }
}
