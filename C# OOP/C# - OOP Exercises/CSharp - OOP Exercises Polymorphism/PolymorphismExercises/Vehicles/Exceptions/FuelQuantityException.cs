using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class FuelQuantityException : Exception
    {
        private const string DEF_EXC_MSG = "Fuel must be a positive number";
        public FuelQuantityException()
            :base(DEF_EXC_MSG)
        {
        }

        public FuelQuantityException(string message)
            : base(message)
        {
        }
    }
}
