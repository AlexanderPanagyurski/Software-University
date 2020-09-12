using ShoppingSpree.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Person
    {
        //name, money and a bag of products

        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
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

        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MoneyException);
                }
                money = value;
            }
        }
        private List<Product> products = new List<Product>();

        public IReadOnlyCollection<Product> Products => products.AsReadOnly();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void SpendMoney(decimal cost)
        {
            this.Money -= cost;
        }
    }
}
