using OpenQA.Selenium;
using Specflow_CSharpProject.Base;

namespace Specflow_CSharpProject.Pages.PageMethods
{
    public class Instantiation
    {
        public IWebDriver driver = TestBase.driver;

        public LoginPage loginPage;
        public TestPage testPage;
        public Instantiation()
        {
            loginPage = new LoginPage(driver);
            testPage = new TestPage(driver);
        }        
    }
}
