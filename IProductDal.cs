using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQL_Server_Connections
{
    public interface IProductDal
    {
        List<Product> GetAllProducts();
        List<Product> Find(string productName);
        Product getProductById(int id);
        int Count();
        void Create(Product p);
        void Update(Product p);
        void Delete(int productId);
    }
}