using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {
        private double grams;
        public Food(string name, decimal price,double grams)
            : base(name, price)
        {
            this.Grams = grams;
        }

        public double Grams
        {
            get
            {
                return grams;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException();
                }
                grams = value;
            }
        }
    }
}
