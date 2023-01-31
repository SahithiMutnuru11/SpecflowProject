using Specflow_CSharpProject.Pages.PageMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow_CSharpProject.Steps
{
    [Binding]
    public class SampleTestSteps
    {
        Instantiation ins = new Instantiation();

        [Then(@"I Verify TestPage")]
        public void ThenIVerifyTestPage()
        {
            ins.testPage.testSample();
        }
    }
}
