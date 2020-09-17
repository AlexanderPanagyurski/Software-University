using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/Results";
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(db, usersXml));

            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(db, productsXml));

            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(db, categoriesXml));

            //var categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(db, categoryProductsXml));

            string xml = GetSoldProducts(db);

            if (!Directory.Exists(ResultDirectoryPath))
            {
                Directory.CreateDirectory(ResultDirectoryPath);
            }
            File.WriteAllText(ResultDirectoryPath + "/users-with-sold-products.xml", xml);

            Console.WriteLine(xml);
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string xmlRoot = "Users";

            var usersResult = XMLConverter.Deserializer<ImportUserDto>(inputXml, xmlRoot);

            var users = new List<User>();

            foreach (var importUserDto in usersResult)
            {
                var user = new User
                {
                    FirstName = importUserDto.FirstName,
                    LastName = importUserDto.LastName,
                    Age = importUserDto.Age
                };
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string xmlRoot = "Products";

            var productsResult = XMLConverter.Deserializer<ImportProductDto>(inputXml, xmlRoot);

            var products = new List<Product>();

            foreach (var importProductDto in productsResult)
            {
                var product = new Product
                {
                    Name = importProductDto.Name,
                    Price = importProductDto.Price,
                    SellerId = importProductDto.SellerId,
                    BuyerId = importProductDto.BuyerId
                };

                products.Add(product);
            }
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string xmlRoot = "Categories";

            var categoriesResult = XMLConverter.Deserializer<ImportCategoryDto>(inputXml, xmlRoot);

            var categories = new List<Category>();

            foreach (var importCategoryDto in categoriesResult)
            {
                var category = new Category
                {
                    Name = importCategoryDto.Name
                };
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string xmlRoot = "CategoryProducts";

            var categoryProductsResult = XMLConverter.Deserializer<ImportCategoryProductsDto>(inputXml, xmlRoot);

            var categoryProducts = new List<CategoryProduct>();

            foreach (var importCategoryProductsDto in categoryProductsResult)
            {
                var categoryProduct = new CategoryProduct
                {
                    CategoryId = importCategoryProductsDto.CategoryId,
                    ProductId = importCategoryProductsDto.ProductId
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            const string xmlRoot = "Products";
            var products = context
                    .Products
                    //.Where(p => p.Price >= 500 && p.Price <= 100)
                    .Select(p => new ExportProductDto
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                    })
                    .OrderBy(p => p.Price)
                    .Take(10)
                    .ToArray();
            var xml = XMLConverter.Serialize(products, xmlRoot);

            return xml;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            const string xmlRoot = "Users";

            var users = context
                    .Users
                    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                    .Select(u => new ExportUserSoldProductDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        SoldProducts = u
                            .ProductsSold
                            .Select(p => new ProductDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToArray()
                    })
                    .ToArray();

            var xml = XMLConverter.Serialize(users, xmlRoot);

            return xml;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string xmlRoot = "Categories";

            var categories = context
                    .Categories
                    .Select(c => new ExportCategoryDto
                    {
                        Name = c.Name,
                        Count = c.CategoryProducts.Count,
                        AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                        TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                    })
                    .OrderByDescending(c => c.Count)
                    .ThenBy(c => c.TotalRevenue)
                    .ToArray();

            var xml = XMLConverter.Serialize(categories, xmlRoot);

            return xml;
        }
    }
}