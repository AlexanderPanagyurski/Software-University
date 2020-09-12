using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable, IBirthdate,IBuyer
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public bool isFakeId(string fakeNumbers)
        {
            return this.Id.EndsWith(fakeNumbers) ? true : false;
        }

        public bool CheckYear(string year)
        {
            string yearToCheck = this.Birthdate.Split('/')[2];

            return yearToCheck == year;
        }

        public int BuyFood()
        {
            return 10;
        }
    }
}
