﻿using System;
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
        [TestCase("2,4,6,8", 20)]
        [TestCase("19,appreciate,20,20,50", 109)]
        public void ShouldAllowUnlimitedNumbers(string sInput, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Program.Add(sInput);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }

        [Test]
        [TestCase("1\n2,3,9", 15)]
        public void ShouldAllowNewlineDelimiter(string sInput, int iRealResult)
        {
            Program programTest = new StringCalcNewSLN.Program();
            int iCalculatedResult = Program.Add(sInput);
            Assert.AreEqual(iCalculatedResult, iRealResult);
        }

        [Test]
        [TestCase("1,2,3,-9")]
        [TestCase("-17")]
        public void ShouldThrowExceptionWhenInputIsNegative(string sInput)
        {
            Assert.Throws<Exception>(() => Program.Add(sInput));
        }

        [Test]
        [TestCase("1,2,3,-9, -17")]
        public void ShouldListNegativeNumbersInExceptionMessageOnNegativeInput(string sInput)
        {
            Assert.That(() => Program.Add(sInput), 
                Throws.TypeOf<Exception>()
                .With.Message.EqualTo("Your input contained the following invalid negative numbers: -9,-17. Please try again."));
        }
    }
}
