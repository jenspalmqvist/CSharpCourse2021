using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MethodsAndLists.Test
{

    [TestClass]
    public class NumberListToStringListTests
    {
        NumberListToStringList x = new NumberListToStringList();

        [TestMethod]
        public void AddStars()
        {
            // Lägg till tre stjärnor innan och efter siffran

            List<string> result = x.AddStars(new List<int> { 1003, 20, -130, 2040 });
            List<string> expected = new List<string> { "***1003***", "***20***", "***-130***", "***2040***" };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddStarsToNumbersHigherThan1000()
        {
            // Samma men lägg bara till stjärnor runt de som är större än 1000

            List<string> result = x.AddStarsToNumbersHigherThan1000(new List<int> { 1003, 20, -130, 2040 });
            List<string> expected = new List<string> { "***1003***", "20", "-130", "***2040***" };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NegativeNumbersIsZip_PositiveNumbersIsZap_ZeroIsBoing()
        {
            /*
            Negativa tal => "ZIP"
            Positiva tal => "ZAP"
            Noll         => "BOING"
            */

            List<string> result = x.NegativeNumbersIsZip_PositiveNumbersIsZap_ZeroIsBoing(new List<int> { 1003, 20, -130, 0, 2040 });
            List<string> expected = new List<string> { "ZAP", "ZAP", "ZIP", "BOING", "ZAP" };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LongOrShort()
        {
            // Skapa en lista av strängar som meddelar om personen är kort eller lång (över 160cm). Hoppa över orimliga värden

            List<string> result = x.LongOrShort(new List<int> { 170, 130, 205, -10, 600, 180 });
            List<string> expected = new List<string> { "170cm är långt", "130cm är kort", "205cm är långt", "180cm är långt" };

            CollectionAssert.AreEqual(expected, result);
        }

    }
}
