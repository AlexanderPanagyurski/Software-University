using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Models
{
    public static  class People
    {
        private static List<Person> people = new List<Person>();

        public static IReadOnlyCollection<Person> Collection => people.AsReadOnly();

        public static void AddPerson(Person person)
        {
            people.Add(person);
        }

        public static Person GetPersonByName(string name)
        {
            return people.Find(p => p.Name == name);
        }
    }
}
