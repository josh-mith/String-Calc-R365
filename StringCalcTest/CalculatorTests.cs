using System;
using NUnit.Framework;
using StringCalcNewSLN;

namespace StringCalcNewSLNTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("26, 17", new string[] {",", "\n"}, 43)]
        [TestCase("21, 14", new string[] { ",", "\n" }, 35)]
        public void ReturnsSumOfCommaDelimitedNumbers(string sInput, string[] sDelimiters, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Calculator.Add(sInput, sDelimiters);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }

        [Test]
        [TestCase("28,", 28)]
        [TestCase("", new string[] { ",", "\n" }, 0)]
        [TestCase("714,Irvine", new string[] { ",", "\n" }, 714)]
        public void RegardsEmptyTextAndNonNumericAsZero(string sInput, string[] sDelimiters, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Calculator.Add(sInput, sDelimiters);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }

        [Test]
        [TestCase("2,4,6,8", new string[] { ",", "\n" }, 20)]
        [TestCase("19,appreciate,20,20,50", new string[] { ",", "\n" }, 109)]
        public void ShouldAllowUnlimitedNumbers(string sInput, string[] sDelimiters, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Calculator.Add(sInput, sDelimiters);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }

        [Test]
        [TestCase("1\n2,3,9", new string[] { ",", "\n" }, 15)]
        public void ShouldAllowNewlineDelimiter(string sInput, string[] sDelimiters, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Calculator.Add(sInput, sDelimiters);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }

        [Test]
        [TestCase("1,2,3,-9", new string[] { ",", "\n" })]
        [TestCase("-17", new string[] { ",", "\n" })]
        public void ShouldThrowExceptionWhenInputIsNegative(string sInput, string[] sDelimiters)
        {
            Assert.Throws<Exception>(() => Calculator.Add(sInput, sDelimiters));
        }

        [Test]
        [TestCase("9001,1", new string[] { ",", "\n" }, 1)]
        [TestCase("1001", new string[] { ",", "\n" }, 0)]
        [TestCase("127, 1001", new string[] { ",", "\n"}, 127)]
        public void RegardsNumbersOverAThousandAsZero(string sInput, string[] sDelimiters, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Calculator.Add(sInput, sDelimiters);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }

        [Test]
        [TestCase("120qqq7", new string[] { ",", "\n","qqq"}, 127)]
        public void LetsUsersAddCustomDelimiter(string sInput, string[] sDelimiters, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Calculator.Add(sInput, sDelimiters);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }
    }
}
