using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || (value != "Male" && value != "Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}" + Environment.NewLine);
            sb.Append($"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine);

            return sb.ToString().TrimEnd();
        }
    }
}
