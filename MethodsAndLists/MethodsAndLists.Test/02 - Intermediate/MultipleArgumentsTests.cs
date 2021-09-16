using System;
using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class MultipleArgumentsTests
    {
        MultipleArguments x = new MultipleArguments();

        [TestMethod]
        public void ComputeSequenceSumOrProduct()
        {
            // Beräkna summan eller produkten på talen (true beräknar summan, false beräknar produkten)

            Assert.AreEqual(1 + 2 + 3 + 4 + 5, x.ComputeSequenceSumOrProduct(5, true));
            Assert.AreEqual(1 * 2 * 3 * 4 * 5, x.ComputeSequenceSumOrProduct(5, false));

            Assert.AreEqual(1 + 2 + 3, x.ComputeSequenceSumOrProduct(3, true));
            Assert.AreEqual(1 * 2 * 3, x.ComputeSequenceSumOrProduct(3, false));

            Assert.AreEqual(1, x.ComputeSequenceSumOrProduct(1, true));
            Assert.AreEqual(1, x.ComputeSequenceSumOrProduct(1, false));

            Assert.ThrowsException<ArgumentException>(() => x.ComputeSequenceSumOrProduct(0, true));
            Assert.ThrowsException<ArgumentException>(() => x.ComputeSequenceSumOrProduct(0, false));
            Assert.ThrowsException<ArgumentException>(() => x.ComputeSequenceSumOrProduct(-1, true));
            Assert.ThrowsException<ArgumentException>(() => x.ComputeSequenceSumOrProduct(-1, false));
        }

        [TestMethod]
        public void ComputeSequence()
        {
            // Beräkna summan eller produkten på talen

            Assert.AreEqual(1 + 2 + 3 + 4 + 5, x.ComputeSequence(5, ComputeMethod.Sum));
            Assert.AreEqual(1 * 2 * 3 * 4 * 5, x.ComputeSequence(5, ComputeMethod.Product));

            Assert.AreEqual(1 + 2 + 3, x.ComputeSequence(3, ComputeMethod.Sum));
            Assert.AreEqual(1 * 2 * 3, x.ComputeSequence(3, ComputeMethod.Product));

            Assert.AreEqual(1, x.ComputeSequence(1, ComputeMethod.Sum));
            Assert.AreEqual(1, x.ComputeSequence(1, ComputeMethod.Product));

            Assert.ThrowsException<ArgumentException>(() => x.ComputeSequence(0, ComputeMethod.Sum));
            Assert.ThrowsException<ArgumentException>(() => x.ComputeSequence(0, ComputeMethod.Product));
            Assert.ThrowsException<ArgumentException>(() => x.ComputeSequence(-1, ComputeMethod.Sum));
            Assert.ThrowsException<ArgumentException>(() => x.ComputeSequence(-1, ComputeMethod.Product));
        }

        [TestMethod]
        public void NearbyElements()
        {
            // Returnera närliggande elementen i listan. Den första parametern avser index för "mittenelementet".

            CollectionAssert.AreEqual(new List<string> { "c", "d", "e" },
                x.NearbyElements(3, new List<string> { "a", "b", "c", "d", "e" }));
            CollectionAssert.AreEqual(new List<string> { "a", "b" },
                x.NearbyElements(0, new List<string> { "a", "b", "c", "d", "e" }));
            CollectionAssert.AreEqual(new List<string> { "d", "e" },
                x.NearbyElements(4, new List<string> { "a", "b", "c", "d", "e" }));
        }

        [TestMethod]
        public void NearbyElements_InvalidInput()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                x.NearbyElements(-1, new List<string> { "a", "b" })
            );

            Assert.ThrowsException<ArgumentException>(() =>
                x.NearbyElements(2, new List<string> { "a", "b" })
            );

            Assert.ThrowsException<ArgumentException>(() =>
                x.NearbyElements(3, new List<string> { "a", "b" })
            );
        }

        [TestMethod]
        public void MultiplyAllBy()
        {
            //  Multiplicera alla tal i listan med den första parametern
            var expected = new List<double> { 1200, 314, 5000, 9900 };
            CollectionAssert.AreEqual(expected, x.MultiplyAllBy(100, new List<double> { 12, 3.14, 50, 99 }));


            Assert.ThrowsException<ArgumentException>(() =>
                x.MultiplyAllBy(3, null)
            );
        }

        [TestMethod]
        public void SomeToUpper()
        {

            // Returnera en ny lista där vissa ord är med stora bokstäver. 
            // Den andra parmetern är en lista av "bool" som anger vilka som ska vara stora.

            var inputWords = new List<string> { "what", "does", "the", "fox", "says" };
            var inputBools = new List<bool> { true, true, false, false, true };
            var expected = new List<string> { "WHAT", "DOES", "the", "fox", "SAYS" };

            List<string> result = x.SomeToUpper(inputWords, inputBools);
            CollectionAssert.AreEqual(expected, result);

            Assert.ThrowsException<ArgumentException>(() =>
                x.SomeToUpper(null, null)
            );
            Assert.ThrowsException<ArgumentException>(() =>
                x.SomeToUpper(null, new List<bool> { true })
            );
            Assert.ThrowsException<ArgumentException>(() =>
                x.SomeToUpper(new List<string> { "aaa"}, null)
            );
            Assert.ThrowsException<ArgumentException>(() =>
                x.SomeToUpper(new List<string> { "aaa" }, new List<bool> { true, true })
            );
        }

        [TestMethod]
        public void MultiplicationTable_2by4()
        {
            /*
             *      1      2    3    4
             *  1   1*1   1*2  1*3  1*4
             *  2   2*1   2*2  2*3  2*4
             *   
             */
            List<List<int>> table = x.MultiplicationTable(2, 4); // rad, kolumn
            Assert.AreEqual(1 * 1, table[0][0]);
            Assert.AreEqual(1 * 2, table[0][1]);
            Assert.AreEqual(1 * 3, table[0][2]);
            Assert.AreEqual(1 * 4, table[0][3]);
            Assert.AreEqual(2 * 1, table[1][0]);
            Assert.AreEqual(2 * 2, table[1][1]);
            Assert.AreEqual(2 * 3, table[1][2]);
            Assert.AreEqual(2 * 4, table[1][3]);

            Assert.AreEqual(2, table.Count);
            Assert.AreEqual(4, table[0].Count);
            Assert.AreEqual(4, table[1].Count);


            Assert.ThrowsException<ArgumentException>(() => x.MultiplicationTable(0, 5));
            Assert.ThrowsException<ArgumentException>(() => x.MultiplicationTable(5, 0));

        }

        [TestMethod]
        public void MultiplicationTable_1by1()
        {

            /*
             *      1    
             *  1   1*1
             * */
            List<List<int>> table = x.MultiplicationTable(1, 1); // rad, kolumn
            Assert.AreEqual(1 * 1, table[0][0]);
            Assert.AreEqual(1, table.Count);
            Assert.AreEqual(1, table[0].Count);

        }

        [TestMethod]
        public void CombineLists()
        {
            // Slå ihop två listor till en (ett element i taget från vardera lista)

            CollectionAssert.AreEqual(
                new[] { 1, 7, 2, 8, 3, 9 },
                x.CombineLists(
                    new[] { 1, 2, 3 },
                    new[] { 7, 8, 9 })
            );

            CollectionAssert.AreEqual(
                new[] { 1, 7, 2, 8, 3 },
                x.CombineLists(
                    new[] { 1, 2, 3 },
                    new[] { 7, 8 })
            );


            CollectionAssert.AreEqual(
                new[] { 1, 7, 2, 3 },
                x.CombineLists(
                    new[] { 1, 2, 3 },
                    new[] { 7 })
            );

            CollectionAssert.AreEqual(
                new[] { 1, 2, 3 },
                x.CombineLists(
                    new[] { 1, 2, 3 },
                    new int[] { })
            );

            CollectionAssert.AreEqual(
                new[] { 1, 7, 2, 8, 9 },
                x.CombineLists(
                    new[] { 1, 2 },
                    new[] { 7, 8, 9 })
            );

            CollectionAssert.AreEqual(
                new[] { 1, 7, 8, 9 },
                x.CombineLists(
                    new[] { 1 },
                    new[] { 7, 8, 9 })
            );


            CollectionAssert.AreEqual(
                new[] { 7, 8, 9 },
                x.CombineLists(
                    new int[] { },
                    new[] { 7, 8, 9 })
            );

        }


        [TestMethod]
        public void RotateList()
        {
            CollectionAssert.AreEqual(
                new[] { 3, 4, 5, 1, 2 },
                x.RotateList(new[] { 1, 2, 3, 4, 5 }, -2));

            CollectionAssert.AreEqual(
                new[] { 2, 3, 4, 5, 1 },
                x.RotateList(new[] { 1, 2, 3, 4, 5 }, -1));

            CollectionAssert.AreEqual(
                new[] { 3, 4, 5, 1, 2 },
                x.RotateList(new[] { 1, 2, 3, 4, 5 }, -2));

            CollectionAssert.AreEqual(
                new[] { 3, 4, 1, 2 },
                x.RotateList(new[] { 1, 2, 3, 4 }, -2));

            CollectionAssert.AreEqual(
                new[] { 3, 1, 2 },
                x.RotateList(new[] { 1, 2, 3 }, -2));

            CollectionAssert.AreEqual(
                new[] { 1, 2, 3 },
                x.RotateList(new[] { 1, 2, 3 }, -3));

            CollectionAssert.AreEqual(
                new[] { 1, 2, 3 },
                x.RotateList(new[] { 1, 2, 3 }, -30));

            CollectionAssert.AreEqual(
                new[] { 4, 5, 1, 2, 3 },
                x.RotateList(new[] { 1, 2, 3, 4, 5 }, 2));

            CollectionAssert.AreEqual(
                new[] { 1, 2, 3, 4, 5 },
                x.RotateList(new[] { 1, 2, 3, 4, 5 }, 0));

            CollectionAssert.AreEqual(
                new[] { 5, 1, 2, 3, 4 },
                x.RotateList(new[] { 1, 2, 3, 4, 5 }, 1));

            CollectionAssert.AreEqual(
                new int[] { },
                x.RotateList(new int[] { }, 22));

            Assert.ThrowsException<ArgumentException>(() => x.RotateList(null, 0));
        }

        [TestMethod]
        [DataRow("1 2 3 4 5", 0, "1 2 3 4 5")]
        [DataRow("1 2 3 4 5", 1, "5 1 2 3 4")]
        [DataRow("1 2 3 4 5", 2, "4 5 1 2 3")]
        [DataRow("1 2 3 4 5", 3, "3 4 5 1 2")]
        [DataRow("1 2 3 4 5", -1, "2 3 4 5 1")]
        [DataRow("1 2 3 4 5", -2, "3 4 5 1 2")]
        [DataRow("1 2 3 4 5", -3, "4 5 1 2 3")]

        public void RotateList_WithDataRows(string inputString, int rotation, string expectedString)
        {
            // Arrange
            int[] input = inputString.Split(" ").Select(int.Parse).ToArray();
            int[] expected = expectedString.Split(" ").Select(int.Parse).ToArray();

            // Act
            int[] actual = x.RotateList(input, rotation);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
