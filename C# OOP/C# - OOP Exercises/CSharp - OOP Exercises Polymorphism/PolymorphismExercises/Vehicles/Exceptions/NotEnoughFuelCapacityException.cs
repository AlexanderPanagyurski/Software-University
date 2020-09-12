using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class NotEnoughFuelCapacityException : Exception
    {
        private const string DEF_EXC_MSG = "Not enough tank capacity!";
        public NotEnoughFuelCapacityException()
            :base(DEF_EXC_MSG)
        {
        }

        public NotEnoughFuelCapacityException(string message)
            : base(message)
        {
        }
    }
}
