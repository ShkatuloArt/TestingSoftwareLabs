using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleLib.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void IsTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(10, 28, 30));
        }

        [TestMethod]
        public void AllSidesIsZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void AllSidesIsNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(-10, -20, -5));
        }

        [TestMethod]
        public void IsTrianglePossible()
        {
            Assert.IsFalse(Triangle.IsTriangle(14, 50, 3));
        }

        [TestMethod]
        public void OneSideIsZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 15, 18));
        }

        [TestMethod]
        public void OneSideIsNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(27, -10, 12));
        }

        [TestMethod]
        public void IsIsoscelesTriangle()
        {
            Assert.IsTrue(Triangle.IsIsoscelesTriangle(20, 20, 18));
        }

        [TestMethod]
        public void IsEquilateralTriangle()
        {
            Assert.IsTrue(Triangle.IsEquilateralTriangle(14, 14, 14));
        }

        [TestMethod]
        public void IsRightTriangle()
        {
            Assert.IsTrue(Triangle.IsRightTriangle(3, 4, 5));
        }

        [TestMethod]
        public void IsAnotherTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(12, 3, 15));
        }
    }
}
