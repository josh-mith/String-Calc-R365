using System;
using NUnit.Framework;
using StringCalcNewSLN;

namespace StringCalcNewSLNTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("26, 17", 43)]
        [TestCase("21, 14", 35)]
        public void ReturnsSumOfCommaDelimitedNumbers(string sInput, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Program.Add(sInput);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }

        [Test]
        [TestCase("28,", 28)]
        [TestCase("", 0)]
        [TestCase("714,Irvine", 714)]
        public void RegardsEmptyTextAndNonNumericAsZero(string sInput, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Program.Add(sInput);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }

        [Test]
        [TestCase("2,4,6,8")]
        [TestCase("19,appreciate,20")]
        public void ShouldAllowSumOfMaximumTwoNumbers(string sInput)
        {
            Program programTest = new StringCalcNewSLN.Program();
            Assert.Throws<Exception>(() => Program.Add(sInput));
        }
    }
}
