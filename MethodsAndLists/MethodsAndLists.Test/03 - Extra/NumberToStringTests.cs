// Extrauppgift

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MethodsAndLists.Core;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class NumberToStringTests
    {
        readonly NumberToString x = new NumberToString();

        // Extrauppgift: "Triangle"

        [TestMethod]
        public void Triangle()
        {
            Assert.ThrowsException<ArgumentException>(() => x.Triangle(-1));
            Assert.ThrowsException<ArgumentException>(() => x.Triangle(-10));

            {
                string actual = x.Triangle(0);
                var expected = "";
                Assert.AreEqual(expected, actual);
            }
            {
                var actual = x.Triangle(1);
                var expected = "*";
                Assert.AreEqual(expected, actual);
            }
            {
                var actual = x.Triangle(3);
                var expected = "*\n**\n***";
                Assert.AreEqual(expected, actual);
            }
            {
                var actual = x.Triangle(4);
                var expected = "*\n**\n***\n****";
                Assert.AreEqual(expected, actual);
            }
            {
                string actual = x.Triangle(4,'+');
                var expected = "+\n++\n+++\n++++";
                Assert.AreEqual(expected, actual);
            }
            {
                string actual = x.TriangleReversed(4);
                var expected = "****\n***\n**\n*";
                Assert.AreEqual(expected, actual);
            }
        }

    }
}
