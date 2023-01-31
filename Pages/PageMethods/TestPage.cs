using log4net;
using OpenQA.Selenium;
using Specflow_CSharpProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow_CSharpProject.Pages.PageMethods
{
    public class TestPage : HelpActions
    {
        IWebDriver driver;
        ILog log = LogManager.GetLogger("SamplePage");
        public TestPage(IWebDriver driver)
        {
            this.driver = driver;
            log = LogManager.GetLogger("SamplePage");
        }

        public void testSample()
        {
            Console.WriteLine("I'm in sample");
            log.Info("I'm in sample");
        }
    }
}
