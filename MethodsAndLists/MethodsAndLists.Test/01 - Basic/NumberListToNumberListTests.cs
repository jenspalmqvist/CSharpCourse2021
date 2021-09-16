// Lös uppgifterna med och utan Linq (gör alltså två olika metoder)
using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class NumberListToNumberListTests
    {
        NumberListToNumberList x = new NumberListToNumberList();

        // Demo: dubblera alla tal i listan
        // Demo: dubblera alla tal i listan. Hoppa över negativa tal.

        [TestMethod]
        public void Add100ToEachNumber()
        {
            // Addera 100 till varje siffra i listan

            var input = new List<int> { 5, 15, 23, 200 };
            var expected = new List<int> { 105, 115, 123, 300 };
            List<int> result = x.Add100ToEachNumber(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetNumbersHigherThan1000()
        {
            // Filtrera ut de tal som är högre än 1000

            var input = new List<int> { 1005, 6, 77, 200000, 666 };
            var expected = new List<int> { 1005, 200000 };
            List<int> result = x.GetNumbersHigherThan1000(input);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetNumbersDividableByFive()
        {
            // Filtrera ut de tal som är delbara med fem

            var input = new List<int> { 20, 5, 6, 7, 10 };
            var expected = new List<int> { 20, 5, 10 };
            List<int> result = x.GetNumbersDividableByFive(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DivideEachNumberBy100()
        {
            // Dela alla tal i listan med 100

            var input = new List<int> { 300, 200, -500, 1000 };
            var expected = new List<int> { 3, 2, -5, 10 };
            List<int> result = x.DivideEachNumberBy100(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NegateEachNumber()
        {
            // Negera alla tal i listan

            var input = new List<int> { 10, 20, -30, 40 };
            var expected = new List<int> { -10, -20, 30, -40 };
            List<int> result = x.NegateEachNumber(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add50ToFirstThreeElements()
        {
            // Addera 50 till de tre första elementen i listan

            var input = new List<int> { 6, 16, 23, 200, 300 };
            var expected = new List<int> { 56, 66, 73, 200, 300 };
            List<int> result = x.Add50ToFirstThreeElements(input);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add50ToFirstThreeElements_ShortList()
        {
            // Addera 50 till de tre första elementen i listan

            var input = new List<int> { 6, 16 };
            var expected = new List<int> { 56, 66 };
            var result = x.Add50ToFirstThreeElements(input);

            CollectionAssert.AreEqual(expected, result);

        }

        [TestMethod]
        public void Add70ToEverySecondElement()
        {
            // Addera 70 till varannat element i listan

            var input = new List<int> { 1000, 2000, 3000, 4000, 5000 };
            var expected = new List<int> { 1000, 2070, 3000, 4070, 5000 };
            List<int> result = x.Add70ToEverySecondElement(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CombineTwoMethods()
        {
            // Addera 50 till de tre första elementen i listan

            var input = new List<int> { 300, 200, -500, 1000 };
            var expected = new List<int> { -3, -2, 5, -10 };
            var result = x.DivideEachNumberBy100(x.NegateEachNumber(input));
            CollectionAssert.AreEqual(expected, result);
        }

    }
}
