using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MethodsAndLists.Test
{

    [TestClass]
    public class NumberListToStringTests
    {
        NumberListToString x = new NumberListToString();

        [TestMethod]
        public void ReportFirstAndLastValue()
        {
            // Returnera en text som talar om vilket det första och sista numret är i listan
            string result = x.ReportFirstAndLastValue(new List<int> { 5, 1000, 2000, 3000, 6 });
            Assert.AreEqual("Första siffran är 5 och sista siffran är 6", result);
        }

        [TestMethod]
        public void ReportFirstAndLastValue_EmptyList()
        {
            Assert.ThrowsException<ArgumentException>(() =>

                x.ReportFirstAndLastValue(new List<int>())

            );

            Assert.ThrowsException<ArgumentException>(() =>

                x.ReportFirstAndLastValue(null)

            );
        }


        [TestMethod]
        public void ReportNumberOfNegativeValues()
        {
            // Returnera en text hur många negativa tal som finns i listan
            Assert.AreEqual("Det finns 2 st negativa tal i listan", x.ReportNumberOfNegativeValues(new List<int> { 5, 7, -2, 100, -4 }));
            Assert.AreEqual("Jippi! Det finns inga negativa tal i listan", x.ReportNumberOfNegativeValues(new List<int> { 5, 7, 44, 100, 33 }));
            Assert.AreEqual("Det finns ett negativt tal i listan", x.ReportNumberOfNegativeValues(new List<int> { 5, 7, -2, 100, 4 }));
        }

    }
}
