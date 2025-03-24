using NUnit.Framework;
using Kalkulator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KalkulatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_ReturnsCorrectSum()
        {
            Assert.AreEqual(5, Calculator.Add(2, 3));
            Assert.AreEqual(-1, Calculator.Add(2, -3));
            Assert.AreEqual(0, Calculator.Add(0, 0));
        }

        [Test]
        public void Substract_ReturnsCorrectDifference()
        {
            Assert.AreEqual(2, Calculator.Substract(5, 3));
            Assert.AreEqual(-5, Calculator.Substract(-2, 3));
            Assert.AreEqual(0, Calculator.Substract(4, 4));
        }

        [Test]
        public void Multiply_ReturnsCorrectProduct()
        {
            Assert.AreEqual(6, Calculator.Multiply(2, 3));
            Assert.AreEqual(-6, Calculator.Multiply(-2, 3));
            Assert.AreEqual(0, Calculator.Multiply(0, 5));
        }

        [Test]
        public void Divide_ReturnsCorrectQuotient()
        {
            Assert.AreEqual(2, Calculator.Divide(6, 3));
            Assert.AreEqual(-2, Calculator.Divide(-6, 3));
            Assert.AreEqual(0.5, Calculator.Divide(1, 2), 0.0001);
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(5, 0));
        }

        [Test]
        public void SumSequence_ReturnsCorrectSum()
        {
            Assert.AreEqual(10, Calculator.SumSequence(new List<double> { 2, 3, 5 }));
            Assert.AreEqual(0, Calculator.SumSequence(new List<double> { }));
            Assert.AreEqual(-6, Calculator.SumSequence(new List<double> { -2, -4 }));
        }

        [Test]
        public void AverageSequence_ReturnsCorrectAverage()
        {
            Assert.AreEqual(3, Calculator.AverageSequence(new List<double> { 2, 3, 4 }));
            Assert.AreEqual(-3, Calculator.AverageSequence(new List<double> { -2, -3, -4 }));
        }

        [Test]
        public void AverageSequence_EmptyList_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => Calculator.AverageSequence(new List<double> { }));
        }

        [Test]
        public void MaxSequence_ReturnsMaxValue()
        {
            Assert.AreEqual(5, Calculator.MaxSequence(new List<double> { 1, 2, 5, 3 }));
            Assert.AreEqual(-1, Calculator.MaxSequence(new List<double> { -5, -3, -1 }));
        }

        [Test]
        public void MinSequence_ReturnsMinValue()
        {
            Assert.AreEqual(1, Calculator.MinSequence(new List<double> { 1, 2, 5, 3 }));
            Assert.AreEqual(-5, Calculator.MinSequence(new List<double> { -5, -3, -1 }));
        }
    }
}
