using System;
using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class StringToBoolTests
    {
        readonly StringToBool x = new StringToBool();

        [TestMethod]
        [DataRow("abcba")]
        [DataRow("aba")]
        [DataRow("a")]
        [DataRow("")]
        [DataRow("åäöäå")]
        public void ispalindrome_should_return_true(string input)
        {
            Assert.IsTrue(x.IsPalindrome(input));
        }

        [TestMethod]
        [DataRow("abcbaa")]
        [DataRow("aabcba")]
        [DataRow("ab")]
        [DataRow("abb")]
        [DataRow("aab")]
        public void ispalindrome_should_return_false(string input)
        {
            Assert.IsFalse(x.IsPalindrome(input));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("!")]
        [DataRow("a b")]
        [DataRow(" ")]
        public void ispalindrome_should_raise_expection_when_input_is_not_swedish_letters(string input)
        {
            // Tillåt bara svenska tecken som inparameter 

            Assert.ThrowsException<ArgumentException>(() => x.IsPalindrome(input));
        }

        [TestMethod]
        [DataRow("111 11")]
        [DataRow("999 99")]
        [DataRow("234 56")]
        public void iszipcode_should_return_true(string text)
        {
            // Kolla om texten är ett svenskt postnummer
            Assert.IsTrue(x.IsZipCode(text));
        }

        [TestMethod]

        [DataRow(null)]

        [DataRow("011 11")]
        [DataRow("099 99")]
        [DataRow("034 56")]

        [DataRow("111 01")]
        [DataRow("999 09")]
        [DataRow("234 06")]

        [DataRow(" 111 11")]
        [DataRow("999 99 ")]
        [DataRow(" 234 56 ")]

        [DataRow("11111")]
        [DataRow("9a9 99")]
        [DataRow("234 5b")]

        [DataRow("1111 11")]
        [DataRow("999 999")]
        [DataRow("2234 566")]
        public void iszipcode_should_return_false(string text)
        {
            Assert.IsFalse(x.IsZipCode(text));
        }

    }
}
