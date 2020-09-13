using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/Results";
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //ResetDatabase(db);

            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            string json = GetUsersWithProducts(db);

            if (!Directory.Exists(ResultDirectoryPath))
            {
                Directory.CreateDirectory(ResultDirectoryPath);
            }
            File.WriteAllText(ResultDirectoryPath + "/users-and-products.json", json);

            Console.WriteLine(json);

        }

        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            context.Database.EnsureCreated();
            Console.WriteLine("Darabase was successfully created!");
        }

        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert
                    .DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert
                    .DeserializeObject<Category[]>(inputJson)
                    .Where(c => c.Name != null)
                    .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //5
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert
                    .DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        //05. Export Products In Range 
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                    .Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                    })
                    .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var successfullySoldProducts = context
                    .Users
                    .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        soldProducts = u
                            .ProductsSold
                            .Select(ps => new
                            {
                                name = ps.Name,
                                price = decimal.Parse($"{ps.Price:f2}"),
                                buyerFirstName = ps.Buyer.FirstName,
                                buyerLastName = ps.Buyer.LastName
                            })
                    })
                    .ToArray();

            string json = JsonConvert.SerializeObject(successfullySoldProducts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            return json;
        }

        // 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                    .Categories
                    .OrderByDescending(c => c.CategoryProducts.Count)
                    .Select(c => new
                    {
                        category = c.Name,
                        productsCount = c.CategoryProducts.Count,
                        averagePrice = decimal.Parse(c.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2")),
                        totalRevenue = decimal.Parse(c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2"))
                    })
                    .ToArray();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        //Problem 7
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                    .Users
                    .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                    .Select(u => new
                    {
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u
                                .ProductsSold
                                .Count(ps => ps.Buyer != null),
                            products = u
                                .ProductsSold
                                .Where(ps => ps.Buyer != null)
                                .Select(p=>new
                                {
                                    name=p.Name,
                                    price=p.Price
                                })
                                .ToArray()
                        }
                    })
                    .OrderByDescending(u=>u.soldProducts.count)
                    .ToArray();

            var resultObj = new
            {
                usersCount=users.Length,
                users=users
            };

            string json = JsonConvert.SerializeObject(resultObj, Formatting.Indented,
                 new JsonSerializerSettings
                 {
                     NullValueHandling = NullValueHandling.Ignore
                 });

            return json;
        }

    }
}