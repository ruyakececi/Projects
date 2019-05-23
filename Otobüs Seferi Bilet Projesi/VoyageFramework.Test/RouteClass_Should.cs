using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VoyageFramework;

namespace UnitTestProject1
{
    [TestClass]
    public class RouteClass_Should
    {
        [TestMethod]
        public void TestMethod1()
        {
            //ARRANGE
            int Distance = 225;
            int ExpectedResult = 45;
            Route route = new Route("Ankara", "Konya", Distance);
            //ACT
            decimal ActualResult = route.BasePrice;
            //ASSERT
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestMethod]
        public void ReturnBasePrice_114forGiven600()
        {
            //ARRANGE
            int Distance = 600;
            int ExpectedResult = 111;
            Route route = new Route("Ankara", "Konya", Distance);
            //ACT
            decimal ActualResult = route.BasePrice;
            //ASSERT
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestMethod]
        public void GetBreakCount()
        {
            //ARRANGE
            int Distance = 401;
            int ExpectedResult = 2;
            Route route = new Route("Ankara", "Konya", Distance);
            //ACT
            route.BreakCount = 5;
            int ActualResult = route.BreakCount;
            //ASSERT
            Assert.AreEqual(ExpectedResult,ActualResult);

        }
        [TestMethod]
        public void GetBreakCount_5WhenSetAboveGiven_1000()
        {
            //ARRANGE
            int Distance = 1000;
            int Expected = 5;
            Route route = new Route("Ankara", "Konya", Distance);
            //ACT
            route.BreakCount = 10;
            int Actual = route.BreakCount;
            //ASSERT
            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        public void Duration()
        {
            //ARRANGE
            int Distance = 100;
            int Expected = 75;
            Route route = new Route("Ankara", "Konya", Distance);
            //ACT
            int Actual = route.Duration;
            //ASSERT
            Assert.AreEqual(Expected, Actual);
            
        }
    }
}
