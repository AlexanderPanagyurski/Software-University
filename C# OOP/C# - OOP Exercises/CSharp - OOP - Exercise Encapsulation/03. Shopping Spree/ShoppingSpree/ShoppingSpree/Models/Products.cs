using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Models
{
    public static class Products
    {
        private static List<Product> products = new List<Product>();
        public static IReadOnlyCollection<Product> Collection => products.AsReadOnly();

        public static void AddProduct(Product product)
        {
            products.Add(product);
        }

        public static Product GetProductByName(string name)
        {
            return products.Find(p => p.Name == name);
        }
    }
}
