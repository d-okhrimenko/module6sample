using ConsoleApp26.CalcLibrary;
using ConsoleApp26.CalcLibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Diagnostics;

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

        [TestMethod]
        public void CheckThatSmsWasSent()
        {
            IDataProvider dataDependency = new StubDataProvider();
            Mock<ISmsService> mockedSmsService = new Mock<ISmsService>();

            Mock<IDataProvider> md = new Mock<IDataProvider>();
            md.Setup(x => x.GetLinesFromFile("test.txt")).Returns(new string[] { });
            md.Setup(x => x.GetLinesFromFile("foo.txt")).Returns(new string[] { "1", "2" });

            mockedSmsService
                .Setup(service => service.GetAdminNumber())
                .Returns("+380501231212");

            ISmsService srv = mockedSmsService.Object;
            string r = srv.GetAdminNumber();
            Debug.WriteLine(r);

            Calc c = new Calc(dataDependency, mockedSmsService.Object);
            var counter = c.GetEmptyLines("foo.txt");
            var phoneNumber = mockedSmsService.Object.GetAdminNumber();

            mockedSmsService
                .Verify(service => service.SendSms(
                    It.Is<string>(x => x == counter + " empty lines"),
                    It.Is<string>(x => x == phoneNumber)
                    ),
                Times.Once);
        }
    }
}
