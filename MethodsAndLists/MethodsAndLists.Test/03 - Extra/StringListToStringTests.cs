// Extrauppgift: "Frame" (avancerad)

using System;
using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class StringListToStringTests
    {
        readonly StringListToString x = new StringListToString();

        [TestMethod]
        public void Frame_Long()
        {
            /*
             
            *********
            * Hello *
            * World *
            * in    *
            * a     *
            * frame *
            *********
             
             */
            string expected = "*********\n* Hello *\n* World *\n* in    *\n* a     *\n* frame *\n*********";
            string actual = x.Frame(new[] { "Hello", "World", "in", "a", "frame" });
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Frame_OneWord()
        {
            /*
             
            *********
            * Hello *
            *********
             
             */
            string expected = "*********\n* Hello *\n*********";
            string actual = x.Frame(new[] { "Hello" });
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Frame_OneLetter()
        {
            /*
             
            *****
            * H *
            *****
             
             */
            string expected = "*****\n* H *\n*****";
            string actual = x.Frame(new[] { "H" });
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Frame_NoWords()
        {
            var expected = "";
            string actual = x.Frame(new string[] { });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Frame_Exceptions()
        {
            x.Frame(null);
        }
    }
}
