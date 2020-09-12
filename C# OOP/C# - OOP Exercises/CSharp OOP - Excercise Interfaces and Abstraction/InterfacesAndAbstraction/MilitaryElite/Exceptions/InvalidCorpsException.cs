using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class InvalidCorpsException : Exception
    {
        private const string DEF_EXC_MSG = "Invalid corps input!";

        public InvalidCorpsException()
            :base(DEF_EXC_MSG)
        {
        }

        public InvalidCorpsException(string message)
            : base(message)
        {
        }
    }
}
