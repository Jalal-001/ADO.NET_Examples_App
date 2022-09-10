using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SQL_Server_Connections
{
    public class MSSqlProductDal : IProductDal
    {
        public int Count()
        {
            int Count = 0;
            static SqlConnection GetMySqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new SqlConnection(connectionString);
            }

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string commandText = "Select Count(*) from products";
                    SqlCommand command = new SqlCommand(commandText, connection);
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

        public void Create(Product p)
        {
            static SqlConnection GetSqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new SqlConnection(connectionString);
            }

            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();

                    string SelectCommand = "INSERT INTO products(ProductName,UnitPrice,Discontinued) VALUES (@productname,@unitprice,@discontinued)";
                    SqlCommand command = new SqlCommand(SelectCommand, connection);
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
            static SqlConnection GetSqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new SqlConnection(connectionString);
            }

            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();

                    string SelectCommand = "Delete from products where ProductID=@productId";
                    SqlCommand command = new SqlCommand(SelectCommand, connection);
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

        public List<Product> Find(string productName)
        {
            List<Product> products = null;

            static SqlConnection GetMySqlConnection()
            {
                string connectionString = @"";
                return new SqlConnection(connectionString);
            }
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();
                    string commandText = "Select *from products where ProductName LIKE @productName";
                    var command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@productName", System.Data.SqlDbType.NVarChar).Value = "%" + productName + "%";
                    SqlDataReader reader = command.ExecuteReader();

                    products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add
                        (
                            new Product
                            {
                                ID = int.Parse(reader["ProductID"].ToString()),
                                Name = reader["ProductName"].ToString(),
                                Price = double.Parse(reader["UnitPrice"].ToString())
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

        public List<Product> GetAllProducts()
        {
            static SqlConnection GetSqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new SqlConnection(connectionString);
            }

            List<Product> products = null;

            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();

                    string SelectCommand = "Select *from products";
                    SqlCommand command = new SqlCommand(SelectCommand, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ID = int.Parse(reader["ProductID"].ToString()),
                            Name = reader["ProductName"].ToString(),
                            Price = double.Parse(reader["UnitPrice"].ToString())
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
            static SqlConnection GetMSSqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new SqlConnection(connectionString);
            }

            Product product = null;

            using (var connection = GetMSSqlConnection())
            {
                try
                {
                    connection.Open();

                    string commandText = "Select *from products where ProductID=@productID";

                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.AddWithValue("@productID", id);
                    SqlDataReader reader = command.ExecuteReader();
                    product = new Product();

                    reader.Read();
                    if (reader.HasRows)
                    {
                        product = new Product()
                        {
                            ID = int.Parse(reader["ProductID"].ToString()),
                            Name = reader["ProductName"].ToString(),
                            Price = double.Parse(reader["UnitPrice"].ToString())
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
            static SqlConnection GetSqlConnection()
            {
                string connectionString = @"";
                // Provider/Driver
                return new SqlConnection(connectionString);
            }

            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();

                    string SelectCommand = "Update products Set ProductName=@productname,UnitPrice=@unitprice Where ProductID=@productid";
                    SqlCommand command = new SqlCommand(SelectCommand, connection);
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
    }
}