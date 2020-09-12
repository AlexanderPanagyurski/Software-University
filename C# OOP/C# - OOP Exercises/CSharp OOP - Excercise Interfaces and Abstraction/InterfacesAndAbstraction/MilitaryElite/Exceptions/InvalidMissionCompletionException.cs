using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string DEF_EXC_MSG = "Mission is already completed!";
        public InvalidMissionCompletionException()
            :base(DEF_EXC_MSG)
        {
        }

        public InvalidMissionCompletionException(string message)
            : base(message)
        {
        }
    }
}
