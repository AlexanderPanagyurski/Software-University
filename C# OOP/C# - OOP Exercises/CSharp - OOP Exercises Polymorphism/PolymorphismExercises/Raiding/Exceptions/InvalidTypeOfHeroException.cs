using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Exceptions
{
    public class InvalidTypeOfHeroException : Exception
    {
        private const string DEF_MSG_EXC = "Invalid hero!";
        public InvalidTypeOfHeroException()
            :base(DEF_MSG_EXC)
        {
        }

        public InvalidTypeOfHeroException(string message)
            : base(message)
        {
        }
    }
}
