using NUnit.Framework;
using Kalkulator;
using System;

namespace Testy
{
    [TestFixture]
    public class ScientificCalculatorTests
    {
        [Test]
        public void Power_ValidInputs_ReturnsCorrectResult()
        {
            Assert.AreEqual(8, ScientificCalculator.Power(2, 3));  // 2^3 = 8
            Assert.AreEqual(1, ScientificCalculator.Power(5, 0));  // 5^0 = 1
            Assert.AreEqual(2, ScientificCalculator.Power(4, 0.5)); // sqrt(4) = 2
            Assert.AreEqual(0.1, ScientificCalculator.Power(10, -1), 0.0001); // 10^-1 = 0.1
        }

        [Test]
        public void SquareRoot_ValidAndInvalidInputs()
        {
            Assert.AreEqual(3, ScientificCalculator.SquareRoot(9));  // sqrt(9) = 3
            Assert.AreEqual(-1, ScientificCalculator.SquareRoot(0)); // sqrt(0) → -1
            Assert.AreEqual(-1, ScientificCalculator.SquareRoot(-4)); // sqrt(-4) → -1
        }

        [Test]
        public void Log_ValidAndInvalidInputs()
        {
            Assert.AreEqual(0, ScientificCalculator.Log(1));  // log(1) = 0
            Assert.AreEqual(0, ScientificCalculator.Log(1));  // log(1) = 0
            Assert.AreEqual(1, ScientificCalculator.Log(Math.E), 0.0001);  // log(e) = 1
            Assert.AreEqual(Math.Log(10), ScientificCalculator.Log(10), 0.0001); // log(10) ≈ 2.3
            Assert.AreEqual(-1, ScientificCalculator.Log(0));  // log(0) → -1
            Assert.AreEqual(-1, ScientificCalculator.Log(-5)); // log(-5) → -1
        }
    }
}