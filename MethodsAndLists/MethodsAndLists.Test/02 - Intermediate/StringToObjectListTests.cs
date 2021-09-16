using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class StringToObjectListTests
    {
        StringToObjectList x = new StringToObjectList();

        [TestMethod]
        public void parsecities_should_return_four_cites()
        {
            string input = "Göteborg,401956;Lomma,13016;Mönsterås,5201;Östra Tommarp,293";
            List<City> cities = x.ParseCities(input);

            Assert.AreEqual(4, cities.Count());

            Assert.AreEqual("Göteborg", cities[0].Name);
            Assert.AreEqual(401956, cities[0].Population);

            Assert.AreEqual("Lomma", cities[1].Name);
            Assert.AreEqual(13016, cities[1].Population);

            Assert.AreEqual("Mönsterås", cities[2].Name);
            Assert.AreEqual(5201, cities[2].Population);

            Assert.AreEqual("Östra Tommarp", cities[3].Name);
            Assert.AreEqual(293, cities[3].Population);


        }

        [TestMethod]
        [DataRow("Mönsterås,5201")]
        [DataRow("   Mönsterås  ,  5201   ")]
        [DataRow("   Mönsterås,5201 \t\n")]
        [DataRow("  \n  \tMönsterås  \n  \t,  \n  \t5201  \n  \t")]
        public void parsecities_should_return_one_city_when_just_one_city_is_supplied(string onecity)
        {
            List<City> cities = x.ParseCities(onecity);

            Assert.AreEqual(1, cities.Count());

            Assert.AreEqual("Mönsterås", cities[0].Name);
            Assert.AreEqual(5201, cities[0].Population);

        }


        [TestMethod]
        public void parsecities_should_not_allow_null()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                x.ParseCities(null);
            });

        }

        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(" \t   \t   \n  \n")]
        public void parsecities_should_give_empty_list_if_just_white_spaces_is_supplied(string input)
        {
            Assert.AreEqual(0, x.ParseCities(input).Count);
        }
    }

}
