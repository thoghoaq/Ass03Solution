using System.Collections.Generic;
using BusinessObject.BusinessObject;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductByID(int productID) => ProductDAO.Instance.getProductByID(productID);
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.getProductList();
        public void InsertProduct(Product product) => ProductDAO.Instance.addNew(product);
        public void DeleteProduct(int productID) => ProductDAO.Instance.remove(productID);
        public void UpdateProduct(Product product) => ProductDAO.Instance.update(product);
    }
}
