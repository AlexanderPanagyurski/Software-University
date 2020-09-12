using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet:IBirthdate
    {
        public string Name { get; private set; }


        public string Birthdate { get; private set; }

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public bool CheckYear(string year)
        {
            string yearToCheck = this.Birthdate.Split('/')[2];

            return yearToCheck == year;
        }
    }
}
