﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestRPNCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void CheckForOperSanitySingleToken()
        {

            string expr1 = "ABCDEKJk";

            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();

            bool result = calci.validate(expr1);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckForOperSanityCorrect()
        {

            string expr1 = "3 5 +";

            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();

            bool result = calci.validate(expr1);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void CheckForOperSanityNullString()
        {

            string expr1 = null;

            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();

            bool result = calci.validate(expr1);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckForOperSanityEmptyString()
        {

            string expr1 = string.Empty;

            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();

            bool result = calci.validate(expr1);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckForOperSanityInvalidInput()
        {

            string expr1 = "AB 2 + 4 -";

            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();

            bool result = calci.validate(expr1);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void EvaluateDivideByZero()
        {
            string expr1 = "2 0 /";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("",result);
        }

        [TestMethod]
        
        public void EvaluateAddition()
        {
            string expr1 = "0 2 +";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("2",result);
        }

        [TestMethod]
        
        public void EvaluateDivision()
        {
            string expr1 = "4 2 /";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
             string result = calci.Evaluate(expr1);
             Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void EvaluatePercent()
        {
            string expr1 = "4 %";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("0.04", result);
        }
        [TestMethod]
        
        public void Evaluatesubstraction()
        {
            string expr1 = "1 2 -";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("-1", result);
        }

        [TestMethod]
        
        public void EvaluateMultiplicate()
        {
            string expr1 = "4 2 *";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("8", result);
        }
        [TestMethod]
        public void EvaluateFactorial()
        {
            string expr1 = "4 !";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("24", result);
        }
        [TestMethod]
        public void SampleDataTest()
        {
            string expr1 = "1 2 3 + -";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("-4", result);
        }
        [TestMethod]
        public void SampleDataTest2()
        {
            string expr1 = "5 1 2 + 4 * + 3 -";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("14", result);
        }

        [TestMethod]
        public void SampleDataTest3()
        {
            string expr1 = "12 3 / !";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("24", result);
        }

        [TestMethod]
        public void SampleDataTest4()
        {
            string expr1 = "3 ! 4 5 * +";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("26", result);
        }

        [TestMethod]
        public void SampleDataTest5()
        {
            string expr1 = "50 % 2 *";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void SampleDataTest6()
        {
            string expr1 = "2 3 ^ 4 5 + +";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("17", result);
        }

        public void SampleDataTest7()
        {
            string expr1 = "6 2 * 3 /";
            RPnCalculator.Calculator calci = new RPnCalculator.Calculator();
            string result = calci.Evaluate(expr1);
            Assert.AreEqual("4", result);
        }
		
		
    }
}
