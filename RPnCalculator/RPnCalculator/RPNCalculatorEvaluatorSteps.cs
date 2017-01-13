using System;
using TechTalk.SpecFlow;
using NUnit;
using NUnit.Common;
using NUnit.Framework;
namespace RPnCalculator
{
    [Binding]
    public class RPNCalculatorEvaluatorSteps
    {
        private string evalresult = "";
        [Given(@"I have entered ""(.*)"" into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(string p0)
        {
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            evalresult = calci.Evaluate(p0);
            
        }
        
        [When(@"I press calculate")]
        public void WhenIPressCalculate()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be ""(.*)"" on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string p0)
        {
            Assert.AreEqual(evalresult,p0);
        }
    }
}
