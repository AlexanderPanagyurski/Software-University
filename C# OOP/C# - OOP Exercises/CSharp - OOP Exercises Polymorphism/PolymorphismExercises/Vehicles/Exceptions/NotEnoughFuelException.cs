using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class NotEnoughFuelException : Exception
    {
        private const string DEF_EXC_MSG = "Not enough fuel exception!";
        public NotEnoughFuelException()
            :base(DEF_EXC_MSG)
        {
        }

        public NotEnoughFuelException(string message) : base(message)
        {
        }
    }
}
