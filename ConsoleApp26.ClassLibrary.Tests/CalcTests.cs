using ConsoleApp26.CalcLibrary;
using ConsoleApp26.CalcLibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleApp26.CalcLibrary.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_1and2passed_ResultIs3()
        {
            // Arange 
            Calc c = new Calc();
            int x = 1;
            int y = 2;
            int expected = 3;
            int actual;

            //Act 
            actual = c.Sum(x, y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetEmptyLinesCheck()
        {
            var dependecy = new StubDataProvider();
            Calc c = new Calc(dependecy);

            string fileName = "fileName.txt";
            int expected = 3;

            int actual = c.GetEmptyLines(fileName);
            Assert.AreEqual(expected, actual);
        }
    }
}
