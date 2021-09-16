using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class NumberToNumberTests
    {
        NumberToNumber x = new NumberToNumber();

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(1 + 2, 2)]
        [DataRow(1 + 2 + 3, 3)]
        [DataRow(1 + 2 + 3 + 4, 4)]
        public void SumNumbersTo(int expected, int input)
        {
            Assert.AreEqual(expected, x.SumNumbersTo(input));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void SumNumbersTo_InvalidInput(int input)
        {
            Assert.ThrowsException<ArgumentException>(() => x.SumNumbersTo(input));
        }

        [TestMethod]
        [DataRow(5, 5, 5)]
        [DataRow(5 + 6, 5, 6)]
        [DataRow(3 + 4 + 5 + 6 + 7, 3, 7)]
        [DataRow(-3 + -2 + -1 + 0 + 1 + 2, -3, 2)]
        public void SumNumbers(int expected, int from, int to)
        {
            Assert.AreEqual(expected, x.SumNumbers(from, to));
        }

        [DataRow(5, 4)]
        [DataRow(-3, -4)]
        public void SumNumbers_InvalidInput(int from, int to)
        {
            Assert.ThrowsException<ArgumentException>(() => x.SumNumbers(from, to));
        }

        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(0, 2)]
        [DataRow(3, 3)]
        [DataRow(3, 4)]
        [DataRow(3 + 5, 5)]
        [DataRow(3 + 5 + 6, 6)]
        [DataRow(3 + 5 + 6, 7)]
        [DataRow(3 + 5 + 6, 8)]
        [DataRow(3 + 5 + 6 + 9, 9)]
        [DataRow(3 + 5 + 6 + 9 + 10, 10)]
        public void SumNumbersDividedByThreeOrFive(int expected, int input)
        {
            Assert.AreEqual(expected, x.SumNumbersDividedByThreeOrFive(input));
        }

    }
}
