using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class LinqUsageTests
    {
        LinqUsage x = new LinqUsage();
        List<Person> personList = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText("persons.json"));

        [TestMethod]
        public void FindPersonsInTown()
        {
            List<Person> personsInBollberg = x.FindPersonsInTown(personList, "Bollberg");

            Assert.AreEqual(2, personsInBollberg.Count());

            Assert.AreEqual("Donya", personsInBollberg[0].Name);
            Assert.AreEqual("Ludolf", personsInBollberg[1].Name);

            List<Person> personsInSundbyberg = x.FindPersonsInTown(personList, "Sundbyberg");

            Assert.AreEqual(3, personsInSundbyberg.Count());

            Assert.AreEqual("Agathon", personsInSundbyberg[0].Name);
            Assert.AreEqual("Cecil", personsInSundbyberg[1].Name);
            Assert.AreEqual("Dagny", personsInSundbyberg[2].Name);
        }


        [TestMethod]
        public void FindAllPersonsOverAge()
        {
            List<Person> personsOver35 = x.FindAllPersonsOverAge(personList, 35);

            Assert.AreEqual(4, personsOver35.Count());

            Assert.AreEqual("Agathon", personsOver35[0].Name);
            Assert.AreEqual("Cecil", personsOver35[1].Name);
            Assert.AreEqual("Dagny", personsOver35[2].Name);
            Assert.AreEqual("Ludolf", personsOver35[3].Name);
        }

        [TestMethod]
        public void FindPersonsOnSameAddress()
        {
            List<Person> personsOnSameAddress = x.FindPersonsOnSameAddress(personList);

            Assert.AreEqual(2, personsOnSameAddress.Count());

            Assert.AreEqual("Cecil", personsOnSameAddress[0].Name);
            Assert.AreEqual("Dagny", personsOnSameAddress[1].Name);
        }

        [TestMethod]
        public void SortByAge()
        {
            List<Person> personsSortedByAge = x.SortByAge(personList, false);

            Assert.AreEqual("Donya", personsSortedByAge[0].Name);
            Assert.AreEqual("Bernhard", personsSortedByAge[1].Name);
            Assert.AreEqual("Jasmin", personsSortedByAge[2].Name);
            Assert.AreEqual("Jenz", personsSortedByAge[3].Name);
            Assert.AreEqual("Ludolf", personsSortedByAge[4].Name);
            Assert.AreEqual("Dagny", personsSortedByAge[5].Name);
            Assert.AreEqual("Cecil", personsSortedByAge[6].Name);
            Assert.AreEqual("Agathon", personsSortedByAge[7].Name);

            List<Person> personsSortedByAgeDescending = x.SortByAge(personList, true);

            Assert.AreEqual("Agathon", personsSortedByAgeDescending[0].Name);
            Assert.AreEqual("Cecil", personsSortedByAgeDescending[1].Name);
            Assert.AreEqual("Dagny", personsSortedByAgeDescending[2].Name);
            Assert.AreEqual("Ludolf", personsSortedByAgeDescending[3].Name);
            Assert.AreEqual("Jenz", personsSortedByAgeDescending[4].Name);
            Assert.AreEqual("Bernhard", personsSortedByAgeDescending[5].Name);
            Assert.AreEqual("Jasmin", personsSortedByAgeDescending[6].Name);
            Assert.AreEqual("Donya", personsSortedByAgeDescending[7].Name);
        }
    }
}