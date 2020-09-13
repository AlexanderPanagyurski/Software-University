using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private List<Person> data;
        public int Count { get => data.Count; }

        public Repository()
        {
            data = new List<Person>();
        }

        public void Add(Person person)
        {
            if (!data.Contains(person))
            {
                data.Add(person);
            }
        }

        public Person Get(int id)
        {
            return data[id];
        }
        public bool Update(int id, Person newPerson)
        {
            bool doesExist = false;

            if (data.Contains(newPerson))
            {
                doesExist = true;
                data[id] = newPerson;
            }
            return doesExist;
        }

        public bool Delete(int id)
        {
            bool doesExist = false;

            if (data.Count > id)
            {
                doesExist = true;
                data.RemoveAt(id);
            }
            return doesExist;
        }
    }
}
