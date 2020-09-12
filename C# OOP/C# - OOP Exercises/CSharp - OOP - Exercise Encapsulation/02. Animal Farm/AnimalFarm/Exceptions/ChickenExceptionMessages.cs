using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm.Exceptions
{
    public static class ChickenExceptionMessages
    {
        private const string DefaultNameException = "Name cannot be empty.";
        private const string DefaultAgeException = "Age should be between 0 and 15.";

        public static string NameException { get=> DefaultNameException; }
        public static string AgeException { get => DefaultAgeException; }

    }
}
