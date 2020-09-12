using ShoppingSpree.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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
                    throw new ArgumentException(ExceptionMessages.NameException);
                }
                name = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MoneyException);
                }
                cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
