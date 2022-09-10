using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SQL_Server_Connections
{
    public class MySQLProductDal : IProductDal
    {
        public List<Product> Find(string productName)
        {
            List<Product> products = null;

            static MySqlConnection GetMySqlConnection()
            {
                string connectionString = @"";
                return new MySqlConnection(connectionString);
            }
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();
                    string commandText = "Select *from products where product_name LIKE @productName";
                    var command = new MySqlCommand(commandText, connection);
                    command.Parameters.Add("@productName", MySqlDbType.String).Value = "%" + productName + "%";
                    MySqlDataReader reader = command.ExecuteReader();

                    products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add
                        (
                            new Product
                            {
                                ID = int.Parse(reader["id"].ToString()),
                                Name = reader["product_name"].ToString(),
                                Price = double.Parse(reader["list_price"].ToString())
                            }
                        );
                    }
                    reader.Close();
                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }
        public void Create(Product p)
        {
            static MySqlConnection GetMySqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new MySqlConnection(connectionString);
            }

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string SelectCommand = "INSERT INTO products(product_name,list_price,discontinued) VALUES (@productname,@unitprice,@discontinued)";
                    MySqlCommand command = new MySqlCommand(SelectCommand, connection);
                    command.Parameters.AddWithValue("@productname", p.Name);
                    command.Parameters.AddWithValue("@unitprice", p.Price);
                    command.Parameters.AddWithValue("@discontinued", 1);
                    int result = command.ExecuteNonQuery();
                    Console.WriteLine($"{result} Product added ");
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void Delete(int productId)
        {
            static MySqlConnection GetSqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new MySqlConnection(connectionString);
            }

            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();

                    string SelectCommand = "Delete from products where id=@productId";
                    MySqlCommand command = new MySqlCommand(SelectCommand, connection);
                    command.Parameters.AddWithValue("@productId", productId);

                    int result = command.ExecuteNonQuery();
                    Console.WriteLine($"{result} Product Deleted");
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public List<Product> GetAllProducts()
        {
            static MySqlConnection GetMySqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new MySqlConnection(connectionString);
            }

            List<Product> products = null;

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string commandText = "Select *from products";
                    MySqlCommand command = new MySqlCommand(commandText, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ID = int.Parse(reader["id"].ToString()),
                            Name = reader["product_name"].ToString(),
                            Price = double.Parse(reader["list_price"].ToString())
                        });
                    }
                    reader.Close();
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }
        public Product getProductById(int id)
        {
            static MySqlConnection GetMySqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new MySqlConnection(connectionString);
            }

            Product product = null;

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string commandText = "Select *from products where id=@productID";

                    MySqlCommand command = new MySqlCommand(commandText, connection);
                    command.Parameters.Add("@productID", MySqlDbType.Int32).Value = id;
                    MySqlDataReader reader = command.ExecuteReader();
                    product = new Product();

                    reader.Read();
                    if (reader.HasRows)
                    {
                        product = new Product()
                        {
                            ID = int.Parse(reader["id"].ToString()),
                            Name = reader["product_name"].ToString(),
                            Price = double.Parse(reader["list_price"].ToString())
                        };
                    }

                    reader.Close();
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return product;
        }
        public void Update(Product p)
        {
            static MySqlConnection GetMySqlConnection()
            {
                string connectionString = @"";
                return new MySqlConnection(connectionString);
            }
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string SelectCommand = "Update products Set product_name=@productname,list_price=@unitprice Where id=@productid";
                    MySqlCommand command = new MySqlCommand(SelectCommand, connection);
                    command.Parameters.AddWithValue("@productname", p.Name);
                    command.Parameters.AddWithValue("@unitprice", p.Price);
                    command.Parameters.AddWithValue("@productid", p.ID);
                    int result = command.ExecuteNonQuery();
                    Console.WriteLine($"{result} Product Updated ");
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public int Count()
        {
            int Count = 0;
            static MySqlConnection GetMySqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new MySqlConnection(connectionString);
            }

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string commandText = "Select Count(*) from products";
                    MySqlCommand command = new MySqlCommand(commandText, connection);
                    var result = command.ExecuteScalar();
                    Count = Convert.ToInt32(result);
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return Count;
        }
    }
}