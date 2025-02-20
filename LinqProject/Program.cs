﻿using System;
namespace LinqProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
               new Category{CategoryId=1,CategoryName="Bilgisayar"},
               new Category{CategoryId=2, CategoryName="Telefon"}
            };

            List<Product> products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Acer Laptop",QuatityPerUnit="32 GB Ram",UnitPrice=10000,UnitsInStock=5},
                new Product{ProductId=2,CategoryId=1,ProductName="Asus Laptop",QuatityPerUnit="16 GB Ram",UnitPrice=8000,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=1,ProductName="Hp Laptop",QuatityPerUnit="8 GB Ram",UnitPrice=6000,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Samsung Telefon",QuatityPerUnit="4 GB Ram",UnitPrice=10000,UnitsInStock=15},
                new Product{ProductId=5,CategoryId=2,ProductName="Apple Telefon",QuatityPerUnit="4 GB Ram",UnitPrice=8000,UnitsInStock=0},
            };

            //Test(products);

            //AnyTest(products);

            //FindTest(products);

            //FindAllTest(products);

            //AscDescTest(products);

            //ClassicLinqTest(products);

            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                         select new ProductDto { CategoryName = c.CategoryName, ProductName = p.ProductName, UnitPrice = p.UnitPrice, ProductId = p.ProductId };

            foreach (var productDto in result)
            {
                Console.WriteLine(productDto.ProductName + "---" + productDto.CategoryName);
            }
        }

        private static void ClassicLinqTest(List<Product> products)
        {
            var result = from p in products
                         where p.UnitsInStock > 2
                         orderby p.UnitPrice descending, p.ProductName ascending
                         select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            // Single Line Query

            var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top"));
            Console.WriteLine(result);
        }

        private static void FindTest(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 3);
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Laptop");
            Console.WriteLine(result);
        }

        private static void Test(List<Product> products)
        {
            Console.WriteLine("-----Algoritmik-----");

            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    Console.WriteLine(product.ProductName);
                }
            }

            Console.WriteLine("-----Linq-----");

            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
                Console.ReadLine();
            }
        }
    }

    class ProductDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuatityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

    }

    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

}
