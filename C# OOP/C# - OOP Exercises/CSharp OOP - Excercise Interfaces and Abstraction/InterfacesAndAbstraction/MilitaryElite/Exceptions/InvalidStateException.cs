using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class InvalidStateException : Exception
    {
        private const string DEF_EXC_MSG = "Invalid state input!";
        public InvalidStateException()
            :base(DEF_EXC_MSG)
        {
        }

        public InvalidStateException(string message)
            : base(message)
        {
        }
    }
}
