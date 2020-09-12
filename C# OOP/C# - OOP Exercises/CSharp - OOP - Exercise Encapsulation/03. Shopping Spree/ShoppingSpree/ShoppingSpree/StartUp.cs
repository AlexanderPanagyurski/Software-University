using ShoppingSpree.Exceptions;
using ShoppingSpree.Models;
using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var peopleInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            try
            {



                foreach (var item in peopleInput)
                {
                    var personInput = item.Split("=");
                    Person person = new Person(personInput[0], decimal.Parse(personInput[1]));

                    People.AddPerson(person);
                }

                foreach (var item in productsInput)
                {
                    var productInput = item.Split("=");
                    Product product = new Product(productInput[0], decimal.Parse(productInput[1]));

                    Products.AddProduct(product);
                }
                string input = Console.ReadLine();
                while (input != "END")
                {
                    try
                    {
                        string[] splitInput = input.Split(" ");

                        Person person = People.GetPersonByName(splitInput[0]);

                        Product product = Products.GetProductByName(splitInput[1]);

                        if (person.Money - product.Cost >= 0)
                        {
                            person.AddProduct(product);
                            person.SpendMoney(product.Cost);

                            Console.WriteLine($"{person.Name} bought {product.Name}");
                        }
                        else
                        {
                            throw new ArgumentException(String.Format(ExceptionMessages.NotEnoughMoneyException, person.Name, product.Name));
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    input = Console.ReadLine();
                }
                try
                {
                    foreach (var person in People.Collection)
                    {
                        if (person.Products.Count > 0)
                        {
                            Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                        }
                        else
                        {
                            throw new ArgumentException(String.Format(ExceptionMessages.EmptyProductsCollectionException, person.Name));
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
         }
    }
}
