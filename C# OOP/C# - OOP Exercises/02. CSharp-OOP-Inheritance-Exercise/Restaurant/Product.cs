using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        private string name;

        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                price = value;
            }
        }


    }
}
