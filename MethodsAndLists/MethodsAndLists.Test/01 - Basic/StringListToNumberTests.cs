using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class StringListToNumberTests
    {
        StringListToNumber x = new StringListToNumber();

        /*
            Hissen börjar på våning 0. 
            För varje "UPP" åker den upp en våning
            För varje "NER" åker den ner en våning
            */

        [TestMethod]
        [DataRow(null, 2, new[] { "UPP", "NER", "UPP", "UPP" })]
        [DataRow(null, -3, new[] { "NER", "NER", "NER" })]
        [DataRow(null, -1, new[] { "NER" })]
        [DataRow(null, 3, new[] { "UPP", "UPP", "UPP" })]
        [DataRow(null, 1, new[] { "UPP" })]
        public void ElevatorGoUpAndDown(object dummy, int expected, string[] input)
        {
            int result = x.ElevatorGoUpAndDown(input);
            Assert.AreEqual(expected, result);

        }
    }
}
