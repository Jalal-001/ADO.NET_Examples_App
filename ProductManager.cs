using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQL_Server_Connections
{
    public class ProductManager : IProductDal
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public int Count()
        {
            return _productDal.Count();
        }

        public void Create(Product p)
        {
            _productDal.Create(p);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(productId);
        }

        public List<Product> Find(string productName)
        {
            return _productDal.Find(productName);
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetAllProducts();
        }

        public Product getProductById(int id)
        {
            return _productDal.getProductById(id);
        }

        public void Update(Product p)
        {
            _productDal.Update(p);
        }
    }
}