using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class StringListToBoolTests
    {
        StringListToBool x = new StringListToBool();

        [TestMethod]
        [DataRow(new[] { "abcdef", "friday", "ooooooooo" })]
        public void all_words_are_longer_than_five_letters(string[] input)
        {
            Assert.IsTrue(x.AllWordsAreFiveLettersOrLonger(input));
            Assert.IsTrue(x.AllWordsAreFiveLettersOrLonger_Linq(input));
        }


        [TestMethod]
        [DataRow(new[] { "abcdef", "fri", "ooooooooo" })]
        [DataRow(null)]
        public void all_words_are_longer_than_five_letters_should_return_false(string[] input)
        {
            Assert.IsFalse(x.AllWordsAreFiveLettersOrLonger(input));
            Assert.IsFalse(x.AllWordsAreFiveLettersOrLonger_Linq(input));
        }
    }
}
