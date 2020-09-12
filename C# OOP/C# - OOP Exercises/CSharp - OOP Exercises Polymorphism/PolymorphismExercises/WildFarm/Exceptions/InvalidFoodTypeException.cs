using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Exceptions
{
    public class InvalidFoodTypeException : Exception
    {
        private const string DEF_MSG_EXC = "{0} does not eat {1}!";
        public InvalidFoodTypeException()
            :base(DEF_MSG_EXC)
        {
        }

        public InvalidFoodTypeException(string message)
            : base(message)
        {
        }
    }
}
