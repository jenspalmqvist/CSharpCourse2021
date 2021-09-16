using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndLists.Core
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
    }
    public class LinqUsage
    {

        public List<Person> FindPersonsInTown(List<Person> persons, string town)
        {
            return persons.Where(person => person.Adress.Contains(town)).ToList();
        }
        public List<Person> FindAllPersonsOverAge(List<Person> persons, int age)
        {
            return persons.Where(person => person.Age > 35).ToList();
        }
        public List<Person> FindPersonsOnSameAddress(List<Person> persons)
        {
            return persons.GroupBy(person => person.Adress).Where(group => group.Count() == 2).First().ToList();
        }

    
        public List<Person> SortByAge(List<Person> persons, bool descending)
        {
            return descending ? persons.OrderByDescending(person => person.Age).ToList() : persons.OrderBy(person => person.Age).ToList();
        }
    }
}