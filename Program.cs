using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using SQL_Server_Connections;



// 1 - GetAllProducts

// var productDal = new ProductManager(new MSSqlProductDal());

// var products = productDal.GetAllProducts();
// foreach (var item in products)
// {
//     System.Console.WriteLine($"name: {item.Name}");
// }

// 2 - getProductById

// var productDal = new ProductManager(new MySQLProductDal());
// var product = productDal.getProductById(3);
// System.Console.WriteLine($"{product.Name}");

// 3 - Find

// var productDal = new ProductManager(new MSSqlProductDal());
// var products = productDal.Find("Sauce");
// foreach (var product in products)
// {
//     Console.WriteLine($"Name: {product.Name} Price: {product.Price}");
// }

// 4 - Count

// var productDal = new ProductManager(new MSSqlProductDal());
// var count = productDal.Count();
// Console.WriteLine(count);

// 5 - Create
// var productDal = new ProductManager(new MySQLProductDal());
// var product = new Product()
// {
//     Name = "Iphone 13 Pro",
//     Price = 4000,

// };
// productDal.Create(product);

// 6 - Update 
// var productDal = new ProductManager(new MySQLProductDal());
// // 6.1
// var product = new Product()
// {
//     ID = 101,
//     Name = "Iphone 12 Pro",
//     Price = 3350
// };
// productDal.Update(product);
//6.2
// var product = productDal.getProductById(80);
// product.Name = "Iphone 12 Mini";
// product.Price = 2200;

// productDal.Update(product);

// 7 - Delete

var productDal = new ProductManager(new MySQLProductDal());
productDal.Delete(102);










