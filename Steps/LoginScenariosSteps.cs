using log4net;
using OpenQA.Selenium;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Specflow_CSharpProject.Pages.PageMethods;
using Specflow_CSharpProject.Utilities;

namespace Specflow_CSharpProject
{
    [Binding]
    public class LoginScenariosSteps
    {
        ILog log = LogManager.GetLogger("LoginScenariosSteps");

        Instantiation ins = new Instantiation();
        Utility utilities = new Utility();

        [Given(@"I navigate to url - '(.*)'")]
        public void GivenINavigatetoUrl(string appName)
        {
            string url = (ConfigurationManager.GetSection("URL") as System.Collections.Specialized.NameValueCollection)[appName];
            utilities.DefaultBrowserAction(url);
        }

        [Then(@"I verify login page")]
        public void ThenIVerifyLoginPage()
        {
            ins.loginPage.VerifyLoginPage();
        }

        [When(@"I enter user credentials")]
        public void WhenIEnterUserCred(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            //userName    password
            ins.loginPage.enterUserCredentials(data.userName, data.password);
        }
	
	    [Then(@"I verify login successful")]
        public void ThenIVerifyLoginSuccessful()
        {
            ins.loginPage.verifyloginSuccessful();
        }

        [Then(@"I Verify error message - '(.*)'")]
        public void ThenIVerifyerrorMessage(string errorMsg)
        {
            ins.loginPage.verifyErrorMessage(errorMsg);
        }              
    }
}
